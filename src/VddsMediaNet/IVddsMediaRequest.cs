using VddsMediaNet.Delegate;

namespace VddsMediaNet
{
    public interface IVddsMediaRequest
    {
        IVddsMediaDelegate Delegate { get; set; }


        void Process();

        void Responde();
    }
}