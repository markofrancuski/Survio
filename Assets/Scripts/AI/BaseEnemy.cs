using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseEnemy : MonoBehaviour
{

    [SerializeField] private AIState _currentState;

    [Header("Stats")]
    [SerializeField] private float attackRadius;
    [SerializeField] private float chaseRadius;

    [SerializeField] FlashRed red;
    private void Awake()
    {
        try
        {
            red = GetComponent<FlashRed>();
            if (red == null) throw new System.Exception($"GameObject: { gameObject.name} has no component FlashRed");
        }
        catch(System.Exception e)
        {
            Debug.Log(e.Message);
        }

    }
    [SerializeField] private float _health;
    public float Health
    {
        get { return _health; }
        set
        {
            _health = value;
            if(_health > 0) if (red != null) red.TintRed();
            else gameObject.SetActive(false);
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Health -= other.GetComponent<IDamage>().DMG;
        }
    }
}
