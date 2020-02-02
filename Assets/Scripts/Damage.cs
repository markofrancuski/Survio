using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damage : MonoBehaviour
{
    [Header("DAMAGE CLASS")]
    [SerializeField] protected float DMG;

    public float GetDamage() => DMG;
}
