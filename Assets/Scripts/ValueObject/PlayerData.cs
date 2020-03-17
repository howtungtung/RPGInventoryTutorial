using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class PlayerData
{
    public int[] ownItems;
    [Range(0,100)]
    public int str;
    [Range(0, 100)]
    public int vit;
    [Range(0, 100)]
    public int luk;
    [Range(0, 100)]
    public int @int;
    [Range(0, 100)]
    public int dex;
    [Range(0, 100)]
    public int agi;

    public float[] GetNormalizedStatus()
    {
        float[] output = new float[] {
            str/100f,
            vit/100f,
            luk/100f,
            @int/100f,
            dex/100f,
            agi/100f
        };
        return output;
    }
}
