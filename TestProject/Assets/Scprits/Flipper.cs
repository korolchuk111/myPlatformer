using UnityEngine;

public class Flipper
{
    public static void FlipX(Transform transform)
    {
        var scale = transform.localScale;
        scale.x *= -1;

        transform.localScale = scale;
    }
}
