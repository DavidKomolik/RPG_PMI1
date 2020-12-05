using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] Image healthBar;
    [SerializeField] float damage;
    [SerializeField] float speed;
    [SerializeField] AggroRange aggroRange;

    private Vector3 _startingPosition;
    private NavMeshAgent _agent;

    private float _maxHealth;

    private void Awake()
    {
        _startingPosition = transform.position;
        _agent = GetComponent<NavMeshAgent>();

        _maxHealth = health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health > 0)
        {
            healthBar.fillAmount = health / _maxHealth;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (aggroRange.PlayerObject != null)
        {
            MoveToPosition(aggroRange.PlayerObject.transform.position);
        }
        else
        {
            MoveToPosition(_startingPosition);
        }
    }

    private void MoveToPosition(Vector3 position)
    {
        if (position == transform.position ||  position == _agent.destination)
            return;

        _agent.SetDestination(position);
    }
}
