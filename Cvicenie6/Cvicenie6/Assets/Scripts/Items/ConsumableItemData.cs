using UnityEngine;

[CreateAssetMenu(fileName = "New Comsumable Item Data", menuName = "Items/Consumable Item Data")]
public class ConsumableItemData : ItemData
{
    [SerializeField] int healthToRestore;

    public int HealthToRestore => healthToRestore;
}