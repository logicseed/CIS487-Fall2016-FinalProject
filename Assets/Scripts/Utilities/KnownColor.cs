// Marc King - mjking@umich.edu
// Colors by Microsoft

public enum KnownColor
{
    AliceBlue,
    AntiqueWhite,
    Aqua,
    Aquamarine,
    Azure,
    Beige,
    Bisque,
    Black,
    BlanchedAlmond,
    Blue,
    BlueViolet,
    Brown,
    BurlyWood,
    CadetBlue,
    Chartreuse,
    Chocolate,
    Coral,
    CornflowerBlue,
    Cornsilk,
    Crimson,
    Cyan,
    DarkBlue,
    DarkCyan,
    DarkGoldenrod,
    DarkGray,
    DarkGreen,
    DarkKhaki,
    DarkMagenta,
    DarkOliveGreen,
    DarkOrange,
    DarkOrchid,
    DarkRed,
    DarkSalmon,
    DarkSeaGreen,
    DarkSlateBlue,
    DarkSlateGray,
    DarkTurquoise,
    DarkViolet,
    DeepPink,
    DeepSkyBlue,
    DimGray,
    DodgerBlue,
    Firebrick,
    FloralWhite,
    ForestGreen,
    Fuchsia,
    Gainsboro,
    GhostWhite,
    Gold,
    Goldenrod,
    Gray,
    Green,
    GreenYellow,
    Honeydew,
    HotPink,
    IndianRed,
    Indigo,
    Ivory,
    Khaki,
    Lavender,
    LavenderBlush,
    LawnGreen,
    LemonChiffon,
    LightBlue,
    LightCoral,
    LightCyan,
    LightGoldenrodYellow,
    LightGreen,
    LightGray,
    LightPink,
    LightSalmon,
    LightSeaGreen,
    LightSkyBlue,
    LightSlateGray,
    LightSteelBlue,
    LightYellow,
    Lime,
    LimeGreen,
    Linen,
    Magenta,
    Maroon,
    MediumAquamarine,
    MediumBlue,
    MediumOrchid,
    MediumPurple,
    MediumSeaGreen,
    MediumSlateBlue,
    MediumSpringGreen,
    MediumTurquoise,
    MediumVioletRed,
    MidnightBlue,
    MintCream,
    MistyRose,
    Moccasin,
    NavajoWhite,
    Navy,
    OldLace,
    Olive,
    OliveDrab,
    Orange,
    OrangeRed,
    Orchid,
    PaleGoldenrod,
    PaleGreen,
    PaleTurquoise,
    PaleVioletRed,
    PapayaWhip,
    PeachPuff,
    Peru,
    Pink,
    Plum,
    PowderBlue,
    Purple,
    Red,
    RosyBrown,
    RoyalBlue,
    SaddleBrown,
    Salmon,
    SandyBrown,
    SeaGreen,
    SeaShell,
    Sienna,
    Silver,
    SkyBlue,
    SlateBlue,
    SlateGray,
    Snow,
    SpringGreen,
    SteelBlue,
    Tan,
    Teal,
    Thistle,
    Tomato,
    Turquoise,
    Violet,
    Wheat,
    White,
    WhiteSmoke,
    Yellow,
    YellowGreen
}

public static class KnownColorExtensions
{
    public static string HTMLCode(this KnownColor color)
    {
        string code;
        switch (color)
        {
            case KnownColor.AliceBlue: code = "#F0F8FF"; break;
            case KnownColor.AntiqueWhite: code = "#FAEBD7"; break;
            case KnownColor.Aqua: code = "#00FFFF"; break;
            case KnownColor.Aquamarine: code = "#7FFFD4"; break;
            case KnownColor.Azure: code = "#F0FFFF"; break;
            case KnownColor.Beige: code = "#F5F5DC"; break;
            case KnownColor.Bisque: code = "#FFE4C4"; break;
            case KnownColor.Black: code = "#000000"; break;
            case KnownColor.BlanchedAlmond: code = "#FFEBCD"; break;
            case KnownColor.Blue: code = "#0000FF"; break;
            case KnownColor.BlueViolet: code = "#8A2BE2"; break;
            case KnownColor.Brown: code = "#A52A2A"; break;
            case KnownColor.BurlyWood: code = "#DEB887"; break;
            case KnownColor.CadetBlue: code = "#5F9EA0"; break;
            case KnownColor.Chartreuse: code = "#7FFF00"; break;
            case KnownColor.Chocolate: code = "#D2691E"; break;
            case KnownColor.Coral: code = "#FF7F50"; break;
            case KnownColor.CornflowerBlue: code = "#6495ED"; break;
            case KnownColor.Cornsilk: code = "#FFF8DC"; break;
            case KnownColor.Crimson: code = "#DC143C"; break;
            case KnownColor.Cyan: code = "#00FFFF"; break;
            case KnownColor.DarkBlue: code = "#00008B"; break;
            case KnownColor.DarkCyan: code = "#008B8B"; break;
            case KnownColor.DarkGoldenrod: code = "#B8860B"; break;
            case KnownColor.DarkGray: code = "#A9A9A9"; break;
            case KnownColor.DarkGreen: code = "#006400"; break;
            case KnownColor.DarkKhaki: code = "#BDB76B"; break;
            case KnownColor.DarkMagenta: code = "#8B008B"; break;
            case KnownColor.DarkOliveGreen: code = "#556B2F"; break;
            case KnownColor.DarkOrange: code = "#FF8C00"; break;
            case KnownColor.DarkOrchid: code = "#9932CC"; break;
            case KnownColor.DarkRed: code = "#8B0000"; break;
            case KnownColor.DarkSalmon: code = "#E9967A"; break;
            case KnownColor.DarkSeaGreen: code = "#8FBC8F"; break;
            case KnownColor.DarkSlateBlue: code = "#483D8B"; break;
            case KnownColor.DarkSlateGray: code = "#2F4F4F"; break;
            case KnownColor.DarkTurquoise: code = "#00CED1"; break;
            case KnownColor.DarkViolet: code = "#9400D3"; break;
            case KnownColor.DeepPink: code = "#FF1493"; break;
            case KnownColor.DeepSkyBlue: code = "#00BFFF"; break;
            case KnownColor.DimGray: code = "#696969"; break;
            case KnownColor.DodgerBlue: code = "#1E90FF"; break;
            case KnownColor.Firebrick: code = "#B22222"; break;
            case KnownColor.FloralWhite: code = "#FFFAF0"; break;
            case KnownColor.ForestGreen: code = "#228B22"; break;
            case KnownColor.Fuchsia: code = "#FF00FF"; break;
            case KnownColor.Gainsboro: code = "#DCDCDC"; break;
            case KnownColor.GhostWhite: code = "#F8F8FF"; break;
            case KnownColor.Gold: code = "#FFD700"; break;
            case KnownColor.Goldenrod: code = "#DAA520"; break;
            case KnownColor.Gray: code = "#808080"; break;
            case KnownColor.Green: code = "#008000"; break;
            case KnownColor.GreenYellow: code = "#ADFF2F"; break;
            case KnownColor.Honeydew: code = "#F0FFF0"; break;
            case KnownColor.HotPink: code = "#FF69B4"; break;
            case KnownColor.IndianRed: code = "#CD5C5C"; break;
            case KnownColor.Indigo: code = "#4B0082"; break;
            case KnownColor.Ivory: code = "#FFFFF0"; break;
            case KnownColor.Khaki: code = "#F0E68C"; break;
            case KnownColor.Lavender: code = "#E6E6FA"; break;
            case KnownColor.LavenderBlush: code = "#FFF0F5"; break;
            case KnownColor.LawnGreen: code = "#7CFC00"; break;
            case KnownColor.LemonChiffon: code = "#FFFACD"; break;
            case KnownColor.LightBlue: code = "#ADD8E6"; break;
            case KnownColor.LightCoral: code = "#F08080"; break;
            case KnownColor.LightCyan: code = "#E0FFFF"; break;
            case KnownColor.LightGoldenrodYellow: code = "#FAFAD2"; break;
            case KnownColor.LightGreen: code = "#90EE90"; break;
            case KnownColor.LightGray: code = "#D3D3D3"; break;
            case KnownColor.LightPink: code = "#FFB6C1"; break;
            case KnownColor.LightSalmon: code = "#FFA07A"; break;
            case KnownColor.LightSeaGreen: code = "#20B2AA"; break;
            case KnownColor.LightSkyBlue: code = "#87CEFA"; break;
            case KnownColor.LightSlateGray: code = "#778899"; break;
            case KnownColor.LightSteelBlue: code = "#B0C4DE"; break;
            case KnownColor.LightYellow: code = "#FFFFE0"; break;
            case KnownColor.Lime: code = "#00FF00"; break;
            case KnownColor.LimeGreen: code = "#32CD32"; break;
            case KnownColor.Linen: code = "#FAF0E6"; break;
            case KnownColor.Magenta: code = "#FF00FF"; break;
            case KnownColor.Maroon: code = "#800000"; break;
            case KnownColor.MediumAquamarine: code = "#66CDAA"; break;
            case KnownColor.MediumBlue: code = "#0000CD"; break;
            case KnownColor.MediumOrchid: code = "#BA55D3"; break;
            case KnownColor.MediumPurple: code = "#9370DB"; break;
            case KnownColor.MediumSeaGreen: code = "#3CB371"; break;
            case KnownColor.MediumSlateBlue: code = "#7B68EE"; break;
            case KnownColor.MediumSpringGreen: code = "#00FA9A"; break;
            case KnownColor.MediumTurquoise: code = "#48D1CC"; break;
            case KnownColor.MediumVioletRed: code = "#C71585"; break;
            case KnownColor.MidnightBlue: code = "#191970"; break;
            case KnownColor.MintCream: code = "#F5FFFA"; break;
            case KnownColor.MistyRose: code = "#FFE4E1"; break;
            case KnownColor.Moccasin: code = "#FFE4B5"; break;
            case KnownColor.NavajoWhite: code = "#FFDEAD"; break;
            case KnownColor.Navy: code = "#000080"; break;
            case KnownColor.OldLace: code = "#FDF5E6"; break;
            case KnownColor.Olive: code = "#808000"; break;
            case KnownColor.OliveDrab: code = "#6B8E23"; break;
            case KnownColor.Orange: code = "#FFA500"; break;
            case KnownColor.OrangeRed: code = "#FF4500"; break;
            case KnownColor.Orchid: code = "#DA70D6"; break;
            case KnownColor.PaleGoldenrod: code = "#EEE8AA"; break;
            case KnownColor.PaleGreen: code = "#98FB98"; break;
            case KnownColor.PaleTurquoise: code = "#AFEEEE"; break;
            case KnownColor.PaleVioletRed: code = "#DB7093"; break;
            case KnownColor.PapayaWhip: code = "#FFEFD5"; break;
            case KnownColor.PeachPuff: code = "#FFDAB9"; break;
            case KnownColor.Peru: code = "#CD853F"; break;
            case KnownColor.Pink: code = "#FFC0CB"; break;
            case KnownColor.Plum: code = "#DDA0DD"; break;
            case KnownColor.PowderBlue: code = "#B0E0E6"; break;
            case KnownColor.Purple: code = "#800080"; break;
            case KnownColor.Red: code = "#FF0000"; break;
            case KnownColor.RosyBrown: code = "#BC8F8F"; break;
            case KnownColor.RoyalBlue: code = "#4169E1"; break;
            case KnownColor.SaddleBrown: code = "#8B4513"; break;
            case KnownColor.Salmon: code = "#FA8072"; break;
            case KnownColor.SandyBrown: code = "#F4A460"; break;
            case KnownColor.SeaGreen: code = "#2E8B57"; break;
            case KnownColor.SeaShell: code = "#FFF5EE"; break;
            case KnownColor.Sienna: code = "#A0522D"; break;
            case KnownColor.Silver: code = "#C0C0C0"; break;
            case KnownColor.SkyBlue: code = "#87CEEB"; break;
            case KnownColor.SlateBlue: code = "#6A5ACD"; break;
            case KnownColor.SlateGray: code = "#708090"; break;
            case KnownColor.Snow: code = "#FFFAFA"; break;
            case KnownColor.SpringGreen: code = "#00FF7F"; break;
            case KnownColor.SteelBlue: code = "#4682B4"; break;
            case KnownColor.Tan: code = "#D2B48C"; break;
            case KnownColor.Teal: code = "#008080"; break;
            case KnownColor.Thistle: code = "#D8BFD8"; break;
            case KnownColor.Tomato: code = "#FF6347"; break;
            case KnownColor.Turquoise: code = "#40E0D0"; break;
            case KnownColor.Violet: code = "#EE82EE"; break;
            case KnownColor.Wheat: code = "#F5DEB3"; break;
            case KnownColor.White: code = "#FFFFFF"; break;
            case KnownColor.WhiteSmoke: code = "#F5F5F5"; break;
            case KnownColor.Yellow: code = "#FFFF00"; break;
            case KnownColor.YellowGreen: code = "#9ACD32"; break;
            default: code = "#FFFFFF"; break;
        }
        return code;
    }
}

