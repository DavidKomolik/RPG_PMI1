using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float damage;

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
}
