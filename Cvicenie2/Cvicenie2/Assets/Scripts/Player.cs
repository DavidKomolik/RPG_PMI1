﻿using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] MeleeRange meleeRange;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Movement();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.transform.CompareTag("Enemy"))
                {
                    ShootProjectile(hitInfo.point);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
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

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 moveDirection = new Vector3(0, 0, 1); // smer pohybu
            transform.Translate(moveDirection * speed); // zmena transformácie (pozície) objektu hráča vzhľadom na smer pohybu
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 moveDirection = new Vector3(0, 0, -1);
            transform.Translate(moveDirection * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 moveDirection = new Vector3(-1, 0, 0);
            transform.Translate(moveDirection * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 moveDirection = new Vector3(1, 0, 0);
            transform.Translate(moveDirection * speed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Vector3 moveDirection = new Vector3(0, 1, 0);
            transform.Rotate(moveDirection);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 moveDirection = new Vector3(0, -1, 0);
            transform.Rotate(moveDirection);
        }
    }

    private void ShootProjectile(Vector3 position)
    {
        Debug.Log("Shooting projectile at enemy position");

        var projectileObject = Instantiate(projectilePrefab);

        projectileObject.transform.position = transform.position;

        var direction = position - transform.position;
        var travelDistance = Vector3.Distance(position, transform.position);

        projectileObject.GetComponent<Projectile>().Shoot(direction.normalized, travelDistance);
    }

    private void AttackEnemy(Enemy enemy)
    {
        Debug.Log("Attacking enemy with melee attack");
        enemy.TakeDamage(damage);
    }
}
