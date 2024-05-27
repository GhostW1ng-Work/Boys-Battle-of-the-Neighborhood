using UnityEngine;
using YG;

public class MobileInputController : MonoBehaviour
{
    [SerializeField] private WinPanelShower _win;

    private void Start()
    {
        if (YandexGame.EnvironmentData.isMobile)
        {
            MinigameActivator.MinigameActivated += OnActivated;
            ClosePanelButton.MinigameClosed += OnClosed;
            OpenMarket.MarketOpened += OnActivated;
            CloseMarket.MarketClosed += OnClosed;
            _win.Winned += OnWinned;
        }
        else
        {
            OnActivated();
        }
    }

    public void OnWinned()
    {
        gameObject.SetActive(false);
        MinigameActivator.MinigameActivated -= OnActivated;
        ClosePanelButton.MinigameClosed -= OnClosed;
        OpenMarket.MarketOpened -= OnActivated;
        CloseMarket.MarketClosed -= OnClosed;
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
