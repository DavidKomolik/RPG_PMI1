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
    [SerializeField] Animator enemyAnimator;

    private Vector3 _startingPosition;
    private NavMeshAgent _agent;

    private float _maxHealth;
    private bool _isDead;

    private void Awake()
    {
        _startingPosition = transform.position;
        _agent = GetComponent<NavMeshAgent>();

        _maxHealth = health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / _maxHealth;

        if (health <= 0)
        {
            OnDeath();
        }
    }

    private void Update()
    {
        if (_isDead)
            return;

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

    private void OnDeath()
    {
        _isDead = true;

        //disable movement
        _agent.enabled = false;

        //disable player interaction IGNORE RAYCAST = 2
        gameObject.layer = 2;

        enemyAnimator.Play("Death");

        Destroy(gameObject, 1f);
    }
}
