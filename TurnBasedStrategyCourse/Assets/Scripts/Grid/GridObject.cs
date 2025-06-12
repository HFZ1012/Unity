using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem; // Reference to the grid system;
    private GridPosition gridPosition; // Reference to the grid position;
    private List<Unit> unitList; // Reference to the unit;
    //private Transform transform; // Reference to the transform of the object;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit>(); // Initialize the unit list;
    }

    public override string ToString() // Override the ToString method;
    {
        string unitString = ""; // Initialize the unit string;
        foreach (Unit unit in unitList) // For each unit in the unit list;
        {
            unitString += unit + "\n"; // Add the unit to the unit string;
        }
        
        return gridPosition.ToString() + "\n" + unitString; // Return the grid position and the unit;
    }

    public void AddUnit(Unit unit) // Set the unit;
    {
        unitList.Add(unit); // Add the unit to the unit list;
    }

    public void RemoveUnit(Unit unit) // Remove the unit;
    {
        unitList.Remove(unit); // Remove the unit from the unit list;
    }

    public List<Unit> GetUnitList() // Get the unit;
    {
        return unitList; // Return the unit;
    }
    
    public bool HasAnyUnit() // Check if the grid object has any unit;
    {
        return unitList.Count > 0; // Return true if the unit list is not empty;
    }
}



