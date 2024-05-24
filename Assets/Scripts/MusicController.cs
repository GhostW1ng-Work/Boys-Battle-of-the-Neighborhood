using UnityEngine;
using YG;

public class MusicController : MonoBehaviour
{
    [SerializeField] private WinPanelShower _win;
    [SerializeField] private AudioClip _calmMusic;
    [SerializeField] private AudioClip _battleMusic;
    [SerializeField] private AudioClip _winMusic;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PlayerSetter.FightStarted += OnFightStarted;
        PlayerSetter.FightEnded += OnFightEnded;
        _win.Winned += OnWinned;
    }

    private void OnDisable()
    {
        PlayerSetter.FightStarted -= OnFightStarted;
        PlayerSetter.FightEnded -= OnFightEnded;
        _win.Winned -= OnWinned;
    }

    private void OnWinned()
    {
        _audioSource.Stop();
        _audioSource.clip = _winMusic;
        _audioSource.Play();
        _audioSource.loop = true;
    }

    private void OnFightStarted()
    {
        _audioSource.Stop();
        _audioSource.clip = _battleMusic;
        _audioSource.Play();
        _audioSource.loop = true;
    }

    private void OnFightEnded()
    {
        _audioSource.Stop();
        _audioSource.clip = _calmMusic;
        _audioSource.Play();
        _audioSource.loop = true;
    }

    private void Start()
    {
        if (YandexGame.savesData.isWin)
        {
            OnWinned();
        }
        else
        {
            OnFightEnded();
        }
    }
}
