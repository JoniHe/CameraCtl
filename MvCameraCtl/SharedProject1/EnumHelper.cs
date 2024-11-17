using System;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace ShareProject
{

    public static class EnumHelper
    {
        public static string GetDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            if (field == null) return null;

            var attributes = field.GetCustomAttributes(typeof(DisplayNameAttribute), false);

            if (attributes.Length == 0) return null;

            return ((DisplayNameAttribute)attributes[0]).DisplayName;
        }

        public static string GetEnumMemberValue(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            if (field == null) return null;

            var attributes = field.GetCustomAttributes(typeof(EnumMemberAttribute), false);

            if (attributes.Length == 0) return null;

            return ((EnumMemberAttribute)attributes[0]).Value;
        }

        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                  (DescriptionAttribute[])fi.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
    }

    public enum MyColors
    {
        [Description("yuk!")] LightGreen = 0x012020,
        [Description("nice :-)")] VeryDeepPink = 0x123456,
        [Description("so what")] InvisibleGray = 0x456730,
        [Description("no comment")] DeepestRed = 0xfafafa,
        [Description("I give up")] PitchBlack = 0xffffff,
    }
}


// Usage:
/*

public enum MyEnum
{
    [DisplayName("First value")]
    Value1,
    [DisplayName("Second value")]
    Value2,
    [DisplayName("Third value")]
    Value3
}



[DataContract]
public enum MEnum
{
    [EnumMember(Value = "First value")]
    Value1,
    [EnumMember(Value = "Second value")]
    Value2,
    [EnumMember(Value = "Third value")]
    Value3
}




var myEnumValue = MyEnum.Value1;
var value = EnumHelper.GetEnumMemberValue(myEnumValue); // "First value"


var myEnumValue = MEnum.Value1;
var displayName = EnumHelper.GetDisplayName(myEnumValue); // "First value"

var myEnumValue = MyColors.LightGreen;
var displayName = EnumHelper.GetDescription(myEnumValue); // "First value"
*/
