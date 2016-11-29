// Marc King - mjking@umich.edu

using UnityEngine;


public static class MaterialColor
{
    // Red: #F44336
    public static Color Red { get { return new Color(0.957f, 0.263f, 0.212f); } }

    // Pink: #E91E63
    public static Color Pink { get { return new Color(0.914f, 0.118f, 0.388f); } }

    // Purple: #9C27B0
    public static Color Purple { get { return new Color(0.612f, 0.153f, 0.690f); } }

    // DeepPurple: #673AB7
    public static Color DeepPurple { get { return new Color(0.404f, 0.227f, 0.718f); } }

    // Indigo: #3F51B5
    public static Color Indigo { get { return new Color(0.247f, 0.318f, 0.710f); } }

    // Blue: #2196F3
    public static Color Blue { get { return new Color(0.129f, 0.588f, 0.953f); } }

    // LightBlue: #03A9F4
    public static Color LightBlue { get { return new Color(0.012f, 0.663f, 0.957f); } }

    // Cyan: #00BCD4
    public static Color Cyan { get { return new Color(0.0f, 0.737f, 0.831f); } }

    // Teal: #009688
    public static Color Teal { get { return new Color(0.0f, 0.588f, 0.533f); } }

    // Green: #4CAF50
    public static Color Green { get { return new Color(0.298f, 0.686f, 0.314f); } }

    // LightGreen: #8BC34A
    public static Color LightGreen { get { return new Color(0.545f, 0.765f, 0.290f); } }

    // Lime: #CDDC39
    public static Color Lime { get { return new Color(0.804f, 0.863f, 0.224f); } }

    // Yellow: #FFEB3B
    public static Color Yellow { get { return new Color(1.0f, 0.922f, 0.231f); } }

    // Amber: #FFC107
    public static Color Amber { get { return new Color(1.0f, 0.757f, 0.027f); } }

    // Orange: #FF9800
    public static Color Orange { get { return new Color(1.0f, 0.596f, 0.0f); } }

    // DeepOrange: #FF5722
    public static Color DeepOrange { get { return new Color(1.0f, 0.341f, 0.133f); } }

    // Brown: #795548
    public static Color Brown { get { return new Color(0.475f, 0.333f, 0.282f); } }

    // Grey: #9E9E9E
    public static Color Grey { get { return new Color(0.620f, 0.620f, 0.620f); } }

    // BlueGrey: #607D8B
    public static Color BlueGrey { get { return new Color(0.376f, 0.490f, 0.545f); } }

    // Black: #000000
    public static Color Black { get { return new Color(0.0f, 0.0f, 0.0f); } }

    // White: #FFFFFF
    public static Color White { get { return new Color(1.0f, 1.0f, 1.0f); } }


    public static class Standard
    {
        public static Color Velocity { get { return Indigo; } }
        public static Color Acceleration { get { return Red; } }
        public static Color UnclampedAcceleration { get { return Brown; } }
        public static Color Distance { get { return Green; } }
        public static Color SeekDesiredVelocity { get { return DeepPurple; } }
        public static Color SeekSteering { get { return Pink; } }
        public static Color AvoidRayDistance { get { return Orange; } }
        public static Color AvoidSteering { get { return DeepOrange; } }
    }
}
