using System.ComponentModel;

namespace Urania.Core.Data {

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum InchName {
        [Description(" ")]
        Unknown = 0,
        [Description("1/32″")]
        OneThirtySecond,
        [Description("1/16″")]
        OneSixteenth,
        [Description("3/32″")]
        ThreeThirtySecond,
        [Description("1/8″")]
        OneEighth,
        [Description("5/32″")]
        FiveThirtySecond,
        [Description("3/16″")]
        ThreeSixteenth,
        [Description("7/32″")]
        SevenThirtySecond,
        [Description("1/4″")]
        OneFourth,
        [Description("9/32″")]
        NineThirtySecond,
        [Description("5/16″")]
        FiveSixteenth,
        [Description("11/32″")]
        ElevenThirtySecond,
        [Description("3/8″")]
        ThreeEighth,
        [Description("13/32″")]
        ThirteenThirtySecond,
        [Description("7/16″")]
        SevenSixteenth,
        [Description("15/32″")]
        FifteenThirtySecond,
        [Description("1/2″")]
        OneHalf,
        [Description("17/32″")]
        SeventeenThirtySecond,
        [Description("9/16″")]
        NineSixteenth,
        [Description("19/32″")]
        NineteenThirtySecond,
        [Description("5/8″")]
        FiveEighth,
        [Description("21/32″")]
        TwentyOneThirtySecond,
        [Description("11/16″")]
        ElevenSixteenth,
        [Description("23/32″")]
        TwentyThreeThirtySecond,
        [Description("3/4″")]
        ThreeFourth,
        [Description("25/32″")]
        TwentyFiveThirtySecond,
        [Description("13/16″")]
        ThirteenSixteenth,
        [Description("27/32″")]
        TwentySevenThirtySecond,
        [Description("7/8″")]
        SevenEighth,
        [Description("29/32″")]
        TwentyNineThirtySecond,
        [Description("15/16″")]
        FifteenSixteenth,
        [Description("31/32″")]
        ThirtyOneThirtySecond,
        [Description("1″")]
        One
    }
}