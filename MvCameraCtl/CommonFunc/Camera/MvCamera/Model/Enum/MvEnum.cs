using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CommonFunc.Camera.MvCamera.Model.Enum
{
    public enum ImageFormat
    {
        [Description("Mono8")]
        Mono8 = 0x01080001,
        [Description("Mono10")]
        Mono10 = 0x01100003,
    }

    public enum AcquisitionMode
    {
        [Description("SingleFrame")]
        SingleFrame = 0,
        [Description("Continuous")]
        Continuous = 2,
    }

    public enum TriggerSource
    {
        [Description("Line0")]
        Line0 = 0,
        [Description("Line2")]
        Line2 = 2,
        [Description("Counter0")]
        Counter0 = 4,
        [Description("Software")]
        Software = 7,
        [Description("Action1")]
        Action1 = 9,
        [Description("Anyway")]
        Anyway = 13,
    }

    public enum TriggerMode
    {
        [Description("Off")]
        Off = 0,
        [Description("On")]
        On = 1,
    }

    public enum TriggerActivation
    {
        /// <summary>
        /// 上升沿触发
        /// </summary>
        [Description("RisingEdge")]
        RisingEdge = 0,
        /// <summary>
        /// 下降沿触发
        /// </summary>
        [Description("FallingEdge")]
        FallingEdge = 1,
        /// <summary>
        /// 高电平触发
        /// </summary>
        [Description("LevelHigh")]
        LevelHigh = 0,
        /// <summary>
        /// 低电平触发
        /// </summary>
        [Description("LevelLow")]
        LevelLow = 1,
    }

    public enum ExposureAuto
    {
        [Description("Off")]
        Off = 0,
        [Description("Once")]
        Once = 1,
        [Description("Continuous")]
        Continuous = 1,
    }
}