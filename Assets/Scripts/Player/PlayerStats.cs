using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamagable
{
    public delegate void OnDamageReceivedEventHandler();
    private OnDamageReceivedEventHandler OnDamageReceived;

    FlashRed red;

    public float Health;
    private float health;


    private void Start()
    {
        red = GetComponent<FlashRed>();
        if (red != null) OnDamageReceived += red.TintRed;
    }

    private void OnDisable()
    {
        if (red != null) OnDamageReceived -= red.TintRed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        DamageManager.Instance.SpawnText(transform.position + Vector3.up, amount.ToString(), Colors.WHITE);
        OnDamageReceived?.Invoke();
    }
    
}
