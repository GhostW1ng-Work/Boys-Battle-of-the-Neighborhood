using UnityEngine;
using UnityEngine.UI;
using YG;

public class MobileInteractButton : MonoBehaviour
{
    private Interactable _interactable;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        if(YandexGame.EnvironmentData.isDesktop)
            gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        _interactable.Interact();
    }

    public void SetInteractable(Interactable interactable)
    {
        _interactable = interactable;
    }
}
