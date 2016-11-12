using UnityEngine;
using System.Collections;

public static class IntExtensions
{
    /// <summary>
    /// Extension method to determine if an integer is even number.
    /// </summary>
    /// <returns>True if the integer is even; false otherwise.</returns>
    public static bool IsEven(this int integer)
    {
        return integer % 2 == 0;
    }

    /// <summary>
    /// Extension method to determine if an integer is an odd number.
    /// </summary>
    /// <returns>True if the integer is an odd number; false otherwise.</returns>
    public static bool IsOdd(this int integer)
    {
        return integer % 2 != 0;
    }
}
