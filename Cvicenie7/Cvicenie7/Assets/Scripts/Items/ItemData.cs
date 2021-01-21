using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Items/General Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] new string name;
    [SerializeField] string description;
    [SerializeField] int price;
    [SerializeField] Sprite sprite;

    public string Name => name;
    public string Description => description;
    public int Price => price;
    public Sprite Sprite => sprite;
}
