using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{

    public static LevelGrid Instance { get; private set; } // Singleton instance of the UnitActionSystem class;

    [SerializeField] private Transform gridDebugObjectPrefab; // Reference to the debug prefab;

    private GridSystem gridSystem;

    private void Awake() // Awake is called when the script instance is being loaded;
    {
        if(Instance != null) // If there is already an instance of the UnitActionSystem class;
        {
            Debug.LogError("There is more than one UnitActionSystem! " + transform + " - " + Instance); // Log an error;
            Destroy(gameObject); // Destroy this instance;
            return; // Exit the method;
        }
        Instance = this; // Set the singleton instance to this instance;

        gridSystem = new GridSystem(10, 10, 2f); // Create a new grid system;
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab); // Create debug objects;
    }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit) // Set the unit at the grid position;
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition); // Get the grid object at the grid position;
        gridObject.AddUnit(unit); // Set the unit at the grid position;
    }
    
    public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition) // Get the unit at the grid position;
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition); // Get the grid object at the grid position;
        return gridObject.GetUnitList(); // 返回网格对象的单位列表
    }

    public void RemoveUnitAtGridPosition(GridPosition gridPosition,Unit unit) // Clear the unit at the grid position;
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition); // Get the grid object at the grid position;
        gridObject.RemoveUnit(unit); // Clear the unit at the grid position;
    }

    public void UnitMovedGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition) // Unit moved grid position;
    {
        RemoveUnitAtGridPosition(fromGridPosition, unit); // Clear the unit at the from grid position;
        AddUnitAtGridPosition(toGridPosition, unit); // Set the unit at the to grid position;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition); // Get the grid position from the world position;

    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition); // Get the grid position from the world position;

    public bool IsValidGridPosition(GridPosition gridPosition) => gridSystem.IsValidGridPosition(gridPosition); // Check if the grid position is valid;

    public int GetWidth() => gridSystem.GetWidth(); // Get the width of the grid;

    public int GetHeight() => gridSystem.GetHeight(); // Get the height of the grid;

    public bool HasAnyUnitOnGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition); // Get the grid object at the grid position;
        return gridObject.HasAnyUnit(); // Check if the grid object has any unit;
    }
}