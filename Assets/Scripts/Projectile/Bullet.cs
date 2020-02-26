using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(Rigidbody2D)) ]
public class Bullet : Damage
{
    [Header("BULLET CLASS")]
    [SerializeField] Rigidbody2D _rigidBody;
   
    public float moveSpeed;

    public Vector2 dir;
  
    public void Fire(Vector2 direction)
    {

        //float angle = Mathf.Acos(Vector2.Dot(Vector2.up, transform.TransformDirection(direction)) );
        //transform.Rotate(Vector3.back, angle * Mathf.Rad2Deg);

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

        _rigidBody.velocity = direction * moveSpeed;
        //_rigidBody.velocity = direction * moveSpeed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
