﻿using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float damage;
    [SerializeField] float rangeAttackDelay;
    [SerializeField] float meleeAttackDelay;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] MeleeRange meleeRange;
    [SerializeField] GameObject destinationIndicator;

    private Camera _camera;
    private NavMeshAgent _agent;

    private float rangeAttackTimer;
    private float meleeAttackTimer;

    private void Awake()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();

        destinationIndicator = Instantiate(destinationIndicator);
        destinationIndicator.SetActive(false);
    }

    void Update()
    {
        rangeAttackTimer -= Time.deltaTime;
        meleeAttackTimer -= Time.deltaTime;

        if (_agent.remainingDistance == 0)
        {
            destinationIndicator.SetActive(false);
        }

        // Vystrelenie projektilu + pohyb
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.transform.CompareTag("Enemy"))
                {
                    ShootProjectile(hitInfo.point);
                }
                {
                    MoveToPosition(hitInfo.point);
                }
            }
        }

        // Melee utok na blizko
        if (Input.GetMouseButton(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.transform.CompareTag("Enemy"))
                {
                    var enemy = hitInfo.transform.GetComponent<Enemy>();

                    if (meleeRange.IsEnemyInRange(enemy))
                    {
                        AttackEnemy(enemy);
                    }
                }
            }
        }
    }

    private void MoveToPosition(Vector3 position)
    {
        if (destinationIndicator.activeSelf == false)
            destinationIndicator.SetActive(true);

        _agent.SetDestination(position);

        destinationIndicator.transform.position = _agent.destination;
    }

    private void ShootProjectile(Vector3 position)
    {
        if (rangeAttackTimer > 0)
            return;

        rangeAttackTimer = rangeAttackDelay;

        Debug.Log("Shooting projectile at enemy position");

        var projectileObject = Instantiate(projectilePrefab);

        projectileObject.transform.position = transform.position;

        var direction = position - transform.position;
        var travelDistance = Vector3.Distance(position, transform.position);

        projectileObject.GetComponent<Projectile>().Shoot(direction.normalized, travelDistance);
    }

    private void AttackEnemy(Enemy enemy)
    {
        if (meleeAttackTimer > 0)
            return;

        meleeAttackTimer = meleeAttackDelay;

        Debug.Log("Attacking enemy with melee attack");
        enemy.TakeDamage(damage);
    }
}
