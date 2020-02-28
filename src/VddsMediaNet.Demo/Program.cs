using System;
using System.IO;
using System.Reflection;
using VddsMediaNet.Converters;
using VddsMediaNet.Delegate;
using VddsMediaNet.Logger;

namespace VddsMediaNet.Demo
{
    class Program
    {
        public static void Main(string[] args)
        {   
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            var configuration = new VddsMediaConfiguration
            {
                SectionName = "DEMO_DEMO",
                SystemType = SystemType.ImageManagementSystem,
                Name = "Demo",
                VddsMediaVersion = VddsMediaVersion.VddsMedia14,
                Stages = "134",
                SupportInformation = true,
                PatientDataImportPath = Path.Combine(basePath, "VddsMedia.Demo.exe"),
                PatientDataImportOs = OperationSystem.Windows,
                MultimediaInformationExportPath = Path.Combine(basePath, "VddsMedia.Demo.exe"),
                MultimediaInformationExportOs = OperationSystem.Windows,
                MultimediaExportPath = Path.Combine(basePath, "VddsMedia.Demo.exe"),
                MultimediaExportOs = OperationSystem.Windows
            };

            new VddsMediaResponder()
                .WithArguments(args)
                .WithConfiguration(configuration)
                .WithDelegate(new Delegate())
                .WithLogger(new VddsMediaLogger(Path.Combine(basePath, "VddsMedia.log")))
                .Process();
        }
    }
}