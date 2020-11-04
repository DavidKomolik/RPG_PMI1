using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] InteractionRange interactionRange;

    private void OnMouseDown()
    {
        if (interactionRange.IsPlayerInRange)
        {
            Debug.Log("Player interaction");
        }
    }
}