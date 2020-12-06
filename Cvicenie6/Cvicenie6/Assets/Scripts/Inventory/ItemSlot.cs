using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] GameObject item;

    private Image _itemImage;

    public Sprite ItemSprite => _itemImage.sprite;
    public bool IsEmpty => item.activeSelf == false;

    public int ItemSlotID { get; set; } = 0;
    public ObjectsInventory ObjectsInventory { get; set; }

    private void Awake()
    {
        _itemImage = item.GetComponent<Image>();
    }

    public void ChangeAndShowItem(Sprite sprite)
    {
        _itemImage.sprite = sprite;
        ShowItem();
    }

    public void ShowItem()
    {
        item.SetActive(true);
    }

    public void HideItem()
    {
        item.SetActive(false);
    }
}
