using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : Damage
{
    [Header("BULLET CLASS")]
    [SerializeField] Rigidbody2D _rigidBody;
   
    public float moveSpeed;

    public Vector3 dir;

    public void Fire(Vector3 direction)
    {
        dir = direction;
        _rigidBody.velocity = dir * moveSpeed;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
           
        //_rigidBody.velocity = direction * moveSpeed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
