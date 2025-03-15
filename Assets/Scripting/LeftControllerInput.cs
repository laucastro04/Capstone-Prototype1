using UnityEngine;
using UnityEngine.InputSystem;

public class LeftControllerInput : MonoBehaviour
{
    public InputActionAsset inputActions; // Assign XRInputActions in Inspector
    public string actionMapName = "XRControllerActions"; // Your Action Map name
    public string actionName = "SpawnBookAction"; // Your Action name
    public GameObject vrBookObject; // Assign the VRBook object in the scene
    private InputAction spawnBookAction;

    private void OnEnable()
    {
        // Find the correct action inside the Action Map
        var actionMap = inputActions.FindActionMap(actionMapName);
        if (actionMap != null)
        {
            spawnBookAction = actionMap.FindAction(actionName);
            if (spawnBookAction != null)
            {
                spawnBookAction.performed += ToggleBook;
                spawnBookAction.Enable();
            }
            else
            {
                Debug.LogError($"Action '{actionName}' not found in Action Map '{actionMapName}'");
            }
        }
        else
        {
            Debug.LogError($"Action Map '{actionMapName}' not found in Input Actions");
        }
    }

    private void OnDisable()
    {
        if (spawnBookAction != null)
        {
            spawnBookAction.performed -= ToggleBook;
            spawnBookAction.Disable();
        }
    }

    private void ToggleBook(InputAction.CallbackContext context)
    {
        if (vrBookObject != null)
        {
            vrBookObject.SetActive(!vrBookObject.activeSelf); // Toggle visibility
        }
        else
        {
            Debug.LogError("VR Book Object is not assigned in the Inspector!");
        }
    }
}