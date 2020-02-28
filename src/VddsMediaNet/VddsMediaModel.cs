using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using IniParser;
using IniParser.Model;
using VddsMediaNet.Attributes;
using VddsMediaNet.Converters;

namespace VddsMediaNet
{
    public class VddsMediaModel
    {
        public string FilePath { get; set; }

        public IniData Data { get; set; }


        private readonly FileIniDataParser _parser;


        public VddsMediaModel()
        {
            _parser = new FileIniDataParser();

            Data = new IniData();
            Data.Configuration.AssigmentSpacer = string.Empty;
        }

        public VddsMediaModel(string path, bool create = false)
            : this()
        {
            FilePath = path ?? throw new ArgumentNullException(nameof(path));

            if (create && !File.Exists(FilePath))
            {
                using (var fileStream = File.Create(FilePath))
                {

                }
            }

            Data = _parser.ReadFile(FilePath, Encoding.GetEncoding("iso-8859-1"));
            Data.Configuration.AssigmentSpacer = string.Empty;
        }


        public void Write(string path = null)
        {
            if (path == null && FilePath == null)
            {
                throw new ArgumentNullException(path);
            }

            _parser.WriteFile(path ?? FilePath, Data, Encoding.GetEncoding("iso-8859-1"));
        }


        protected void ReadProperties(string defaultSection = null)
        {
            foreach (var property in GetType().GetProperties())
            {
                var attribute = (VddsMediaFieldAttribute)property.GetCustomAttributes(typeof(VddsMediaFieldAttribute), false).FirstOrDefault();

                if (attribute == null)
                {
                    continue;
                }

                var section = attribute.Section ?? defaultSection;

                if (section == null)
                {
                    continue;
                }

                if (!Data.Sections.ContainsSection(section) || !Data[section].ContainsKey(attribute.Name))
                {
                    continue;
                }

                ReadKey(property, Data[section][attribute.Name]);
            }
        }

        protected void WriteProperties(string defaultSection = null)
        {
            foreach (var property in GetType().GetProperties())
            {
                var attribute = (VddsMediaFieldAttribute)property.GetCustomAttributes(typeof(VddsMediaFieldAttribute), false).FirstOrDefault();

                if (attribute == null)
                {
                    continue;
                }

                var section = attribute.Section ?? defaultSection;

                if (section == null)
                {
                    continue;
                }

                WriteKey(section, attribute.Name, property.GetValue(this), property.PropertyType);
            }
        }


        protected void ReadKey(PropertyInfo property, string value)
        {
            if (property is null) throw new ArgumentNullException(nameof(property));

            var type = property.PropertyType;

            var converter = GetConverterForType(type);

            if (converter == null)
            {
                return;
            }

            property.SetValue(this, converter.ConvertBack(value, type));
        }

        protected void WriteKey(string section, string key, object value, Type type = null)
        {
            if (section is null) throw new ArgumentNullException(nameof(section));
            if (key is null) throw new ArgumentNullException(nameof(key));

            if (value == null)
            {
                return;
            }

            var converter = GetConverterForType(type ?? value.GetType());

            if (converter == null || converter.Convert(value) == null)
            {
                return;
            }

            if (!Data.Sections.ContainsSection(section))
            {
                Data.Sections.AddSection(section);
            }

            if (Data[section].ContainsKey(key))
            {
                Data[section][key] = converter.Convert(value);
            }
            else
            {
                Data[section].AddKey(key, converter.Convert(value));
            }
        }


        private IVddsMediaConverter GetConverterForType(Type type)
        {
            if (type == typeof(bool) || type == typeof(bool?))
            {
                return new BoolConverter();
            }
            else if (type == typeof(DateTime) || type == typeof(DateTime?))
            {
                return new DateConverter();
            }
            else if (type.IsEnum)
            {
                return new EnumConverter();
            }
            else if (type == typeof(int) ||type == typeof(int?))
            {
                return new IntConverter();
            }
            else if (type == typeof(string))
            {
                return new StringConverter();
            }

            return null;
        }


        protected static bool ContainsSection(string path, string section)
        {
            IniData data;

            try
            {
                var parser = new FileIniDataParser();
                data = parser.ReadFile(path, Encoding.GetEncoding("iso-8859-1"));
            }
            catch
            {
                return false;
            }

            if (!data.Sections.ContainsSection(section))
            {
                return false;
            }

            return true;
        }
    }
}