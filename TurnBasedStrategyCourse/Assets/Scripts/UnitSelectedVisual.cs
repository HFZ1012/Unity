using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Unit unit;

    private MeshRenderer meshRenderer; // MeshRenderer component of the unit;

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>(); // Get the MeshRenderer component of the unit;
    }

    private void Start() {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged; // Subscribe to the OnSelectedUnitChanged event;
        UpdateVisual(); // Update the visual of the unit;
    }

    private void UnitActionSystem_OnSelectedUnitChanged(object sender, System.EventArgs empty)  // Method to handle the OnSelectedUnitChanged event;
    {
       UpdateVisual(); // Update the visual of the unit;
    }

    private void UpdateVisual() 
    { // Method to update the visual of the unit;
        if(UnitActionSystem.Instance.GetSelectedUnit() == unit) // If the selected unit is this unit;
        {
            meshRenderer.enabled = true; // Enable the mesh renderer;
        } else {
            meshRenderer.enabled = false; // Disable the mesh renderer;
        }
    }
}
