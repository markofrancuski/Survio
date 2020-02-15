using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damage : MonoBehaviour, IDamage
{
    [Header("DAMAGE CLASS")]

    #region INTERFACE IMPLEMENTATION

    [SerializeField] private float damage;
    public float DMG { get => damage; set => damage = value; }
    #endregion 
}
