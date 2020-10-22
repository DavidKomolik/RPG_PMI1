using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float damage;
    [SerializeField] float speed;
    [SerializeField] AggroRange aggroRange;

    private Vector3 _startingPosition;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _startingPosition = transform.position;
        _agent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health > 0)
        {
            Debug.Log($"Taken { damage } damage, remaining health: { health }");
        }
        else
        {
            Debug.Log("Enemy died");
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
