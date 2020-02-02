using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseEnemy : MonoBehaviour, IDamagable
{

    [Header("Components")]
    [SerializeField] private Rigidbody2D _rigidbody2d;


    [SerializeField] private EnemyState _previousState;
    [SerializeField] private EnemyState _currentState;
    public EnemyState CurrentState
    {
        get { return _currentState; }
        set { _previousState = _currentState; _currentState = value; }
    }

    public GameObject attackTarget;

    public float Health;
    [SerializeField] private float health;

    public float changeDirectionTimer;
    public float tempChangeDirectionTimer;

    public float moveSpeed;
    public float chaseRadius;
    public float attackRadius;

    Vector2 targetDirection;

    public float fireRate;
    public float tempFireRate;

    #region UNITY FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        targetDirection = attackTarget.transform.position - transform.position;

        //Check for the target
        if (targetDirection.sqrMagnitude < chaseRadius * chaseRadius && _currentState != EnemyState.ATTACK)
        {

            Debug.Log("Player is in chase radius! ");
            _currentState = EnemyState.CHASE;
            // Player is in chase radius
            // Chase the player
        }
        else
        {
            RevertEnemyState();
        }

        if (targetDirection.sqrMagnitude < attackRadius * attackRadius)
        {
            _currentState = EnemyState.ATTACK;
        }
        else { RevertEnemyState(); }

        if(_currentState == EnemyState.PATROL)
        {
            //Patrol
        }
        
        if(_currentState == EnemyState.ATTACK)
        {
            if (tempFireRate <= 0)
            {
                //Attack
                tempFireRate = fireRate;
            }
            else
            {
                tempFireRate -= Time.deltaTime;
            }
        }


    }

    private void FixedUpdate()
    {
        if (_currentState == EnemyState.CHASE)
        {
            //Move towards the target

        }

    }

    private void OnDisable()
    {
        //Reset Health
        health = Health;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Damage"))
        {
            // Take Damage
            OnPlayerContact();
            TakeDamage(other.GetComponent<Damage>().GetDamage());
        }

    }

    #endregion

    private void RevertEnemyState() { _currentState = _previousState; }

    protected virtual void OnPlayerContact()
    {

    }

    #region INTERFACES

    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    #endregion



}
