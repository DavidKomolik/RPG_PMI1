using System.Collections.Generic;
using UnityEngine;

public class MeleeRange : MonoBehaviour
{
    private List<Enemy> _enemiesInRange;

    private void Awake()
    {
        _enemiesInRange = new List<Enemy>();
    }

    public bool IsEnemyInRange(Enemy enemy)
    {
        return _enemiesInRange.Contains(enemy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy entered melee range");
            _enemiesInRange.Add(other.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy left melee range");
            _enemiesInRange.Remove(other.GetComponent<Enemy>());
        }
    }
}
