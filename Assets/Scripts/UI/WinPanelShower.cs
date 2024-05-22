using UnityEngine;
using YG;

public class WinPanelShower : MonoBehaviour
{
    [SerializeField] private int _enemiesCount;

    private CanvasGroup _canvasGroup;
    private int _currentDiedEnemies = 0;

    private void OnEnable()
    {
        Enemy.AnyEnemyDied += OnAnyEnemyDied;
    }

    private void OnDisable()
    {
        Enemy.AnyEnemyDied -= OnAnyEnemyDied;
    }

    private void OnAnyEnemyDied()
    {
        _currentDiedEnemies++;
        YandexGame.savesData.deadEnemiesCount++;

        if(_currentDiedEnemies >= _enemiesCount)
        {
            YandexGame.savesData.isWin = true;
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
        YandexGame.SaveProgress();
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _currentDiedEnemies = YandexGame.savesData.deadEnemiesCount;
        if(YandexGame.savesData.isWin == false)
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
        else
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}
