using VddsMediaNet.Attributes;

namespace VddsMediaNet
{
    public enum SystemType
    {
        [VddsMediaEnum("BVS")]
        ImageManagementSystem,

        [VddsMediaEnum("PVS")]
        PatientManagementSystem
    }
}