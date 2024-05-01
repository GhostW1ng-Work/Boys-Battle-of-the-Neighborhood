using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine;
using YG;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _interactionLayer;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, _range, _interactionLayer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.TryGetComponent(out Interactable interactable))
                {
                    interactable.Interact();
                }
            }

        }
    }
}