using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform spawnPosition;

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonUp(0))
        {
            FireUpProjectile( GetDirection() );
        }

    }

    void FireUpProjectile(Vector3 direction)
    {
        GameObject go = Instantiate(bulletPrefab, spawnPosition.position, Quaternion.identity);
        go.GetComponent<Bullet>().Fire(direction);
    }

    Vector3 GetDirection()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //if (vec.x > 0) vec.x = 1;
        //else if (vec.x < 0) vec.x = -1;
        //else vec.x = 0;

        //if (vec.y > 0) vec.y = 1;
        //else if (vec.y < 0) vec.y = -1;
        //else vec.y = 0;

        return vec.normalized;
    }

}
