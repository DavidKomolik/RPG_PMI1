using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject bodies;

    private bool _isMenuActive = false;

    void Start()
    {
        bool firstActive = false;
        foreach (Transform child in bodies.transform)
        {
            if (firstActive == false)
            {
                child.gameObject.SetActive(true);
                firstActive = true;
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        _isMenuActive = !_isMenuActive;

        menu.SetActive(_isMenuActive);
    }

    public void ShowBody(GameObject bodyObject)
    {
        if (bodyObject == null)
            return;

        if (bodyObject.transform.IsChildOf(bodies.transform) == false)
            return;

        foreach (Transform child in bodies.transform)
        {
            if (child.gameObject == bodyObject)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
