// Marc King - mjking@umich.edu
// Colors by Google - material.google.com/style/color.html

public enum MaterialColor
{
    Red,
    Pink,
    Purple,
    DeepPurple,
    Indigo,
    Blue,
    LightBlue,
    Cyan,
    Teal,
    Green,
    LightGreen,
    Lime,
    Yellow,
    Amber,
    Orange,
    DeepOrange,
    Brown,
    Grey,
    BlueGrey,
    Black,
    White
}

public enum MaterialOpacity
{
    None,
    Full,
    DarkPrimaryText,
    DarkSecondaryText,
    DarkDisabledText,
    DarkHintText,
    DarkIcons,
    DarkDividers,
    LightPrimaryText,
    LightSecondaryText,
    LightDisabledText,
    LightHintText,
    LightIcons,
    LightDividers
}

public static class MaterialColorExtensions
{
    public static string HTMLCode(this MaterialColor color)
    {
        string code;
        switch (color)
        {
            case MaterialColor.Red: code = "#F44336"; break;
            case MaterialColor.Pink: code = "#E91E63"; break;
            case MaterialColor.Purple: code = "#9C27B0"; break;
            case MaterialColor.DeepPurple: code = "#673AB7"; break;
            case MaterialColor.Indigo: code = "#3F51B5"; break;
            case MaterialColor.Blue: code = "#2196F3"; break;
            case MaterialColor.LightBlue: code = "#03A9F4"; break;
            case MaterialColor.Cyan: code = "#00BCD4"; break;
            case MaterialColor.Teal: code = "#009688"; break;
            case MaterialColor.Green: code = "#4CAF50"; break;
            case MaterialColor.LightGreen: code = "#8BC34A"; break;
            case MaterialColor.Lime: code = "#CDDC39"; break;
            case MaterialColor.Yellow: code = "#FFEB3B"; break;
            case MaterialColor.Amber: code = "#FFC107"; break;
            case MaterialColor.Orange: code = "#FF9800"; break;
            case MaterialColor.DeepOrange: code = "#FF5722"; break;
            case MaterialColor.Brown: code = "#795548"; break;
            case MaterialColor.Grey: code = "#9E9E9E"; break;
            case MaterialColor.BlueGrey: code = "#607D8B"; break;
            case MaterialColor.Black: code = "#000000"; break;
            case MaterialColor.White: code = "#FFFFFF"; break;
            default: code = "#FFFFFF"; break;
        }
        return code;
    }
}

public static class MaterialOpacityExtensions
{
    public static string HTMLCode(this MaterialOpacity opacity)
    {
        string code;
        switch (opacity)
        {
            case MaterialOpacity.None: code = "00"; break; // 0%
            case MaterialOpacity.Full: code = "FF"; break; // 100%
            case MaterialOpacity.DarkPrimaryText: code = "DE"; break; // 87%
            case MaterialOpacity.DarkSecondaryText: code = "8A"; break; // 54%
            case MaterialOpacity.DarkDisabledText: code = "61"; break; // 38%
            case MaterialOpacity.DarkHintText: code = "61"; break; // 38%
            case MaterialOpacity.DarkIcons: code = "61"; break; // 38%
            case MaterialOpacity.DarkDividers: code = "1F"; break; // 12%
            case MaterialOpacity.LightPrimaryText: code = "FF"; break; // 100%
            case MaterialOpacity.LightSecondaryText: code = "B3"; break; // 70%
            case MaterialOpacity.LightDisabledText: code = "80"; break; // 50%
            case MaterialOpacity.LightHintText: code = "80"; break; // 50%
            case MaterialOpacity.LightIcons: code = "80"; break; // 50%
            case MaterialOpacity.LightDividers: code = "1F"; break; // 12%
            default: code = "FF"; break; // 100%
        }
        return code;
    }
}

public enum MaterialColorAdvanced
{
    #region Reds
    Red050,
    Red100,
    Red200,
    Red300,
    Red400,
    Red500,
    Red600,
    Red700,
    Red800,
    Red900,
    RedA100,
    RedA200,
    RedA400,
    RedA700,
    #endregion Reds

    #region Pinks
    Pink050,
    Pink100,
    Pink200,
    Pink300,
    Pink400,
    Pink500,
    Pink600,
    Pink700,
    Pink800,
    Pink900,
    PinkA100,
    PinkA200,
    PinkA400,
    PinkA700,
    #endregion Pinks

    #region Purples
    Purple050,
    Purple100,
    Purple200,
    Purple300,
    Purple400,
    Purple500,
    Purple600,
    Purple700,
    Purple800,
    Purple900,
    PurpleA100,
    PurpleA200,
    PurpleA400,
    PurpleA700,
    #endregion Purples

    #region Deep Purples
    DeepPurple050,
    DeepPurple100,
    DeepPurple200,
    DeepPurple300,
    DeepPurple400,
    DeepPurple500,
    DeepPurple600,
    DeepPurple700,
    DeepPurple800,
    DeepPurple900,
    DeepPurpleA100,
    DeepPurpleA200,
    DeepPurpleA400,
    DeepPurpleA700,
    #endregion Deep Purples

    #region Indigos
    Indigo050,
    Indigo100,
    Indigo200,
    Indigo300,
    Indigo400,
    Indigo500,
    Indigo600,
    Indigo700,
    Indigo800,
    Indigo900,
    IndigoA100,
    IndigoA200,
    IndigoA400,
    IndigoA700,
    #endregion Indigos

    #region Blues
    Blue050,
    Blue100,
    Blue200,
    Blue300,
    Blue400,
    Blue500,
    Blue600,
    Blue700,
    Blue800,
    Blue900,
    BlueA100,
    BlueA200,
    BlueA400,
    BlueA700,
    #endregion Blues

    #region Light Blues
    LightBlue050,
    LightBlue100,
    LightBlue200,
    LightBlue300,
    LightBlue400,
    LightBlue500,
    LightBlue600,
    LightBlue700,
    LightBlue800,
    LightBlue900,
    LightBlueA100,
    LightBlueA200,
    LightBlueA400,
    LightBlueA700,
    #endregion Light Blues

    #region Cyans
    Cyan050,
    Cyan100,
    Cyan200,
    Cyan300,
    Cyan400,
    Cyan500,
    Cyan600,
    Cyan700,
    Cyan800,
    Cyan900,
    CyanA100,
    CyanA200,
    CyanA400,
    CyanA700,
    #endregion Cyans

    #region Teals
    Teal050,
    Teal100,
    Teal200,
    Teal300,
    Teal400,
    Teal500,
    Teal600,
    Teal700,
    Teal800,
    Teal900,
    TealA100,
    TealA200,
    TealA400,
    TealA700,
    #endregion Teals

    #region Greens
    Green050,
    Green100,
    Green200,
    Green300,
    Green400,
    Green500,
    Green600,
    Green700,
    Green800,
    Green900,
    GreenA100,
    GreenA200,
    GreenA400,
    GreenA700,
    #endregion Greens

    #region Light Greens
    LightGreen050,
    LightGreen100,
    LightGreen200,
    LightGreen300,
    LightGreen400,
    LightGreen500,
    LightGreen600,
    LightGreen700,
    LightGreen800,
    LightGreen900,
    LightGreenA100,
    LightGreenA200,
    LightGreenA400,
    LightGreenA700,
    #endregion Light Greens

    #region Limes
    Lime050,
    Lime100,
    Lime200,
    Lime300,
    Lime400,
    Lime500,
    Lime600,
    Lime700,
    Lime800,
    Lime900,
    LimeA100,
    LimeA200,
    LimeA400,
    LimeA700,
    #endregion Limes

    #region Yellows
    Yellow050,
    Yellow100,
    Yellow200,
    Yellow300,
    Yellow400,
    Yellow500,
    Yellow600,
    Yellow700,
    Yellow800,
    Yellow900,
    YellowA100,
    YellowA200,
    YellowA400,
    YellowA700,
    #endregion Yellows

    #region Ambers
    Amber050,
    Amber100,
    Amber200,
    Amber300,
    Amber400,
    Amber500,
    Amber600,
    Amber700,
    Amber800,
    Amber900,
    AmberA100,
    AmberA200,
    AmberA400,
    AmberA700,
    #endregion Ambers

    #region Oranges
    Orange050,
    Orange100,
    Orange200,
    Orange300,
    Orange400,
    Orange500,
    Orange600,
    Orange700,
    Orange800,
    Orange900,
    OrangeA100,
    OrangeA200,
    OrangeA400,
    OrangeA700,
    #endregion Oranges

    #region Deep Oranges
    DeepOrange050,
    DeepOrange100,
    DeepOrange200,
    DeepOrange300,
    DeepOrange400,
    DeepOrange500,
    DeepOrange600,
    DeepOrange700,
    DeepOrange800,
    DeepOrange900,
    DeepOrangeA100,
    DeepOrangeA200,
    DeepOrangeA400,
    DeepOrangeA700,
    #endregion Deep Oranges

    #region Browns
    Brown050,
    Brown100,
    Brown200,
    Brown300,
    Brown400,
    Brown500,
    Brown600,
    Brown700,
    Brown800,
    Brown900,
    #endregion Browns

    #region Greys
    Grey050,
    Grey100,
    Grey200,
    Grey300,
    Grey400,
    Grey500,
    Grey600,
    Grey700,
    Grey800,
    Grey900,
    #endregion Greys

    #region Blue Greys
    BlueGrey050,
    BlueGrey100,
    BlueGrey200,
    BlueGrey300,
    BlueGrey400,
    BlueGrey500,
    BlueGrey600,
    BlueGrey700,
    BlueGrey800,
    BlueGrey900
    #endregion Blue Greys
}

public static class MaterialColorAdvancedExtensions
{
    public static string HTMLCode(this MaterialColorAdvanced color)
    {
        string code;
        switch (color)
        {
            #region Reds
            case MaterialColorAdvanced.Red050: code = "#FFEBEE"; break;
            case MaterialColorAdvanced.Red100: code = "#FFCDD2"; break;
            case MaterialColorAdvanced.Red200: code = "#EF9A9A"; break;
            case MaterialColorAdvanced.Red300: code = "#E57373"; break;
            case MaterialColorAdvanced.Red400: code = "#EF5350"; break;
            case MaterialColorAdvanced.Red500: code = "#F44336"; break;
            case MaterialColorAdvanced.Red600: code = "#E53935"; break;
            case MaterialColorAdvanced.Red700: code = "#D32F2F"; break;
            case MaterialColorAdvanced.Red800: code = "#C62828"; break;
            case MaterialColorAdvanced.Red900: code = "#B71C1C"; break;
            case MaterialColorAdvanced.RedA100: code = "#FF8A80"; break;
            case MaterialColorAdvanced.RedA200: code = "#FF5252"; break;
            case MaterialColorAdvanced.RedA400: code = "#FF1744"; break;
            case MaterialColorAdvanced.RedA700: code = "#D50000"; break;
            #endregion Reds

            #region Pinks
            case MaterialColorAdvanced.Pink050: code = "#FCE4EC"; break;
            case MaterialColorAdvanced.Pink100: code = "#F8BBD0"; break;
            case MaterialColorAdvanced.Pink200: code = "#F48FB1"; break;
            case MaterialColorAdvanced.Pink300: code = "#F06292"; break;
            case MaterialColorAdvanced.Pink400: code = "#EC407A"; break;
            case MaterialColorAdvanced.Pink500: code = "#E91E63"; break;
            case MaterialColorAdvanced.Pink600: code = "#D81B60"; break;
            case MaterialColorAdvanced.Pink700: code = "#C2185B"; break;
            case MaterialColorAdvanced.Pink800: code = "#AD1457"; break;
            case MaterialColorAdvanced.Pink900: code = "#880E4F"; break;
            case MaterialColorAdvanced.PinkA100: code = "#FF80AB"; break;
            case MaterialColorAdvanced.PinkA200: code = "#FF4081"; break;
            case MaterialColorAdvanced.PinkA400: code = "#F50057"; break;
            case MaterialColorAdvanced.PinkA700: code = "#C51162"; break;
            #endregion Pinks

            #region Purples
            case MaterialColorAdvanced.Purple050: code = "#F3E5F5"; break;
            case MaterialColorAdvanced.Purple100: code = "#E1BEE7"; break;
            case MaterialColorAdvanced.Purple200: code = "#CE93D8"; break;
            case MaterialColorAdvanced.Purple300: code = "#BA68C8"; break;
            case MaterialColorAdvanced.Purple400: code = "#AB47BC"; break;
            case MaterialColorAdvanced.Purple500: code = "#9C27B0"; break;
            case MaterialColorAdvanced.Purple600: code = "#8E24AA"; break;
            case MaterialColorAdvanced.Purple700: code = "#7B1FA2"; break;
            case MaterialColorAdvanced.Purple800: code = "#6A1B9A"; break;
            case MaterialColorAdvanced.Purple900: code = "#4A148C"; break;
            case MaterialColorAdvanced.PurpleA100: code = "#EA80FC"; break;
            case MaterialColorAdvanced.PurpleA200: code = "#E040FB"; break;
            case MaterialColorAdvanced.PurpleA400: code = "#D500F9"; break;
            case MaterialColorAdvanced.PurpleA700: code = "#AA00FF"; break;
            #endregion Purples

            #region Deep Purples
            case MaterialColorAdvanced.DeepPurple050: code = "#EDE7F6"; break;
            case MaterialColorAdvanced.DeepPurple100: code = "#D1C4E9"; break;
            case MaterialColorAdvanced.DeepPurple200: code = "#B39DDB"; break;
            case MaterialColorAdvanced.DeepPurple300: code = "#9575CD"; break;
            case MaterialColorAdvanced.DeepPurple400: code = "#7E57C2"; break;
            case MaterialColorAdvanced.DeepPurple500: code = "#673AB7"; break;
            case MaterialColorAdvanced.DeepPurple600: code = "#5E35B1"; break;
            case MaterialColorAdvanced.DeepPurple700: code = "#512DA8"; break;
            case MaterialColorAdvanced.DeepPurple800: code = "#4527A0"; break;
            case MaterialColorAdvanced.DeepPurple900: code = "#311B92"; break;
            case MaterialColorAdvanced.DeepPurpleA100: code = "#B388FF"; break;
            case MaterialColorAdvanced.DeepPurpleA200: code = "#7C4DFF"; break;
            case MaterialColorAdvanced.DeepPurpleA400: code = "#651FFF"; break;
            case MaterialColorAdvanced.DeepPurpleA700: code = "#6200EA"; break;
            #endregion Deep Purples

            #region Indigos
            case MaterialColorAdvanced.Indigo050: code = "#E8EAF6"; break;
            case MaterialColorAdvanced.Indigo100: code = "#C5CAE9"; break;
            case MaterialColorAdvanced.Indigo200: code = "#9FA8DA"; break;
            case MaterialColorAdvanced.Indigo300: code = "#7986CB"; break;
            case MaterialColorAdvanced.Indigo400: code = "#5C6BC0"; break;
            case MaterialColorAdvanced.Indigo500: code = "#3F51B5"; break;
            case MaterialColorAdvanced.Indigo600: code = "#3949AB"; break;
            case MaterialColorAdvanced.Indigo700: code = "#303F9F"; break;
            case MaterialColorAdvanced.Indigo800: code = "#283593"; break;
            case MaterialColorAdvanced.Indigo900: code = "#1A237E"; break;
            case MaterialColorAdvanced.IndigoA100: code = "#8C9EFF"; break;
            case MaterialColorAdvanced.IndigoA200: code = "#536DFE"; break;
            case MaterialColorAdvanced.IndigoA400: code = "#3D5AFE"; break;
            case MaterialColorAdvanced.IndigoA700: code = "#304FFE"; break;
            #endregion Indigos

            #region Blues
            case MaterialColorAdvanced.Blue050: code = "#E3F2FD"; break;
            case MaterialColorAdvanced.Blue100: code = "#BBDEFB"; break;
            case MaterialColorAdvanced.Blue200: code = "#90CAF9"; break;
            case MaterialColorAdvanced.Blue300: code = "#64B5F6"; break;
            case MaterialColorAdvanced.Blue400: code = "#42A5F5"; break;
            case MaterialColorAdvanced.Blue500: code = "#2196F3"; break;
            case MaterialColorAdvanced.Blue600: code = "#1E88E5"; break;
            case MaterialColorAdvanced.Blue700: code = "#1976D2"; break;
            case MaterialColorAdvanced.Blue800: code = "#1565C0"; break;
            case MaterialColorAdvanced.Blue900: code = "#0D47A1"; break;
            case MaterialColorAdvanced.BlueA100: code = "#82B1FF"; break;
            case MaterialColorAdvanced.BlueA200: code = "#448AFF"; break;
            case MaterialColorAdvanced.BlueA400: code = "#2979FF"; break;
            case MaterialColorAdvanced.BlueA700: code = "#2962FF"; break;
            #endregion Blues

            #region Light Blues
            case MaterialColorAdvanced.LightBlue050: code = "#E1F5FE"; break;
            case MaterialColorAdvanced.LightBlue100: code = "#B3E5FC"; break;
            case MaterialColorAdvanced.LightBlue200: code = "#81D4FA"; break;
            case MaterialColorAdvanced.LightBlue300: code = "#4FC3F7"; break;
            case MaterialColorAdvanced.LightBlue400: code = "#29B6F6"; break;
            case MaterialColorAdvanced.LightBlue500: code = "#03A9F4"; break;
            case MaterialColorAdvanced.LightBlue600: code = "#039BE5"; break;
            case MaterialColorAdvanced.LightBlue700: code = "#0288D1"; break;
            case MaterialColorAdvanced.LightBlue800: code = "#0277BD"; break;
            case MaterialColorAdvanced.LightBlue900: code = "#01579B"; break;
            case MaterialColorAdvanced.LightBlueA100: code = "#80D8FF"; break;
            case MaterialColorAdvanced.LightBlueA200: code = "#40C4FF"; break;
            case MaterialColorAdvanced.LightBlueA400: code = "#00B0FF"; break;
            case MaterialColorAdvanced.LightBlueA700: code = "#0091EA"; break;
            #endregion Light Blues

            #region Cyans
            case MaterialColorAdvanced.Cyan050: code = "#E0F7FA"; break;
            case MaterialColorAdvanced.Cyan100: code = "#B2EBF2"; break;
            case MaterialColorAdvanced.Cyan200: code = "#80DEEA"; break;
            case MaterialColorAdvanced.Cyan300: code = "#4DD0E1"; break;
            case MaterialColorAdvanced.Cyan400: code = "#26C6DA"; break;
            case MaterialColorAdvanced.Cyan500: code = "#00BCD4"; break;
            case MaterialColorAdvanced.Cyan600: code = "#00ACC1"; break;
            case MaterialColorAdvanced.Cyan700: code = "#0097A7"; break;
            case MaterialColorAdvanced.Cyan800: code = "#00838F"; break;
            case MaterialColorAdvanced.Cyan900: code = "#006064"; break;
            case MaterialColorAdvanced.CyanA100: code = "#84FFFF"; break;
            case MaterialColorAdvanced.CyanA200: code = "#18FFFF"; break;
            case MaterialColorAdvanced.CyanA400: code = "#00E5FF"; break;
            case MaterialColorAdvanced.CyanA700: code = "#00B8D4"; break;
            #endregion Cyans

            #region Teals
            case MaterialColorAdvanced.Teal050: code = "#E0F2F1"; break;
            case MaterialColorAdvanced.Teal100: code = "#B2DFDB"; break;
            case MaterialColorAdvanced.Teal200: code = "#80CBC4"; break;
            case MaterialColorAdvanced.Teal300: code = "#4DB6AC"; break;
            case MaterialColorAdvanced.Teal400: code = "#26A69A"; break;
            case MaterialColorAdvanced.Teal500: code = "#009688"; break;
            case MaterialColorAdvanced.Teal600: code = "#00897B"; break;
            case MaterialColorAdvanced.Teal700: code = "#00796B"; break;
            case MaterialColorAdvanced.Teal800: code = "#00695C"; break;
            case MaterialColorAdvanced.Teal900: code = "#004D40"; break;
            case MaterialColorAdvanced.TealA100: code = "#A7FFEB"; break;
            case MaterialColorAdvanced.TealA200: code = "#64FFDA"; break;
            case MaterialColorAdvanced.TealA400: code = "#1DE9B6"; break;
            case MaterialColorAdvanced.TealA700: code = "#00BFA5"; break;
            #endregion Teals

            #region Greens
            case MaterialColorAdvanced.Green050: code = "#E8F5E9"; break;
            case MaterialColorAdvanced.Green100: code = "#C8E6C9"; break;
            case MaterialColorAdvanced.Green200: code = "#A5D6A7"; break;
            case MaterialColorAdvanced.Green300: code = "#81C784"; break;
            case MaterialColorAdvanced.Green400: code = "#66BB6A"; break;
            case MaterialColorAdvanced.Green500: code = "#4CAF50"; break;
            case MaterialColorAdvanced.Green600: code = "#43A047"; break;
            case MaterialColorAdvanced.Green700: code = "#388E3C"; break;
            case MaterialColorAdvanced.Green800: code = "#2E7D32"; break;
            case MaterialColorAdvanced.Green900: code = "#1B5E20"; break;
            case MaterialColorAdvanced.GreenA100: code = "#B9F6CA"; break;
            case MaterialColorAdvanced.GreenA200: code = "#69F0AE"; break;
            case MaterialColorAdvanced.GreenA400: code = "#00E676"; break;
            case MaterialColorAdvanced.GreenA700: code = "#00C853"; break;
            #endregion Greens

            #region Light Greens
            case MaterialColorAdvanced.LightGreen050: code = "#F1F8E9"; break;
            case MaterialColorAdvanced.LightGreen100: code = "#DCEDC8"; break;
            case MaterialColorAdvanced.LightGreen200: code = "#C5E1A5"; break;
            case MaterialColorAdvanced.LightGreen300: code = "#AED581"; break;
            case MaterialColorAdvanced.LightGreen400: code = "#9CCC65"; break;
            case MaterialColorAdvanced.LightGreen500: code = "#8BC34A"; break;
            case MaterialColorAdvanced.LightGreen600: code = "#7CB342"; break;
            case MaterialColorAdvanced.LightGreen700: code = "#689F38"; break;
            case MaterialColorAdvanced.LightGreen800: code = "#558B2F"; break;
            case MaterialColorAdvanced.LightGreen900: code = "#33691E"; break;
            case MaterialColorAdvanced.LightGreenA100: code = "#CCFF90"; break;
            case MaterialColorAdvanced.LightGreenA200: code = "#B2FF59"; break;
            case MaterialColorAdvanced.LightGreenA400: code = "#76FF03"; break;
            case MaterialColorAdvanced.LightGreenA700: code = "#64DD17"; break;
            #endregion Light Greens

            #region Limes
            case MaterialColorAdvanced.Lime050: code = "#F9FBE7"; break;
            case MaterialColorAdvanced.Lime100: code = "#F0F4C3"; break;
            case MaterialColorAdvanced.Lime200: code = "#E6EE9C"; break;
            case MaterialColorAdvanced.Lime300: code = "#DCE775"; break;
            case MaterialColorAdvanced.Lime400: code = "#D4E157"; break;
            case MaterialColorAdvanced.Lime500: code = "#CDDC39"; break;
            case MaterialColorAdvanced.Lime600: code = "#C0CA33"; break;
            case MaterialColorAdvanced.Lime700: code = "#AFB42B"; break;
            case MaterialColorAdvanced.Lime800: code = "#9E9D24"; break;
            case MaterialColorAdvanced.Lime900: code = "#827717"; break;
            case MaterialColorAdvanced.LimeA100: code = "#F4FF81"; break;
            case MaterialColorAdvanced.LimeA200: code = "#EEFF41"; break;
            case MaterialColorAdvanced.LimeA400: code = "#C6FF00"; break;
            case MaterialColorAdvanced.LimeA700: code = "#AEEA00"; break;
            #endregion Limes

            #region Yellows
            case MaterialColorAdvanced.Yellow050: code = "#FFFDE7"; break;
            case MaterialColorAdvanced.Yellow100: code = "#FFF9C4"; break;
            case MaterialColorAdvanced.Yellow200: code = "#FFF59D"; break;
            case MaterialColorAdvanced.Yellow300: code = "#FFF176"; break;
            case MaterialColorAdvanced.Yellow400: code = "#FFEE58"; break;
            case MaterialColorAdvanced.Yellow500: code = "#FFEB3B"; break;
            case MaterialColorAdvanced.Yellow600: code = "#FDD835"; break;
            case MaterialColorAdvanced.Yellow700: code = "#FBC02D"; break;
            case MaterialColorAdvanced.Yellow800: code = "#F9A825"; break;
            case MaterialColorAdvanced.Yellow900: code = "#F57F17"; break;
            case MaterialColorAdvanced.YellowA100: code = "#FFFF8D"; break;
            case MaterialColorAdvanced.YellowA200: code = "#FFFF00"; break;
            case MaterialColorAdvanced.YellowA400: code = "#FFEA00"; break;
            case MaterialColorAdvanced.YellowA700: code = "#FFD600"; break;
            #endregion Yellows

            #region Ambers
            case MaterialColorAdvanced.Amber050: code = "#FFF8E1"; break;
            case MaterialColorAdvanced.Amber100: code = "#FFECB3"; break;
            case MaterialColorAdvanced.Amber200: code = "#FFE082"; break;
            case MaterialColorAdvanced.Amber300: code = "#FFD54F"; break;
            case MaterialColorAdvanced.Amber400: code = "#FFCA28"; break;
            case MaterialColorAdvanced.Amber500: code = "#FFC107"; break;
            case MaterialColorAdvanced.Amber600: code = "#FFB300"; break;
            case MaterialColorAdvanced.Amber700: code = "#FFA000"; break;
            case MaterialColorAdvanced.Amber800: code = "#FF8F00"; break;
            case MaterialColorAdvanced.Amber900: code = "#FF6F00"; break;
            case MaterialColorAdvanced.AmberA100: code = "#FFE57F"; break;
            case MaterialColorAdvanced.AmberA200: code = "#FFD740"; break;
            case MaterialColorAdvanced.AmberA400: code = "#FFC400"; break;
            case MaterialColorAdvanced.AmberA700: code = "#FFAB00"; break;
            #endregion Ambers

            #region Oranges
            case MaterialColorAdvanced.Orange050: code = "#FFF3E0"; break;
            case MaterialColorAdvanced.Orange100: code = "#FFE0B2"; break;
            case MaterialColorAdvanced.Orange200: code = "#FFCC80"; break;
            case MaterialColorAdvanced.Orange300: code = "#FFB74D"; break;
            case MaterialColorAdvanced.Orange400: code = "#FFA726"; break;
            case MaterialColorAdvanced.Orange500: code = "#FF9800"; break;
            case MaterialColorAdvanced.Orange600: code = "#FB8C00"; break;
            case MaterialColorAdvanced.Orange700: code = "#F57C00"; break;
            case MaterialColorAdvanced.Orange800: code = "#EF6C00"; break;
            case MaterialColorAdvanced.Orange900: code = "#E65100"; break;
            case MaterialColorAdvanced.OrangeA100: code = "#FFD180"; break;
            case MaterialColorAdvanced.OrangeA200: code = "#FFAB40"; break;
            case MaterialColorAdvanced.OrangeA400: code = "#FF9100"; break;
            case MaterialColorAdvanced.OrangeA700: code = "#FF6D00"; break;
            #endregion Oranges

            #region Deep Oranges
            case MaterialColorAdvanced.DeepOrange050: code = "#FBE9E7"; break;
            case MaterialColorAdvanced.DeepOrange100: code = "#FFCCBC"; break;
            case MaterialColorAdvanced.DeepOrange200: code = "#FFAB91"; break;
            case MaterialColorAdvanced.DeepOrange300: code = "#FF8A65"; break;
            case MaterialColorAdvanced.DeepOrange400: code = "#FF7043"; break;
            case MaterialColorAdvanced.DeepOrange500: code = "#FF5722"; break;
            case MaterialColorAdvanced.DeepOrange600: code = "#F4511E"; break;
            case MaterialColorAdvanced.DeepOrange700: code = "#E64A19"; break;
            case MaterialColorAdvanced.DeepOrange800: code = "#D84315"; break;
            case MaterialColorAdvanced.DeepOrange900: code = "#BF360C"; break;
            case MaterialColorAdvanced.DeepOrangeA100: code = "#FF9E80"; break;
            case MaterialColorAdvanced.DeepOrangeA200: code = "#FF6E40"; break;
            case MaterialColorAdvanced.DeepOrangeA400: code = "#FF3D00"; break;
            case MaterialColorAdvanced.DeepOrangeA700: code = "#DD2C00"; break;
            #endregion Deep Oranges

            #region Browns
            case MaterialColorAdvanced.Brown050: code = "#EFEBE9"; break;
            case MaterialColorAdvanced.Brown100: code = "#D7CCC8"; break;
            case MaterialColorAdvanced.Brown200: code = "#BCAAA4"; break;
            case MaterialColorAdvanced.Brown300: code = "#A1887F"; break;
            case MaterialColorAdvanced.Brown400: code = "#8D6E63"; break;
            case MaterialColorAdvanced.Brown500: code = "#795548"; break;
            case MaterialColorAdvanced.Brown600: code = "#6D4C41"; break;
            case MaterialColorAdvanced.Brown700: code = "#5D4037"; break;
            case MaterialColorAdvanced.Brown800: code = "#4E342E"; break;
            case MaterialColorAdvanced.Brown900: code = "#3E2723"; break;
            #endregion Browns

            #region Greys
            case MaterialColorAdvanced.Grey050: code = "#FAFAFA"; break;
            case MaterialColorAdvanced.Grey100: code = "#F5F5F5"; break;
            case MaterialColorAdvanced.Grey200: code = "#EEEEEE"; break;
            case MaterialColorAdvanced.Grey300: code = "#E0E0E0"; break;
            case MaterialColorAdvanced.Grey400: code = "#BDBDBD"; break;
            case MaterialColorAdvanced.Grey500: code = "#9E9E9E"; break;
            case MaterialColorAdvanced.Grey600: code = "#757575"; break;
            case MaterialColorAdvanced.Grey700: code = "#616161"; break;
            case MaterialColorAdvanced.Grey800: code = "#424242"; break;
            case MaterialColorAdvanced.Grey900: code = "#212121"; break;
            #endregion Greys

            #region Blue Greys
            case MaterialColorAdvanced.BlueGrey050: code = "#ECEFF1"; break;
            case MaterialColorAdvanced.BlueGrey100: code = "#CFD8DC"; break;
            case MaterialColorAdvanced.BlueGrey200: code = "#B0BEC5"; break;
            case MaterialColorAdvanced.BlueGrey300: code = "#90A4AE"; break;
            case MaterialColorAdvanced.BlueGrey400: code = "#78909C"; break;
            case MaterialColorAdvanced.BlueGrey500: code = "#607D8B"; break;
            case MaterialColorAdvanced.BlueGrey600: code = "#546E7A"; break;
            case MaterialColorAdvanced.BlueGrey700: code = "#455A64"; break;
            case MaterialColorAdvanced.BlueGrey800: code = "#37474F"; break;
            case MaterialColorAdvanced.BlueGrey900: code = "#263238"; break;
            #endregion Blue Greys

            default: code = "#FFFFFF"; break;
        }
        return code;
    }
}
