using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class RestartButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Restart);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Restart);
    }

    private void Restart()
    {
        YandexGame.ResetSaveProgress();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
