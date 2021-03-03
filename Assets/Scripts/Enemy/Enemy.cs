using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public enum EffectType
    {
        depressants,
        hallucinogens,
        stimulants,
        multipleEffect
    }

    public string name;
    public string description;
    public EffectType effectType;
}
