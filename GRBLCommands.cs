using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RevopointScanAutomation
{
    public enum GrblSystemCommand
    {
        [System.ComponentModel.Description("$X")]
        SoftReset,

        [System.ComponentModel.Description("?")]
        StatusReport,

        [System.ComponentModel.Description("!")]
        FeedHold,

        [System.ComponentModel.Description("~")]
        Resume,

        [System.ComponentModel.Description("!")]
    
        CycleStart,
        
        [System.ComponentModel.Description("$C")]
        SafetyDoor,

        [System.ComponentModel.Description("\x85")]
        JogCancel,

        [System.ComponentModel.Description("%")]
        FeedOverrideIncrease,

        [System.ComponentModel.Description("!")]
        FeedOverrideDecrease,

        [System.ComponentModel.Description(">")]
        RapidOverrideIncrease,

        [System.ComponentModel.Description("<")]
        RapidOverrideDecrease,

        [System.ComponentModel.Description("S")]
        SpindleSpeedIncrease,

        [System.ComponentModel.Description("R")]
        SpindleSpeedDecrease,

        [System.ComponentModel.Description("M5")]
        SpindleStop,

        [System.ComponentModel.Description("M8")]
        CoolantFloodOn,

        [System.ComponentModel.Description("M9")]
        CoolantFloodOff,

        [System.ComponentModel.Description("M7")]
        CoolantMistOn,

        [System.ComponentModel.Description("M9")]
        CoolantMistOff,

        [System.ComponentModel.Description("M6")]
        ToolChange,

        [System.ComponentModel.Description("$P")]
        Parking,

        [System.ComponentModel.Description("$H")]
        HomingCycle,

        [System.ComponentModel.Description("$X")]
        ResetAlarm,

        [System.ComponentModel.Description("$C")]
        CheckGCodeMode,

        [System.ComponentModel.Description("$X")]
        KillAlarmLock,

        [System.ComponentModel.Description("$21")]
        SoftwareLimitsOn,

        [System.ComponentModel.Description("$20")]
        SoftwareLimitsOff,

        [System.ComponentModel.Description("$X")]
        UnlockEEPROM,

        [System.ComponentModel.Description("$RST=$")]
        RestoreDefaults,

        [System.ComponentModel.Description("$")]
        Help,

        [System.ComponentModel.Description("$$")]
        Settings,

        [System.ComponentModel.Description("$I")]
        BuildInfo,

    }

    public static class EnumHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);

            MemberInfo member = type.GetMember(name)[0];
            DescriptionAttribute attribute = member.GetCustomAttribute<DescriptionAttribute>();

            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}
