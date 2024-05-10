using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private PlayerHealth _player;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.CurrentHealth;
    }

    private void Update()
    {
        _slider.value = Mathf.Lerp(_slider.value, _player.CurrentHealth, _duration);
    }
}
