using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] GameObject bodyObject;

    private UIController _uiController;

    private void Start()
    {
        _uiController = GetComponentInParent<UIController>();
    }

    public void ShowBody()
    {
        _uiController.ShowBody(bodyObject);
    }
}
