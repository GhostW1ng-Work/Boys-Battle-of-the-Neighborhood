using UnityEngine;
using YG;

public class DeviceChecker : MonoBehaviour
{
    [SerializeField] private CanvasGroup _mobileUI;

    private void Start()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {
            _mobileUI.alpha = 0;
            _mobileUI.blocksRaycasts = false;
            _mobileUI.interactable = false;
        }
    }
}
