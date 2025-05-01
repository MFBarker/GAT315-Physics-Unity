using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableObject : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] public InputActionReference interactInput;
    [SerializeField] public EventChannelSO interactEvent;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (interactInput.action.IsPressed() && interactInput.action.WasPressedThisFrame())
        {
            interactEvent.Raise();
        }
    }
}
