using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TouchGame : MonoBehaviour
{
    public TouchPlane[] TouchPlanes;
    private int currentHighlighted = -1;
    
    private void Start()
    {
        SetRandomPlaneHighlight();
    }

    public void SetRandomPlaneHighlight()
    {
        int randomIndex = Random.Range(0, TouchPlanes.Length);
        
        // try again if same
        if (currentHighlighted == randomIndex)
        {
            SetRandomPlaneHighlight();
            return;
        } 
            
        TouchPlanes[randomIndex].SetHighlighted(true);
        currentHighlighted = randomIndex;
        
    }
}
