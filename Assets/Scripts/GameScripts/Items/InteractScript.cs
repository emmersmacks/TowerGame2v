using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    IInteractableObject interactableObject;
    bool canInteract = false;

    private void Start()
    {
        interactableObject = GetComponent<IInteractableObject>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && canInteract)
            interactableObject.InteractActionStart();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canInteract = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract= false;
    }
}
