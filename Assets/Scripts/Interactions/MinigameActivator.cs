using UnityEngine;
using UnityEngine.InputSystem;

public class MinigameActivator : Interactable
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private CanvasGroup _minigame;
    [SerializeField] private GoodCreator _creator;

    public override void Interact()
    {
        _minigame.alpha = 1;
        _minigame.interactable = true;
        _minigame.blocksRaycasts = true;
        Cursor.lockState = CursorLockMode.None;
        _input.enabled = false;
        _creator.CreateGoods();
    }
}
