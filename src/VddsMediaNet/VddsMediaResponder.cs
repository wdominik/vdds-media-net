using System;
using System.IO;
using VddsMediaNet.Delegate;
using VddsMediaNet.Logger;

namespace VddsMediaNet
{
    public class VddsMediaResponder
    {
        private string[] Arguments { get; set; }

        private VddsMediaConfiguration Configuration { get; set; }

        private IVddsMediaDelegate Delegate { get; set; }

        private IVddsMediaLogger Logger { get; set; }

        private string RegisterCommand { get; set; } = "/register";

        private string UnregisterCommand { get; set; } = "/unregister";


        public VddsMediaResponder()
        {

        }


        public VddsMediaResponder WithArguments(string[] arguments)
        {
            Arguments = arguments ?? throw new ArgumentNullException(nameof(arguments));

            return this;
        }

        public VddsMediaResponder WithConfiguration(VddsMediaConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            return this;
        }

        public VddsMediaResponder WithDelegate(IVddsMediaDelegate vddsMediaDelegate)
        {
            Delegate = vddsMediaDelegate ?? throw new ArgumentNullException(nameof(vddsMediaDelegate));

            return this;
        }

        public VddsMediaResponder WithLogger(IVddsMediaLogger logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));

            return this;
        }

        public VddsMediaResponder WithRegisterCommand(string command)
        {
            RegisterCommand = command ?? throw new ArgumentNullException(nameof(command));

            return this;
        }

        public VddsMediaResponder WithUnregisterCommand(string command)
        {
            UnregisterCommand = command ?? throw new ArgumentNullException(nameof(command));

            return this;
        }

        public void Process()
        {
            if (Arguments == null || Arguments.Length < 1)
            {
                return;
            }

            if (Arguments[0] == RegisterCommand)
            {
                Configuration?.Register();

                return;
            }
            else if (Arguments[0] == UnregisterCommand)
            {
                Configuration?.Unregister();

                return;
            }

            IVddsMediaRequest request = null;

            if (PatientDataImport.IsRequest(Arguments[0]))
            {
                request = new PatientDataImport(Arguments[0]);
            }
            else if (MultimediaInformationExport.IsRequest(Arguments[0]))
            {
                request = new MultimediaInformationExport(Arguments[0]);
            }
            else if (MultimediaExport.IsRequest(Arguments[0]))
            {
                request = new MultimediaExport(Arguments[0]);
            }

            if (request != null)
            {
                LogFileContents(VddsMediaDirection.Incoming, Arguments[0]);

                request.Delegate = Delegate;

                request.Process();
                request.Responde();

                LogFileContents(VddsMediaDirection.Outgoing, Arguments[0]);
            }
        }


        private void LogFileContents(VddsMediaDirection direction, string path)
        {
            if (Logger == null)
            {
                return;
            }

            try
            {
                var contents = File.ReadAllText(path);

                Logger.Log(direction, contents);
            }
            catch
            {

            }
        }
    }
}