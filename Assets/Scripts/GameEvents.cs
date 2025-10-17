using System;

public static class GameEvents
{
    public static event Action CubeHitCylinder;

    public static void RaiseCubeHitCylinder()
        => CubeHitCylinder?.Invoke();
}
