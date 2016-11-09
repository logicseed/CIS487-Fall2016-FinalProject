// Marc King - mjking@umich.edu

using System;

public static class StringExtensions
{
    public static string RichTextColor(this string text, MaterialColor color, MaterialOpacity opacity = MaterialOpacity.Full)
    {
        return "<color=" + color.HTMLCode() + opacity.HTMLCode() + ">" + text + "</color>";
    }

    public static string RichTextColor(this string text, MaterialColorAdvanced color, MaterialOpacity opacity = MaterialOpacity.Full)
    {
        return "<color=" + color.HTMLCode() + opacity.HTMLCode() + ">" + text + "</color>";
    }

    public static string RichTextColor(this string text, KnownColor color, int opacity = 100)
    {
        string opacityCode = ((int)Math.Round(255 * ((float)opacity / 100))).ToString("X");
        return "<color=" + color.HTMLCode() + opacityCode + ">" + text + "</color>";
    }

    public static string RichTextBold(this string text)
    {
        return "<b>" + text + "</b>";
    }

    public static string RichTextItalic(this string text)
    {
        return "<i>" + text + "</i>";
    }

    public static string RichTextSize(this string text, int size)
    {
        if (size <= 0) size = 12;
        return "<size=" + size + ">" + text + "</size>";
    }
}
