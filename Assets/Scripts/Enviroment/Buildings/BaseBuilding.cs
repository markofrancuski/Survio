using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BaseBuilding : MonoBehaviour, IDamagable
{
    public delegate void OnBuildingStateChangedDelegate();// OpenBuilding;

    [SerializeField] private bool _isDestroyable;

    [SerializeField] private float MaxHealth;
    [SerializeField] private float _currentHealth;

    public void TakeDamage(float amount)
    {
        if (!_isDestroyable) return;
        
        //Take Damage
    }
}
