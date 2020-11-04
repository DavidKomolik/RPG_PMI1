using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] InteractionRange interactionRange;

    private void OnMouseDown()
    {
        if (interactionRange.IsPlayerInRange)
        {
            Debug.Log("Chest opened");
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
