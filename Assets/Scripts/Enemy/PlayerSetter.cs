using Cinemachine;
using StarterAssets;
using System;
using System.Collections;
using UnityEngine;

public class PlayerSetter : Interactable
{
    [SerializeField] private PlayerAttacker _player;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private ThirdPersonController _controller;
    [SerializeField] private Camera _camera;
    [SerializeField] private CinemachineBrain _brain;
    [SerializeField] private Transform _playerNewPosition;
    [SerializeField] private Transform _cameraNewPosition;

    private bool _playerIsStay = false;
    private Enemy _enemy;

    public event Action PlayerLosed;

    public bool PlayerIsStay => _playerIsStay;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _playerHealth.PlayerDied += OnPlayerDied;
        _enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        _playerHealth.PlayerDied -= OnPlayerDied;
        _enemy.Died -= OnDied;
    }



    public override void Interact()
    {
        if (!_playerIsStay)
        {
            _healthBar.EnableBar(_enemy);
            _playerIsStay = true;
            StartCoroutine(SetPlayer());
            _brain.enabled = false;
            _camera.transform.position = _cameraNewPosition.position;
            _camera.transform.LookAt(transform.position);
        }
        else
        {
            _healthBar.gameObject.SetActive(false);
            _playerIsStay = false;
            _brain.enabled = true;
            _player.SetTarget(null);
            _player.SetInput(true);
        }
    }

    private void OnPlayerDied()
    {
        _healthBar.gameObject.SetActive(false);
        PlayerLosed?.Invoke();
        _playerIsStay = false;
        _brain.enabled = true;
        _player.SetTarget(null);
        _player.SetInput(true);
    }

    private void OnDied()
    {
        _healthBar.gameObject.SetActive(false);
        _playerIsStay = false;
        _brain.enabled = true;
        _player.SetTarget(null);
        _player.SetInput(true);
    }

    private IEnumerator SetPlayer()
    {
        _player.SetInput(false);
        _player.SetTarget(_enemy);
        _controller.enabled = false;
        yield return new WaitForSeconds(0.1f);
        _player.transform.position = _playerNewPosition.position;
        _player.transform.LookAt(transform.position);
        yield return new WaitForSeconds(0.1f);
        _controller.enabled = true;
    }
}
