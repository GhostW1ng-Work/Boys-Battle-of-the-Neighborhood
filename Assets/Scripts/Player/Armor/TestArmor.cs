using UnityEngine;

public class TestArmor : MonoBehaviour
{
    [SerializeField] private ArmorHandler _armorHandler;
    [SerializeField] private Armor _head;
    [SerializeField] private Armor _secondHead;
    [SerializeField] private KeyCode _key1;
    [SerializeField] private KeyCode _key2;

    private void Update()
    {
        if (Input.GetKeyDown(_key1  ))
        {
                _armorHandler.SetArmor(_head);
                print(_armorHandler.GetArmorLevel().ToString());
        }
        if (Input.GetKeyDown(_key2))
        {
            _armorHandler.SetArmor(_secondHead);
            print(_armorHandler.GetArmorLevel().ToString());
        }
    }
}
