using OnScreenPointerPlugin;
using UnityEngine;
using YG;

public class Tutorial : MonoBehaviour
{
    [SerializeField] MinigameActivator _bakery;
    [SerializeField] private OnScreenPointerObject _object;
    [SerializeField] private GameObject _pointerContainer;

    private void Awake()
    {
        if (YandexGame.savesData.tutorialIsEnded)
        {
            OnBakeryActivated();
        }
    }

    private void OnEnable()
    {
        _bakery.BakeryActivated += OnBakeryActivated;
    }

    private void OnDisable()
    {
        _bakery.BakeryActivated -= OnBakeryActivated;
    }

    private void OnBakeryActivated()
    {
        if (!YandexGame.savesData.tutorialIsEnded)
        {
            YandexGame.savesData.tutorialIsEnded = true;
            YandexGame.SaveProgress();
        }

        _bakery.BakeryActivated -= OnBakeryActivated;
        _object.enabled = false;
        Destroy(_pointerContainer);
    }
}
