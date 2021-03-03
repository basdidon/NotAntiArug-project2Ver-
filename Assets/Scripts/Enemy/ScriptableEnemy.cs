using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableEnemy : ScriptableObject
{
    public enum EffectType
    {
        depressants,
        hallucinogens,
        stimulants,
        multipleEffect
    }

    public string enemyName;
    [TextArea(1,5)]
    public string enemyDescription;

    public Sprite enemySprite;

    public EffectType effectType;
}