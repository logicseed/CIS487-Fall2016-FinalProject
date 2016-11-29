// Marc King - mjking@umich.edu
// Colors by Google - material.google.com/style/color.html

public enum ConsoleMaterialColor
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

public enum ConsoleMaterialOpacity
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

public static class ConsoleMaterialColorExtensions
{
    public static string HTMLCode(this ConsoleMaterialColor color)
    {
        string code;
        switch (color)
        {
            case ConsoleMaterialColor.Red: code = "#F44336"; break;
            case ConsoleMaterialColor.Pink: code = "#E91E63"; break;
            case ConsoleMaterialColor.Purple: code = "#9C27B0"; break;
            case ConsoleMaterialColor.DeepPurple: code = "#673AB7"; break;
            case ConsoleMaterialColor.Indigo: code = "#3F51B5"; break;
            case ConsoleMaterialColor.Blue: code = "#2196F3"; break;
            case ConsoleMaterialColor.LightBlue: code = "#03A9F4"; break;
            case ConsoleMaterialColor.Cyan: code = "#00BCD4"; break;
            case ConsoleMaterialColor.Teal: code = "#009688"; break;
            case ConsoleMaterialColor.Green: code = "#4CAF50"; break;
            case ConsoleMaterialColor.LightGreen: code = "#8BC34A"; break;
            case ConsoleMaterialColor.Lime: code = "#CDDC39"; break;
            case ConsoleMaterialColor.Yellow: code = "#FFEB3B"; break;
            case ConsoleMaterialColor.Amber: code = "#FFC107"; break;
            case ConsoleMaterialColor.Orange: code = "#FF9800"; break;
            case ConsoleMaterialColor.DeepOrange: code = "#FF5722"; break;
            case ConsoleMaterialColor.Brown: code = "#795548"; break;
            case ConsoleMaterialColor.Grey: code = "#9E9E9E"; break;
            case ConsoleMaterialColor.BlueGrey: code = "#607D8B"; break;
            case ConsoleMaterialColor.Black: code = "#000000"; break;
            case ConsoleMaterialColor.White: code = "#FFFFFF"; break;
            default: code = "#FFFFFF"; break;
        }
        return code;
    }
}

public static class ConsoleMaterialOpacityExtensions
{
    public static string HTMLCode(this ConsoleMaterialOpacity opacity)
    {
        string code;
        switch (opacity)
        {
            case ConsoleMaterialOpacity.None: code = "00"; break; // 0%
            case ConsoleMaterialOpacity.Full: code = "FF"; break; // 100%
            case ConsoleMaterialOpacity.DarkPrimaryText: code = "DE"; break; // 87%
            case ConsoleMaterialOpacity.DarkSecondaryText: code = "8A"; break; // 54%
            case ConsoleMaterialOpacity.DarkDisabledText: code = "61"; break; // 38%
            case ConsoleMaterialOpacity.DarkHintText: code = "61"; break; // 38%
            case ConsoleMaterialOpacity.DarkIcons: code = "61"; break; // 38%
            case ConsoleMaterialOpacity.DarkDividers: code = "1F"; break; // 12%
            case ConsoleMaterialOpacity.LightPrimaryText: code = "FF"; break; // 100%
            case ConsoleMaterialOpacity.LightSecondaryText: code = "B3"; break; // 70%
            case ConsoleMaterialOpacity.LightDisabledText: code = "80"; break; // 50%
            case ConsoleMaterialOpacity.LightHintText: code = "80"; break; // 50%
            case ConsoleMaterialOpacity.LightIcons: code = "80"; break; // 50%
            case ConsoleMaterialOpacity.LightDividers: code = "1F"; break; // 12%
            default: code = "FF"; break; // 100%
        }
        return code;
    }
}

public enum ConsoleMaterialColorAdvanced
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

public static class ConsoleMaterialColorAdvancedExtensions
{
    public static string HTMLCode(this ConsoleMaterialColorAdvanced color)
    {
        string code;
        switch (color)
        {
            #region Reds
            case ConsoleMaterialColorAdvanced.Red050: code = "#FFEBEE"; break;
            case ConsoleMaterialColorAdvanced.Red100: code = "#FFCDD2"; break;
            case ConsoleMaterialColorAdvanced.Red200: code = "#EF9A9A"; break;
            case ConsoleMaterialColorAdvanced.Red300: code = "#E57373"; break;
            case ConsoleMaterialColorAdvanced.Red400: code = "#EF5350"; break;
            case ConsoleMaterialColorAdvanced.Red500: code = "#F44336"; break;
            case ConsoleMaterialColorAdvanced.Red600: code = "#E53935"; break;
            case ConsoleMaterialColorAdvanced.Red700: code = "#D32F2F"; break;
            case ConsoleMaterialColorAdvanced.Red800: code = "#C62828"; break;
            case ConsoleMaterialColorAdvanced.Red900: code = "#B71C1C"; break;
            case ConsoleMaterialColorAdvanced.RedA100: code = "#FF8A80"; break;
            case ConsoleMaterialColorAdvanced.RedA200: code = "#FF5252"; break;
            case ConsoleMaterialColorAdvanced.RedA400: code = "#FF1744"; break;
            case ConsoleMaterialColorAdvanced.RedA700: code = "#D50000"; break;
            #endregion Reds

            #region Pinks
            case ConsoleMaterialColorAdvanced.Pink050: code = "#FCE4EC"; break;
            case ConsoleMaterialColorAdvanced.Pink100: code = "#F8BBD0"; break;
            case ConsoleMaterialColorAdvanced.Pink200: code = "#F48FB1"; break;
            case ConsoleMaterialColorAdvanced.Pink300: code = "#F06292"; break;
            case ConsoleMaterialColorAdvanced.Pink400: code = "#EC407A"; break;
            case ConsoleMaterialColorAdvanced.Pink500: code = "#E91E63"; break;
            case ConsoleMaterialColorAdvanced.Pink600: code = "#D81B60"; break;
            case ConsoleMaterialColorAdvanced.Pink700: code = "#C2185B"; break;
            case ConsoleMaterialColorAdvanced.Pink800: code = "#AD1457"; break;
            case ConsoleMaterialColorAdvanced.Pink900: code = "#880E4F"; break;
            case ConsoleMaterialColorAdvanced.PinkA100: code = "#FF80AB"; break;
            case ConsoleMaterialColorAdvanced.PinkA200: code = "#FF4081"; break;
            case ConsoleMaterialColorAdvanced.PinkA400: code = "#F50057"; break;
            case ConsoleMaterialColorAdvanced.PinkA700: code = "#C51162"; break;
            #endregion Pinks

            #region Purples
            case ConsoleMaterialColorAdvanced.Purple050: code = "#F3E5F5"; break;
            case ConsoleMaterialColorAdvanced.Purple100: code = "#E1BEE7"; break;
            case ConsoleMaterialColorAdvanced.Purple200: code = "#CE93D8"; break;
            case ConsoleMaterialColorAdvanced.Purple300: code = "#BA68C8"; break;
            case ConsoleMaterialColorAdvanced.Purple400: code = "#AB47BC"; break;
            case ConsoleMaterialColorAdvanced.Purple500: code = "#9C27B0"; break;
            case ConsoleMaterialColorAdvanced.Purple600: code = "#8E24AA"; break;
            case ConsoleMaterialColorAdvanced.Purple700: code = "#7B1FA2"; break;
            case ConsoleMaterialColorAdvanced.Purple800: code = "#6A1B9A"; break;
            case ConsoleMaterialColorAdvanced.Purple900: code = "#4A148C"; break;
            case ConsoleMaterialColorAdvanced.PurpleA100: code = "#EA80FC"; break;
            case ConsoleMaterialColorAdvanced.PurpleA200: code = "#E040FB"; break;
            case ConsoleMaterialColorAdvanced.PurpleA400: code = "#D500F9"; break;
            case ConsoleMaterialColorAdvanced.PurpleA700: code = "#AA00FF"; break;
            #endregion Purples

            #region Deep Purples
            case ConsoleMaterialColorAdvanced.DeepPurple050: code = "#EDE7F6"; break;
            case ConsoleMaterialColorAdvanced.DeepPurple100: code = "#D1C4E9"; break;
            case ConsoleMaterialColorAdvanced.DeepPurple200: code = "#B39DDB"; break;
            case ConsoleMaterialColorAdvanced.DeepPurple300: code = "#9575CD"; break;
            case ConsoleMaterialColorAdvanced.DeepPurple400: code = "#7E57C2"; break;
            case ConsoleMaterialColorAdvanced.DeepPurple500: code = "#673AB7"; break;
            case ConsoleMaterialColorAdvanced.DeepPurple600: code = "#5E35B1"; break;
            case ConsoleMaterialColorAdvanced.DeepPurple700: code = "#512DA8"; break;
            case ConsoleMaterialColorAdvanced.DeepPurple800: code = "#4527A0"; break;
            case ConsoleMaterialColorAdvanced.DeepPurple900: code = "#311B92"; break;
            case ConsoleMaterialColorAdvanced.DeepPurpleA100: code = "#B388FF"; break;
            case ConsoleMaterialColorAdvanced.DeepPurpleA200: code = "#7C4DFF"; break;
            case ConsoleMaterialColorAdvanced.DeepPurpleA400: code = "#651FFF"; break;
            case ConsoleMaterialColorAdvanced.DeepPurpleA700: code = "#6200EA"; break;
            #endregion Deep Purples

            #region Indigos
            case ConsoleMaterialColorAdvanced.Indigo050: code = "#E8EAF6"; break;
            case ConsoleMaterialColorAdvanced.Indigo100: code = "#C5CAE9"; break;
            case ConsoleMaterialColorAdvanced.Indigo200: code = "#9FA8DA"; break;
            case ConsoleMaterialColorAdvanced.Indigo300: code = "#7986CB"; break;
            case ConsoleMaterialColorAdvanced.Indigo400: code = "#5C6BC0"; break;
            case ConsoleMaterialColorAdvanced.Indigo500: code = "#3F51B5"; break;
            case ConsoleMaterialColorAdvanced.Indigo600: code = "#3949AB"; break;
            case ConsoleMaterialColorAdvanced.Indigo700: code = "#303F9F"; break;
            case ConsoleMaterialColorAdvanced.Indigo800: code = "#283593"; break;
            case ConsoleMaterialColorAdvanced.Indigo900: code = "#1A237E"; break;
            case ConsoleMaterialColorAdvanced.IndigoA100: code = "#8C9EFF"; break;
            case ConsoleMaterialColorAdvanced.IndigoA200: code = "#536DFE"; break;
            case ConsoleMaterialColorAdvanced.IndigoA400: code = "#3D5AFE"; break;
            case ConsoleMaterialColorAdvanced.IndigoA700: code = "#304FFE"; break;
            #endregion Indigos

            #region Blues
            case ConsoleMaterialColorAdvanced.Blue050: code = "#E3F2FD"; break;
            case ConsoleMaterialColorAdvanced.Blue100: code = "#BBDEFB"; break;
            case ConsoleMaterialColorAdvanced.Blue200: code = "#90CAF9"; break;
            case ConsoleMaterialColorAdvanced.Blue300: code = "#64B5F6"; break;
            case ConsoleMaterialColorAdvanced.Blue400: code = "#42A5F5"; break;
            case ConsoleMaterialColorAdvanced.Blue500: code = "#2196F3"; break;
            case ConsoleMaterialColorAdvanced.Blue600: code = "#1E88E5"; break;
            case ConsoleMaterialColorAdvanced.Blue700: code = "#1976D2"; break;
            case ConsoleMaterialColorAdvanced.Blue800: code = "#1565C0"; break;
            case ConsoleMaterialColorAdvanced.Blue900: code = "#0D47A1"; break;
            case ConsoleMaterialColorAdvanced.BlueA100: code = "#82B1FF"; break;
            case ConsoleMaterialColorAdvanced.BlueA200: code = "#448AFF"; break;
            case ConsoleMaterialColorAdvanced.BlueA400: code = "#2979FF"; break;
            case ConsoleMaterialColorAdvanced.BlueA700: code = "#2962FF"; break;
            #endregion Blues

            #region Light Blues
            case ConsoleMaterialColorAdvanced.LightBlue050: code = "#E1F5FE"; break;
            case ConsoleMaterialColorAdvanced.LightBlue100: code = "#B3E5FC"; break;
            case ConsoleMaterialColorAdvanced.LightBlue200: code = "#81D4FA"; break;
            case ConsoleMaterialColorAdvanced.LightBlue300: code = "#4FC3F7"; break;
            case ConsoleMaterialColorAdvanced.LightBlue400: code = "#29B6F6"; break;
            case ConsoleMaterialColorAdvanced.LightBlue500: code = "#03A9F4"; break;
            case ConsoleMaterialColorAdvanced.LightBlue600: code = "#039BE5"; break;
            case ConsoleMaterialColorAdvanced.LightBlue700: code = "#0288D1"; break;
            case ConsoleMaterialColorAdvanced.LightBlue800: code = "#0277BD"; break;
            case ConsoleMaterialColorAdvanced.LightBlue900: code = "#01579B"; break;
            case ConsoleMaterialColorAdvanced.LightBlueA100: code = "#80D8FF"; break;
            case ConsoleMaterialColorAdvanced.LightBlueA200: code = "#40C4FF"; break;
            case ConsoleMaterialColorAdvanced.LightBlueA400: code = "#00B0FF"; break;
            case ConsoleMaterialColorAdvanced.LightBlueA700: code = "#0091EA"; break;
            #endregion Light Blues

            #region Cyans
            case ConsoleMaterialColorAdvanced.Cyan050: code = "#E0F7FA"; break;
            case ConsoleMaterialColorAdvanced.Cyan100: code = "#B2EBF2"; break;
            case ConsoleMaterialColorAdvanced.Cyan200: code = "#80DEEA"; break;
            case ConsoleMaterialColorAdvanced.Cyan300: code = "#4DD0E1"; break;
            case ConsoleMaterialColorAdvanced.Cyan400: code = "#26C6DA"; break;
            case ConsoleMaterialColorAdvanced.Cyan500: code = "#00BCD4"; break;
            case ConsoleMaterialColorAdvanced.Cyan600: code = "#00ACC1"; break;
            case ConsoleMaterialColorAdvanced.Cyan700: code = "#0097A7"; break;
            case ConsoleMaterialColorAdvanced.Cyan800: code = "#00838F"; break;
            case ConsoleMaterialColorAdvanced.Cyan900: code = "#006064"; break;
            case ConsoleMaterialColorAdvanced.CyanA100: code = "#84FFFF"; break;
            case ConsoleMaterialColorAdvanced.CyanA200: code = "#18FFFF"; break;
            case ConsoleMaterialColorAdvanced.CyanA400: code = "#00E5FF"; break;
            case ConsoleMaterialColorAdvanced.CyanA700: code = "#00B8D4"; break;
            #endregion Cyans

            #region Teals
            case ConsoleMaterialColorAdvanced.Teal050: code = "#E0F2F1"; break;
            case ConsoleMaterialColorAdvanced.Teal100: code = "#B2DFDB"; break;
            case ConsoleMaterialColorAdvanced.Teal200: code = "#80CBC4"; break;
            case ConsoleMaterialColorAdvanced.Teal300: code = "#4DB6AC"; break;
            case ConsoleMaterialColorAdvanced.Teal400: code = "#26A69A"; break;
            case ConsoleMaterialColorAdvanced.Teal500: code = "#009688"; break;
            case ConsoleMaterialColorAdvanced.Teal600: code = "#00897B"; break;
            case ConsoleMaterialColorAdvanced.Teal700: code = "#00796B"; break;
            case ConsoleMaterialColorAdvanced.Teal800: code = "#00695C"; break;
            case ConsoleMaterialColorAdvanced.Teal900: code = "#004D40"; break;
            case ConsoleMaterialColorAdvanced.TealA100: code = "#A7FFEB"; break;
            case ConsoleMaterialColorAdvanced.TealA200: code = "#64FFDA"; break;
            case ConsoleMaterialColorAdvanced.TealA400: code = "#1DE9B6"; break;
            case ConsoleMaterialColorAdvanced.TealA700: code = "#00BFA5"; break;
            #endregion Teals

            #region Greens
            case ConsoleMaterialColorAdvanced.Green050: code = "#E8F5E9"; break;
            case ConsoleMaterialColorAdvanced.Green100: code = "#C8E6C9"; break;
            case ConsoleMaterialColorAdvanced.Green200: code = "#A5D6A7"; break;
            case ConsoleMaterialColorAdvanced.Green300: code = "#81C784"; break;
            case ConsoleMaterialColorAdvanced.Green400: code = "#66BB6A"; break;
            case ConsoleMaterialColorAdvanced.Green500: code = "#4CAF50"; break;
            case ConsoleMaterialColorAdvanced.Green600: code = "#43A047"; break;
            case ConsoleMaterialColorAdvanced.Green700: code = "#388E3C"; break;
            case ConsoleMaterialColorAdvanced.Green800: code = "#2E7D32"; break;
            case ConsoleMaterialColorAdvanced.Green900: code = "#1B5E20"; break;
            case ConsoleMaterialColorAdvanced.GreenA100: code = "#B9F6CA"; break;
            case ConsoleMaterialColorAdvanced.GreenA200: code = "#69F0AE"; break;
            case ConsoleMaterialColorAdvanced.GreenA400: code = "#00E676"; break;
            case ConsoleMaterialColorAdvanced.GreenA700: code = "#00C853"; break;
            #endregion Greens

            #region Light Greens
            case ConsoleMaterialColorAdvanced.LightGreen050: code = "#F1F8E9"; break;
            case ConsoleMaterialColorAdvanced.LightGreen100: code = "#DCEDC8"; break;
            case ConsoleMaterialColorAdvanced.LightGreen200: code = "#C5E1A5"; break;
            case ConsoleMaterialColorAdvanced.LightGreen300: code = "#AED581"; break;
            case ConsoleMaterialColorAdvanced.LightGreen400: code = "#9CCC65"; break;
            case ConsoleMaterialColorAdvanced.LightGreen500: code = "#8BC34A"; break;
            case ConsoleMaterialColorAdvanced.LightGreen600: code = "#7CB342"; break;
            case ConsoleMaterialColorAdvanced.LightGreen700: code = "#689F38"; break;
            case ConsoleMaterialColorAdvanced.LightGreen800: code = "#558B2F"; break;
            case ConsoleMaterialColorAdvanced.LightGreen900: code = "#33691E"; break;
            case ConsoleMaterialColorAdvanced.LightGreenA100: code = "#CCFF90"; break;
            case ConsoleMaterialColorAdvanced.LightGreenA200: code = "#B2FF59"; break;
            case ConsoleMaterialColorAdvanced.LightGreenA400: code = "#76FF03"; break;
            case ConsoleMaterialColorAdvanced.LightGreenA700: code = "#64DD17"; break;
            #endregion Light Greens

            #region Limes
            case ConsoleMaterialColorAdvanced.Lime050: code = "#F9FBE7"; break;
            case ConsoleMaterialColorAdvanced.Lime100: code = "#F0F4C3"; break;
            case ConsoleMaterialColorAdvanced.Lime200: code = "#E6EE9C"; break;
            case ConsoleMaterialColorAdvanced.Lime300: code = "#DCE775"; break;
            case ConsoleMaterialColorAdvanced.Lime400: code = "#D4E157"; break;
            case ConsoleMaterialColorAdvanced.Lime500: code = "#CDDC39"; break;
            case ConsoleMaterialColorAdvanced.Lime600: code = "#C0CA33"; break;
            case ConsoleMaterialColorAdvanced.Lime700: code = "#AFB42B"; break;
            case ConsoleMaterialColorAdvanced.Lime800: code = "#9E9D24"; break;
            case ConsoleMaterialColorAdvanced.Lime900: code = "#827717"; break;
            case ConsoleMaterialColorAdvanced.LimeA100: code = "#F4FF81"; break;
            case ConsoleMaterialColorAdvanced.LimeA200: code = "#EEFF41"; break;
            case ConsoleMaterialColorAdvanced.LimeA400: code = "#C6FF00"; break;
            case ConsoleMaterialColorAdvanced.LimeA700: code = "#AEEA00"; break;
            #endregion Limes

            #region Yellows
            case ConsoleMaterialColorAdvanced.Yellow050: code = "#FFFDE7"; break;
            case ConsoleMaterialColorAdvanced.Yellow100: code = "#FFF9C4"; break;
            case ConsoleMaterialColorAdvanced.Yellow200: code = "#FFF59D"; break;
            case ConsoleMaterialColorAdvanced.Yellow300: code = "#FFF176"; break;
            case ConsoleMaterialColorAdvanced.Yellow400: code = "#FFEE58"; break;
            case ConsoleMaterialColorAdvanced.Yellow500: code = "#FFEB3B"; break;
            case ConsoleMaterialColorAdvanced.Yellow600: code = "#FDD835"; break;
            case ConsoleMaterialColorAdvanced.Yellow700: code = "#FBC02D"; break;
            case ConsoleMaterialColorAdvanced.Yellow800: code = "#F9A825"; break;
            case ConsoleMaterialColorAdvanced.Yellow900: code = "#F57F17"; break;
            case ConsoleMaterialColorAdvanced.YellowA100: code = "#FFFF8D"; break;
            case ConsoleMaterialColorAdvanced.YellowA200: code = "#FFFF00"; break;
            case ConsoleMaterialColorAdvanced.YellowA400: code = "#FFEA00"; break;
            case ConsoleMaterialColorAdvanced.YellowA700: code = "#FFD600"; break;
            #endregion Yellows

            #region Ambers
            case ConsoleMaterialColorAdvanced.Amber050: code = "#FFF8E1"; break;
            case ConsoleMaterialColorAdvanced.Amber100: code = "#FFECB3"; break;
            case ConsoleMaterialColorAdvanced.Amber200: code = "#FFE082"; break;
            case ConsoleMaterialColorAdvanced.Amber300: code = "#FFD54F"; break;
            case ConsoleMaterialColorAdvanced.Amber400: code = "#FFCA28"; break;
            case ConsoleMaterialColorAdvanced.Amber500: code = "#FFC107"; break;
            case ConsoleMaterialColorAdvanced.Amber600: code = "#FFB300"; break;
            case ConsoleMaterialColorAdvanced.Amber700: code = "#FFA000"; break;
            case ConsoleMaterialColorAdvanced.Amber800: code = "#FF8F00"; break;
            case ConsoleMaterialColorAdvanced.Amber900: code = "#FF6F00"; break;
            case ConsoleMaterialColorAdvanced.AmberA100: code = "#FFE57F"; break;
            case ConsoleMaterialColorAdvanced.AmberA200: code = "#FFD740"; break;
            case ConsoleMaterialColorAdvanced.AmberA400: code = "#FFC400"; break;
            case ConsoleMaterialColorAdvanced.AmberA700: code = "#FFAB00"; break;
            #endregion Ambers

            #region Oranges
            case ConsoleMaterialColorAdvanced.Orange050: code = "#FFF3E0"; break;
            case ConsoleMaterialColorAdvanced.Orange100: code = "#FFE0B2"; break;
            case ConsoleMaterialColorAdvanced.Orange200: code = "#FFCC80"; break;
            case ConsoleMaterialColorAdvanced.Orange300: code = "#FFB74D"; break;
            case ConsoleMaterialColorAdvanced.Orange400: code = "#FFA726"; break;
            case ConsoleMaterialColorAdvanced.Orange500: code = "#FF9800"; break;
            case ConsoleMaterialColorAdvanced.Orange600: code = "#FB8C00"; break;
            case ConsoleMaterialColorAdvanced.Orange700: code = "#F57C00"; break;
            case ConsoleMaterialColorAdvanced.Orange800: code = "#EF6C00"; break;
            case ConsoleMaterialColorAdvanced.Orange900: code = "#E65100"; break;
            case ConsoleMaterialColorAdvanced.OrangeA100: code = "#FFD180"; break;
            case ConsoleMaterialColorAdvanced.OrangeA200: code = "#FFAB40"; break;
            case ConsoleMaterialColorAdvanced.OrangeA400: code = "#FF9100"; break;
            case ConsoleMaterialColorAdvanced.OrangeA700: code = "#FF6D00"; break;
            #endregion Oranges

            #region Deep Oranges
            case ConsoleMaterialColorAdvanced.DeepOrange050: code = "#FBE9E7"; break;
            case ConsoleMaterialColorAdvanced.DeepOrange100: code = "#FFCCBC"; break;
            case ConsoleMaterialColorAdvanced.DeepOrange200: code = "#FFAB91"; break;
            case ConsoleMaterialColorAdvanced.DeepOrange300: code = "#FF8A65"; break;
            case ConsoleMaterialColorAdvanced.DeepOrange400: code = "#FF7043"; break;
            case ConsoleMaterialColorAdvanced.DeepOrange500: code = "#FF5722"; break;
            case ConsoleMaterialColorAdvanced.DeepOrange600: code = "#F4511E"; break;
            case ConsoleMaterialColorAdvanced.DeepOrange700: code = "#E64A19"; break;
            case ConsoleMaterialColorAdvanced.DeepOrange800: code = "#D84315"; break;
            case ConsoleMaterialColorAdvanced.DeepOrange900: code = "#BF360C"; break;
            case ConsoleMaterialColorAdvanced.DeepOrangeA100: code = "#FF9E80"; break;
            case ConsoleMaterialColorAdvanced.DeepOrangeA200: code = "#FF6E40"; break;
            case ConsoleMaterialColorAdvanced.DeepOrangeA400: code = "#FF3D00"; break;
            case ConsoleMaterialColorAdvanced.DeepOrangeA700: code = "#DD2C00"; break;
            #endregion Deep Oranges

            #region Browns
            case ConsoleMaterialColorAdvanced.Brown050: code = "#EFEBE9"; break;
            case ConsoleMaterialColorAdvanced.Brown100: code = "#D7CCC8"; break;
            case ConsoleMaterialColorAdvanced.Brown200: code = "#BCAAA4"; break;
            case ConsoleMaterialColorAdvanced.Brown300: code = "#A1887F"; break;
            case ConsoleMaterialColorAdvanced.Brown400: code = "#8D6E63"; break;
            case ConsoleMaterialColorAdvanced.Brown500: code = "#795548"; break;
            case ConsoleMaterialColorAdvanced.Brown600: code = "#6D4C41"; break;
            case ConsoleMaterialColorAdvanced.Brown700: code = "#5D4037"; break;
            case ConsoleMaterialColorAdvanced.Brown800: code = "#4E342E"; break;
            case ConsoleMaterialColorAdvanced.Brown900: code = "#3E2723"; break;
            #endregion Browns

            #region Greys
            case ConsoleMaterialColorAdvanced.Grey050: code = "#FAFAFA"; break;
            case ConsoleMaterialColorAdvanced.Grey100: code = "#F5F5F5"; break;
            case ConsoleMaterialColorAdvanced.Grey200: code = "#EEEEEE"; break;
            case ConsoleMaterialColorAdvanced.Grey300: code = "#E0E0E0"; break;
            case ConsoleMaterialColorAdvanced.Grey400: code = "#BDBDBD"; break;
            case ConsoleMaterialColorAdvanced.Grey500: code = "#9E9E9E"; break;
            case ConsoleMaterialColorAdvanced.Grey600: code = "#757575"; break;
            case ConsoleMaterialColorAdvanced.Grey700: code = "#616161"; break;
            case ConsoleMaterialColorAdvanced.Grey800: code = "#424242"; break;
            case ConsoleMaterialColorAdvanced.Grey900: code = "#212121"; break;
            #endregion Greys

            #region Blue Greys
            case ConsoleMaterialColorAdvanced.BlueGrey050: code = "#ECEFF1"; break;
            case ConsoleMaterialColorAdvanced.BlueGrey100: code = "#CFD8DC"; break;
            case ConsoleMaterialColorAdvanced.BlueGrey200: code = "#B0BEC5"; break;
            case ConsoleMaterialColorAdvanced.BlueGrey300: code = "#90A4AE"; break;
            case ConsoleMaterialColorAdvanced.BlueGrey400: code = "#78909C"; break;
            case ConsoleMaterialColorAdvanced.BlueGrey500: code = "#607D8B"; break;
            case ConsoleMaterialColorAdvanced.BlueGrey600: code = "#546E7A"; break;
            case ConsoleMaterialColorAdvanced.BlueGrey700: code = "#455A64"; break;
            case ConsoleMaterialColorAdvanced.BlueGrey800: code = "#37474F"; break;
            case ConsoleMaterialColorAdvanced.BlueGrey900: code = "#263238"; break;
            #endregion Blue Greys

            default: code = "#FFFFFF"; break;
        }
        return code;
    }
}
