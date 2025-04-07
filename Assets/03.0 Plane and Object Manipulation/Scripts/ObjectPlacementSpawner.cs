using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Utilities;

public class ObjectPlacementSpawner : MonoBehaviour
{
    public XRRayInteractor ARInteractor;
    public GameObject SpawnObjectPrefab;
    public XRInputButtonReader SpawnObjectInput;
    public UnityEvent ObjectPlaced;
    
    Camera cameraToFace;
    bool attemptSpawn;
    bool everHadSelection;

    void Awake()
    {
        cameraToFace = Camera.main;
    }

    void OnEnable()
    {
        SpawnObjectInput.EnableDirectActionIfModeUsed();
    }

    void OnDisable()
    {
        SpawnObjectInput.DisableDirectActionIfModeUsed();
    }

    void Update()
    {
        // Wait a frame after the Spawn Object input is triggered to actually cast against AR planes and spawn
        // in order to ensure the touchscreen gestures have finished processing to allow the ray pose driver
        // to update the pose based on the touch position of the gestures.
        if (attemptSpawn)
        {
            attemptSpawn = false;
    
            // Don't spawn the object if the tap was over screen space UI.
            var isPointerOverUI = EventSystem.current.IsPointerOverGameObject(-1);
            if (!isPointerOverUI && ARInteractor.TryGetCurrentARRaycastHit(out var arRaycastHit))
            {
                if (!(arRaycastHit.trackable is ARPlane arPlane))
                    return;
    
                SpawnObject(arRaycastHit.pose.position, arPlane.normal);
            }
    
            return;
        }
        
        // ensures that when selecting, you don't spawn more
        // note: select is different from focus, which is used for the highlight state
        // hasSelection is only true when dragging an object around, rotating it, etc...
        var selectState = ARInteractor.logicalSelectState;
        if (selectState.wasPerformedThisFrame)
            everHadSelection = ARInteractor.hasSelection;
    
        attemptSpawn = false;
        if (selectState.wasCompletedThisFrame)
            attemptSpawn = !everHadSelection;
    }
    
    
    public void SpawnObject(Vector3 spawnPoint, Vector3 spawnNormal)
    {
        // place and position spawn
        var newObject = Instantiate(SpawnObjectPrefab);
        newObject.transform.position = spawnPoint;

        // turn object to face camera
        var facePosition = cameraToFace.transform.position;
        var forward = facePosition - spawnPoint;
        BurstMathUtility.ProjectOnPlane(forward, spawnNormal, out var projectedForward);
        newObject.transform.rotation = Quaternion.LookRotation(projectedForward, spawnNormal);

        // call an event that you've placed an object 
        ObjectPlaced.Invoke();
    }
}


