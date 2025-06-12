using System; // For event handlin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; } // Singleton instance of the UnitActionSystem class;

    public event EventHandler OnSelectedUnitChanged; // Event to notify when the selected unit changes;

    [SerializeField] private Unit selectedUnit; // Reference to the currently selected unit;
    [SerializeField] private LayerMask unitLayerMask; // Layer mask to identify units;

    private bool isBusy; // Flag to indicate if the action system is busy;


    private void Awake() // Awake is called when the script instance is being loaded;
    {
        if(Instance != null) // If there is already an instance of the UnitActionSystem class;
        {
            Debug.LogError("There is more than one UnitActionSystem! " + transform + " - " + Instance); // Log an error;
            Destroy(gameObject); // Destroy this instance;
            return; // Exit the method;
        }
        Instance = this; // Set the singleton instance to this instance;
    }

    private void Update()
    {
        if(isBusy) return; // If the action system is busy;
        if(Input.GetMouseButtonDown(0))
        {
            if(TryHandleUnitSelected()) return;// Handle the selection of the unit;

            GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetPosition()); // Get the grid position of the mouse;

            if(selectedUnit.GetMoveAction().IsValidActionGridPosition(mouseGridPosition)) // Check if the grid position is valid;
            {
                SetBusy(); // Set the action system to busy;
                selectedUnit.GetMoveAction().Move(mouseGridPosition,ClearBusy); // Move the unit to the grid position;
            }
        }

        if(Input.GetMouseButtonDown(1)) // If the right mouse button is pressed;         
        {
            SetBusy(); // Set the action system to busy;
            selectedUnit.GetSpinAction().Spin(ClearBusy); // Spin the unit;
        }
    }

    public void SetBusy() // Set the action system to busy;
    {
        isBusy = true; // Set the isBusy flag to true;
    }

    public void ClearBusy() // Clear the action system from busy;
    {
        isBusy = false; // Set the isBusy flag to false;
    }

    private bool TryHandleUnitSelected()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Get the ray from the camera to the mouse position;
        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue,unitLayerMask)) 
        {
            if(raycastHit.transform.TryGetComponent<Unit>(out Unit unit)) // Get the unit component from the hit object;
            {
                SetSelectedUnit(unit); // Set the selected unit to the hit unit;
                return true; // Return true if a unit is selected;
            }
        }
        return false; // Return false if no unit is selected;
    }

    private void SetSelectedUnit(Unit unit) // Set the selected unit;
    {
        selectedUnit = unit; // Set the selected unit to the given unit;
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty); // Notify the listeners that the selected unit has changed;
    }

    public Unit GetSelectedUnit() // Get the selected unit;
    {
        return selectedUnit; // Return the selected unit;
    }
}
