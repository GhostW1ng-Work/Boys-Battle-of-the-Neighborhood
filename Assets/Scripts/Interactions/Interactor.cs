using UnityEngine;
using YG;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _interactionLayer;
    [SerializeField] private CanvasGroup _interactionText;
    [SerializeField] private MobileInteractButton _interactionMobileButton;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, _range, _interactionLayer))
        {
            if (YandexGame.EnvironmentData.isMobile)
            {
                EnableButton();
                _interactionMobileButton.SetInteractable(hit.collider.gameObject.GetComponent<Interactable>());
            }
            else
            {
                _interactionText.alpha = 1;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.collider.TryGetComponent(out Interactable interactable))
                    {
                        interactable.Interact();
                    }
                }
            }
        }
        else
        {
            if (YandexGame.EnvironmentData.isMobile)
            {
                DisableButton();
                _interactionMobileButton.SetInteractable(null);
            }
            else
                _interactionText.alpha = 0;
        }
    }

    private void EnableButton()
    {
        CanvasGroup interactGroup = _interactionMobileButton.GetComponent<CanvasGroup>();
        interactGroup.alpha = 1;
        interactGroup.blocksRaycasts = true;
        interactGroup.interactable = true;
    }

    private void DisableButton()
    {
        CanvasGroup interactGroup = _interactionMobileButton.GetComponent<CanvasGroup>();
        interactGroup.alpha = 0;
        interactGroup.blocksRaycasts = false;
        interactGroup.interactable = false;
    }
}