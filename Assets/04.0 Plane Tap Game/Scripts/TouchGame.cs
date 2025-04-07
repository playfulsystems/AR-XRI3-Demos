using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TouchGame : MonoBehaviour
{
    public TouchPlane[] TouchPlanes;

    private void Start()
    {
        SetRandomPlaneHighlight();
    }

    public void SetRandomPlaneHighlight()
    {
        int randomIndex = Random.Range(0, TouchPlanes.Length);
        TouchPlanes[randomIndex].SetHighlighted(true);
        
    }
}
