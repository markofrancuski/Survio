using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer) )]
public class FlashRed : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void TintRed()
    {
        if(!IsInvoking("ResetColor"))
        {
            _spriteRenderer.color = Color.red;
            Invoke("ResetColor", 0.1f);
        }
    }

    void ResetColor()
    {
        _spriteRenderer.color = Color.white;
    }

}
