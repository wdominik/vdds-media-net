namespace VddsMediaNet.Logger
{
    public interface IVddsMediaLogger
    {
        void Log(VddsMediaDirection direction, string data);
    }
}