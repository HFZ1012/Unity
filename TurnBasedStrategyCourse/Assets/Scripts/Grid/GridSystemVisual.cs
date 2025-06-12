using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{
    public static GridSystemVisual Instance { get; private set; } // Singleton instance of the UnitActionSystem class;

    [SerializeField] private Transform gridSystemVisualSinglePrefab; // Prefab for the grid system visual;

    private GridSystemVisualSingle[,] gridSystemVisualSingleArray; // Array to store the grid system visual objects;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Duplicate GridSystemVisual instance detected! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    private void Start() {
        gridSystemVisualSingleArray = new GridSystemVisualSingle[LevelGrid.Instance.GetWidth(), LevelGrid.Instance.GetHeight()]; // Initialize the grid system visual object array;
        for(int x = 0; x < LevelGrid.Instance.GetWidth(); x++) { // Loop through the width of the grid;
            for(int z = 0; z < LevelGrid.Instance.GetHeight(); z++) 
            {
                GridPosition gridPosition = new GridPosition(x, z); // Create a new grid position;
                Transform gridSystemVisualSingleTransform = Instantiate(gridSystemVisualSinglePrefab, LevelGrid.Instance.GetWorldPosition(gridPosition), Quaternion.identity); // Create a new grid system visual object;
                gridSystemVisualSingleArray[x, z] = gridSystemVisualSingleTransform.GetComponent<GridSystemVisualSingle>(); // Get the grid system visual object component;
                }
            }
        }
    
    private void Update() { // Update the grid visual;
        UpdateGridVisual(); // Update the grid visual;
    }
    
    
    public void HideAllGridPositions() { // Hide all grid positions;
        for(int x = 0; x < LevelGrid.Instance.GetWidth(); x++) { // Loop through the width of the grid;
            for(int z = 0; z < LevelGrid.Instance.GetHeight(); z++) { // Loop through the height of the grid;
                gridSystemVisualSingleArray[x, z].Hide(); // Hide the grid system visual object;
            }
        }
    }

    public void ShowGridPositionList(List<GridPosition> gridPositionList) 
    { // Show the grid positions;
        foreach(GridPosition gridPosition in gridPositionList) 
        { // Loop through the grid positions;
            gridSystemVisualSingleArray[gridPosition.x, gridPosition.z].Show(); // Show the grid system visual object;        }
        }
    }

    private void UpdateGridVisual() { // Update the grid visual;
        HideAllGridPositions(); // Hide all grid positions;
        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit(); // Get the selected unit;
        if(selectedUnit != null) { // If the selected unit is not null;
            ShowGridPositionList(selectedUnit.GetMoveAction().GetValidActionGridPositionList()); // Show the grid positions;
        }
    }

}