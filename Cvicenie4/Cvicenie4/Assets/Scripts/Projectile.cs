using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float overshootDistance;

    private Vector3 _startingPosition;
    private float _maxTravelDistance;

    public void Shoot(Vector3 direction, float travelDistance)
    {
        _startingPosition = transform.position;

        _maxTravelDistance = travelDistance + overshootDistance;

        GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _startingPosition) > _maxTravelDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
