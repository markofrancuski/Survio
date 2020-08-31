using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FlashRed))]
public class Melee : BaseEnemy, IDamage
{

    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _spawnPosition;

    [SerializeField] private float _patrolBoxHorizontalBorder;
    [SerializeField] private float _patrolBoxVerticalBorder;

    [SerializeField] private float _patrolWaitTime;

    public float DMG
    {
        get => throw new System.NotImplementedException();
        set => throw new System.NotImplementedException();
    }


    private void Awake()
    {
        SaveSpawnPosition(transform.position);
    }

    protected override void Update()
    {
        base.Update();

        // Patrol Box
        Debug.DrawLine(transform.position + new Vector3(-_patrolBoxHorizontalBorder, -_patrolBoxVerticalBorder), transform.position + new Vector3(_patrolBoxHorizontalBorder, -_patrolBoxVerticalBorder), Color.blue);
        Debug.DrawLine(transform.position + new Vector3(-_patrolBoxHorizontalBorder, _patrolBoxVerticalBorder), transform.position + new Vector3(_patrolBoxHorizontalBorder, _patrolBoxVerticalBorder), Color.blue);
        Debug.DrawLine(transform.position + new Vector3(-_patrolBoxHorizontalBorder, -_patrolBoxVerticalBorder), transform.position + new Vector3(-_patrolBoxHorizontalBorder, _patrolBoxVerticalBorder), Color.blue);
        Debug.DrawLine(transform.position + new Vector3(_patrolBoxHorizontalBorder, -_patrolBoxVerticalBorder), transform.position + new Vector3(_patrolBoxHorizontalBorder, _patrolBoxVerticalBorder), Color.blue);
    }

    public void SaveSpawnPosition(Vector3 pos) => _spawnPosition = pos;

    private Vector3 GetNewPatrolPosition()
    {
        Vector3 newPosition = Vector3.zero;
        newPosition.x = Random.Range(-_patrolBoxHorizontalBorder, _patrolBoxHorizontalBorder);
        newPosition.x = Random.Range(-_patrolBoxVerticalBorder, _patrolBoxVerticalBorder);
        return newPosition;
    }
}

