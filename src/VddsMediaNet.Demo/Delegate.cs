using System;
using System.Collections.Generic;
using System.IO;
using VddsMediaNet.Delegate;

namespace VddsMediaNet.Demo
{
    public class Delegate : IVddsMediaDelegate
    {
        public void ImportPatient(IPatient patient)
        {
            Console.WriteLine($"Patient {patient.GivenName} {patient.FamilyName} imported");
            Console.ReadKey();
        }

        public void ShowPatient(string id)
        {
            Console.WriteLine($"Opening patient {id} in client...");
            Console.ReadKey();
        }

        public IEnumerable<MultimediaObject> GetMultimediaObjectsForPatient(string id, DateTime? fromDate = null)
        {
            var documentId = string.Empty;

            if (id == "0")
            {
                documentId = "1";
            }
            else if (id == "1")
            {
                documentId = "2";
            }

            var date = new DateTime(2016, 12, 1);

            var result = new List<MultimediaObject>();

            result.Add(new MultimediaObject()
            {
                MultimediaObjectId = documentId,
                Type = MultimediaObjectType.ProfilePhoto,
                TypeId = MultimediaObjectTypeId.ProfilePhoto,
                Extension = MultimediaObjectExtension.Jpeg,
                ColorType = MultimediaObjectColorType.Color,
                Date = date,
                Comment = "Patient"
            });

            return result;
        }

        public string GetPathForMultimediaObject(string id)
        {
            var fileName = $"image{id}source.jpg";
            var path = Path.Combine(@"C:\Test\", fileName);

            File.Copy(path, @"C:\Test\temp.jpg", true);

            return @"C:\Test\temp.jpg";
        }
    }
}