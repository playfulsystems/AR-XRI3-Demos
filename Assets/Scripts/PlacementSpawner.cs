using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PlacementSpawner : MonoBehaviour
{
    public InputActionReference TapAction;
    public XRRayInteractor ARInteractor;
    public GameObject PrefabToPlace;
    public Camera camera;

    void OnEnable()
    {
        TapAction.action.Enable();
        TapAction.action.performed += OnTapDetected;
    }

    void OnDisable()
    {
        TapAction.action.Disable();
        TapAction.action.performed += OnTapDetected;
    }
    
    private void OnTapDetected(InputAction.CallbackContext context)
    {
        if (ARInteractor.logicalSelectState.active) return;
            
        StartCoroutine(DelayedTap());
    }

    IEnumerator DelayedTap()
    {
        yield return null; 
        
        // gotta be -1 to count touch and mouse
        var isPointerOverUI = EventSystem.current.IsPointerOverGameObject(-1);
        if (!isPointerOverUI && ARInteractor.TryGetCurrentARRaycastHit(out var arRaycastHit))
        {
            
            // check to see if what you hit is a plane
            if (arRaycastHit.trackable is ARPlane)
            {
                // set position
                GameObject spawnedObject = Instantiate(PrefabToPlace);
                Vector3 spawnPoint = arRaycastHit.pose.position;
                spawnedObject.transform.position = spawnPoint;
                
                // set rotation (simple)
                var facePosition = camera.transform.position;
                var directionToCamera = facePosition - spawnPoint;
                directionToCamera.y = 0;  // Ensures the object stays level (ignoring vertical direction)

                spawnedObject.transform.rotation = Quaternion.LookRotation(directionToCamera);
            }
        }

        
    }
}
