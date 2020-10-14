using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float damage;
    [SerializeField] float speed;
    [SerializeField] AggroRange aggroRange;

    private Vector3 _startingPosition;

    private void Awake()
    {
        _startingPosition = transform.position;
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
        if (position == transform.position)
            return;

        Vector3 direction = position - transform.position;

        transform.Translate(direction.normalized * Time.deltaTime * speed);
    }
}
