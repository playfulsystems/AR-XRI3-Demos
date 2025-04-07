using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

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
    
    // void Awake()
    // {
    //     var interactable = GetComponent<XRGrabInteractable>();
    //     interactable.selectEntered.AddListener(OnSelectEntered);
    // }
    //
    // private void OnSelectEntered(SelectEnterEventArgs args)
    // {
    //     Debug.Log(gameObject.name + " was tapped!");
    //     MeshRenderer.material = HighlightMaterial;
    // }
}
