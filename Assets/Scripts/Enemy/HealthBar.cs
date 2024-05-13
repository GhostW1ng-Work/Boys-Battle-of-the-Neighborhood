using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private TMP_Text _healthText;

    private Enemy _enemy;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        _slider.value = Mathf.Lerp(_slider.value, _enemy.CurrentHealth, _duration);
        _healthText.text = _enemy.CurrentHealth + "/" + _enemy.MaxHealth;
    }

    public void EnableBar(Enemy enemy)
    {
        _enemy = enemy;
        gameObject.SetActive(true);
        _slider.maxValue = enemy.MaxHealth;
        _slider.value = enemy.CurrentHealth;
    }
}
