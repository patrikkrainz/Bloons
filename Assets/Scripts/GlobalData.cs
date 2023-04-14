using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    private static float Volume = -10;

    public static void setVolume(float volume)
    {
        Volume = volume;
    }

    public static float getVolume()
    {
        return Volume;
    }
}
