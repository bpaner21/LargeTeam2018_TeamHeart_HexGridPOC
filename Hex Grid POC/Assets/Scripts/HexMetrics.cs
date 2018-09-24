using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HexMetrics
{
    // The distance from the center of a hexagonal cell to a corner
    public const float OuterRadius = 10f;

    // The shortest distance from the center of a hexagonal cell to an edge
    public const float InnerRadius = OuterRadius * 0.86602540378f;

    public const float HalfOuterRadius = OuterRadius * 0.5f;

    // Establishes the positions of the corners of 
    // a hexagonical cell relative to its center
    //
    // These cells are oriented so  
    // that flat sides are facing up
    //
    public static Vector3[] corners =
    {
        new Vector3(HalfOuterRadius, 0f, InnerRadius),
        new Vector3(OuterRadius, 0f, 0f),
        new Vector3(HalfOuterRadius, 0f, -InnerRadius),
        new Vector3(-HalfOuterRadius, 0f, -InnerRadius),
        new Vector3(-OuterRadius, 0f, 0f),
        new Vector3(-HalfOuterRadius, 0f, InnerRadius)
    };
}
