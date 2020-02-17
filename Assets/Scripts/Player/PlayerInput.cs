using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void OnFireEventHandler();
    public static event OnFireEventHandler OnFire;

    public GameObject bulletPrefab;
    public Transform spawnPosition;

    //public FirstHand firstHand;

    [SerializeField] private bool CheckForInput;

    // Update is called once per frame
    void Update()
    {
        if (!CheckForInput) return;

        if(Input.GetMouseButtonUp(0))
        {
            FireUpProjectile( GetDirection() );
        }

    }

    private void OnEnable()
    {
        CanvasManager.CanvasPaused += StopShooting;
        CanvasManager.CanvasUnpaused += StartShooting;
    }

    private void OnDisable()
    {
        CanvasManager.CanvasPaused -= StopShooting;
        CanvasManager.CanvasUnpaused -= StartShooting;
    }


    void FireUpProjectile(Vector3 direction)
    {
        GameObject go = Instantiate(bulletPrefab, spawnPosition.position, Quaternion.identity);
        go.GetComponent<Bullet>().Fire(direction);
        OnFire?.Invoke();
    }

    Vector3 GetDirection()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //
        //if (vec.x > 0) vec.x = 1;
        //else if (vec.x < 0) vec.x = -1;
        //else vec.x = 0;

        //if (vec.y > 0) vec.y = 1;
        //else if (vec.y < 0) vec.y = -1;
        //else vec.y = 0;
        return vec.normalized;
    }

    //For Events upon opening canvas
    private void StopShooting() => CheckForInput = false;
    private void StartShooting() => CheckForInput = true;

}
