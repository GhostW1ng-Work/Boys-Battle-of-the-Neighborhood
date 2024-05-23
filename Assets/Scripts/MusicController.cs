using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip _calmMusic;
    [SerializeField] private AudioClip _battleMusic;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PlayerSetter.FightStarted += OnFightStarted;
        PlayerSetter.FightEnded += OnFightEnded;

    }

    private void OnDisable()
    {
        PlayerSetter.FightStarted -= OnFightStarted;
        PlayerSetter.FightEnded -= OnFightEnded;
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
        OnFightEnded();
    }
}
