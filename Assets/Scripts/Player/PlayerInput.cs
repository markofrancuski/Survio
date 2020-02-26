using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void OnFireEventHandler();
    public static event OnFireEventHandler OnFire;

    public GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Transform _targetPosition;

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


    void FireUpProjectile(Vector2 direction)
    {
        //Add Pooler later
        GameObject go = Instantiate(_bulletPrefab, _spawnPosition.position, Quaternion.identity);
        go.GetComponent<Bullet>().Fire(direction);
        OnFire?.Invoke();
    }

    Vector2 GetDirection()
    {
        Vector2 vec = _targetPosition.position - _spawnPosition.position;
        return vec.normalized;
    }

    //For Events upon opening canvas
    private void StopShooting() => CheckForInput = false;
    private void StartShooting() => CheckForInput = true;

}
