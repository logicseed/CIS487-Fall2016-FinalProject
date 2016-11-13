// Marc King - mjking@umich.edu

using UnityEngine;

public static class Vector3Extensions
{
    /// <summary>
    /// Truncates a Vector3 to a maximum magnitude.
    /// </summary>
    /// <param name="magnitude">Maximum magnitude of vector.</param>
    /// <returns>Vector3 truncated to a maximum magnitude.</returns>
    public static Vector3 Truncate(this Vector3 vector, float magnitude)
    {
        if (vector.magnitude > magnitude)
        {
            return vector.normalized * magnitude;
        }
        return vector;
    }
}
