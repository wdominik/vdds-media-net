using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using VddsMediaNet.Attributes;
using VddsMediaNet.Delegate;

namespace VddsMediaNet
{
    public class MultimediaExport : VddsMediaModel, IVddsMediaRequest
    {
        [VddsMediaField(VddsMediaFieldIdentifier.PatientManagementSystem, Section = VddsMediaSectionIdentifier.MultimediaExportSection)]
        public string PatientManagementSystem { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Count, Section = VddsMediaSectionIdentifier.MultimediaExportSection)]
        public int? Count { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.Ready, Section = VddsMediaSectionIdentifier.MultimediaExportSection)]
        public bool? Ready { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.ErrorLevel, Section = VddsMediaSectionIdentifier.MultimediaExportSection)]
        public int? ErrorLevel { get; set; }

        [VddsMediaField(VddsMediaFieldIdentifier.ErrorText, Section = VddsMediaSectionIdentifier.MultimediaExportSection)]
        public string ErrorText { get; set; }

        public IVddsMediaDelegate Delegate { get; set; }


        private Dictionary<int, string> MultimediaIds { get; set; } = new Dictionary<int, string>();

        private Dictionary<int, string> MultimediaPaths { get; set; } = new Dictionary<int, string>();


        public MultimediaExport()
            : base()
        {

        }

        public MultimediaExport(string path, bool create = false)
            : base(path, create)
        {

        }


        public void Process()
        {
            ReadProperties();

            if (!Data.Sections.ContainsSection(VddsMediaSectionIdentifier.MultimediaExportSection))
            {
                return;
            }

            var regex = new Regex(@"MMOID(\d+)");

            foreach (var key in Data[VddsMediaSectionIdentifier.MultimediaExportSection])
            {
                var match = regex.Match(key.KeyName);

                if (match.Success)
                {
                    MultimediaIds.Add(int.Parse(match.Groups[1].Value), key.Value);
                }
            }
        }

        public void Responde()
        {
            var suceededObjects = 0;

            if (MultimediaIds.Any())
            {
                foreach (var id in MultimediaIds)
                {
                    try
                    {
                        var path = Delegate?.GetPathForMultimediaObject(id.Value);

                        if (path != null)
                        {
                            MultimediaPaths.Add(id.Key, path);
                            suceededObjects += 1;
                        }
                    }
                    catch
                    {
                        // Completeness will be verified later
                    }
                }
            }

            Ready = true;

            if (Count.HasValue && suceededObjects != Count.Value)
            {
                Count = 0;
                ErrorLevel = 1;
                ErrorText = "Not all all objects could be fetched successfully";
            }

            if (!ErrorLevel.HasValue)
            {
                ErrorLevel = 0;
            }

            WriteProperties();

            if (MultimediaPaths.Any())
            {
                foreach (var path in MultimediaPaths)
                {
                    WriteKey("MMOPATH", $"MMOID{path.Key}", path.Value);
                }
            }

            Write();
        }


        public static bool IsRequest(string path)
        {
            return ContainsSection(path, VddsMediaSectionIdentifier.MultimediaExportSection);
        }
    }
}