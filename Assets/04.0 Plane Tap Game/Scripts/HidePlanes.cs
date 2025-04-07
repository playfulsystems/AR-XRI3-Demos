using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class HidePlanes : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;

    public void HideAllPlanes()
    {
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }
}
