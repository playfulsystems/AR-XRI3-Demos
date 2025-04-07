using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchPlane : MonoBehaviour, IPointerDownHandler
{
    public Material StandardMaterial;
    public Material HighlightMaterial;
    public MeshRenderer MeshRenderer;
    public UnityEvent TouchComplete;
    bool isHighlighted = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isHighlighted)
        {
            SetHighlighted(false);
            TouchComplete.Invoke();            
        }
    }

    public void SetHighlighted(bool highlighted)
    {
        if (highlighted)
        {
            MeshRenderer.material = HighlightMaterial;
        }
        else
        {
            MeshRenderer.material = StandardMaterial;
        }
        isHighlighted = highlighted;
    }
}
