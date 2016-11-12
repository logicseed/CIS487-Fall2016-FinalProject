// Marc King - mjking@umich.edu

using System;

public static class FloatExtensions
{
    // The built in float.Epsilon is far too small for use with Unity
    private const float UNITY_EPSILON = 0.0005f;

    /// <summary>
    /// Compares two float values to see if they are close enough to be considered equal.
    /// </summary>
    /// <param name="comparedWith">The float to compare with.</param>
    /// <param name="comparedTo">The float to compare to.</param>
    /// <param name="epsilon">The smallest difference that is considered equal.</param>
    /// <returns>True is nearly equal to; false otherwise.</returns>
    public static bool NearlyEqualTo(this float comparedWith, float comparedTo, float epsilon = UNITY_EPSILON)
    {
        var absoluteDifference = Math.Abs(comparedWith - comparedTo);

        return absoluteDifference < epsilon;
    }

    /// <summary>
    /// Compares two float values to see if one is larger or considered equal to the other.
    /// </summary>
    /// <param name="comparedWith">The float to compare with.</param>
    /// <param name="comparedTo">The float to compare to.</param>
    /// <param name="epsilon">The smallest difference that is considered equal.</param>
    /// <returns>True if greater than or nearly equal to; false otherwise.</returns>
    public static bool GreaterOrNearlyEqualTo(this float comparedWith, float comparedTo, float epsilon = UNITY_EPSILON)
    {
        return comparedWith.NearlyEqualTo(comparedTo, epsilon) || comparedWith > comparedTo;
    }

    /// <summary>
    /// Compares two float values to see if one is smaller or considered equal to the other.
    /// </summary>
    /// <param name="comparedWith">The float to compare with.</param>
    /// <param name="comparedTo">The float to compare to.</param>
    /// <param name="epsilon">The smallest difference that is considered equal.</param>
    /// <returns>True if lesser than or nearly equal to; false otherwise.</returns>
    public static bool LesserOrNearlyEqualTo(this float comparedWith, float comparedTo, float epsilon = UNITY_EPSILON)
    {
        return comparedWith.NearlyEqualTo(comparedTo, epsilon) || comparedWith < comparedTo;
    }

    public static bool GreaterThan(this float comparedWith, float comparedTo, float epsilon = UNITY_EPSILON)
    {
        return comparedWith > comparedTo + epsilon;
    }

    public static bool LesserThan(this float comparedWith, float comparedTo, float epsilon = UNITY_EPSILON)
    {
        return comparedWith < comparedTo - epsilon;
    }
}
