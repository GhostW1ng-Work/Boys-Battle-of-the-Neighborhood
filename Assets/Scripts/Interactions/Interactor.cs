using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine;
using YG;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _interactionLayer;

    private Interactable _taking = null;


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
                    if (interactable.IsTaking)
                    {
                        _taking = interactable;
                    }
                }
            }

        }
        if (Input.GetKeyUp(KeyCode.E) && _taking != null)
        {
            _taking.Interact();
            _taking = null;
        }
    }
}