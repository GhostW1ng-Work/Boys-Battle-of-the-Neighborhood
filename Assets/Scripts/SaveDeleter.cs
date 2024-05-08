using UnityEngine;

public class SaveDeleter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
