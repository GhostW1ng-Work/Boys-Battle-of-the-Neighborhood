using UnityEngine;
using YG;

public class MobileInputController : MonoBehaviour
{
    private void Start()
    {
        if (YandexGame.EnvironmentData.isMobile)
        {
            MinigameActivator.MinigameActivated += OnActivated;
            ClosePanelButton.MinigameClosed += OnClosed;
            OpenMarket.MarketOpened += OnActivated;
            CloseMarket.MarketClosed += OnClosed;
        }
        else
        {
            OnActivated();
        }
    }

    private void OnActivated()
    {
        gameObject.SetActive(false);
    }

    private void OnClosed()
    {
        gameObject.SetActive(true);
    }
}
