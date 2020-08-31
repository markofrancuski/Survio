using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{

    [SerializeField] protected AIState _currentState;

    [SerializeField] protected float AttackRadius;
    [SerializeField] protected float ChaseRadius;

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

    protected virtual void Update()
    {
        // Chase Radius
        Debug.DrawLine(transform.position, transform.position + new Vector3(0 , ChaseRadius, 0), Color.red);
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, -ChaseRadius, 0), Color.red);
        Debug.DrawLine(transform.position, transform.position + new Vector3(ChaseRadius, 0, 0), Color.red);
        Debug.DrawLine(transform.position, transform.position + new Vector3(-ChaseRadius, 0, 0), Color.red);

        // Attack Radius
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, AttackRadius, 0), Color.yellow);
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, -AttackRadius, 0), Color.yellow);
        Debug.DrawLine(transform.position, transform.position + new Vector3(AttackRadius, 0, 0), Color.yellow);
        Debug.DrawLine(transform.position, transform.position + new Vector3(-AttackRadius, 0, 0), Color.yellow);

    }
}
