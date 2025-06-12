using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private float cellsize;
    private GridObject[,] gridObjectArray; // Array to store the grid objects;

    public GridSystem(int width, int height,float cellsize) // Constructor;
    {
        this.width = width; // Set the width of the grid;
        this.height = height; // Set the height of the grid;
        this.cellsize = cellsize; // Set the size of each grid cell;

        gridObjectArray = new GridObject[width, height]; // Initialize the grid object array;

        for(int x = 0; x < width; x++) // Loop through the width of the grid;
        {
            for(int z = 0; z < height; z++) // Loop through the height of the grid;
            {
                GridPosition gridPosition = new GridPosition(x, z); // Create a new grid position;
                gridObjectArray[x, z] = new GridObject(this, gridPosition);
            }
        }
    }
    
    public Vector3 GetWorldPosition(GridPosition gridPosition) // Get the world position of a grid cell;
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellsize; // Return the world position of the grid cell;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) // Get the grid position;
    {
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x / cellsize), // Get the x position of the grid cell;
            Mathf.RoundToInt(worldPosition.z / cellsize) // Get the z position of the grid cell;
        );
    }

    public void CreateDebugObjects(Transform debugPrefab) // Create debug objects;
    {
        for(int x = 0; x < width; x++) // Loop through the width of the grid;
        {
            for(int z = 0; z < height; z++) // Loop through the height of the grid;
            {
                GridPosition gridPosition = new GridPosition(x, z); // Create a new grid position;
                Transform debugTransform =GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPosition), Quaternion.identity); // Create a new debug object;
                GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>(); // Get the grid debug object component;
                gridDebugObject.SetGridObject(GetGridObject(gridPosition)); // Set the grid object of the debug object;
            }
        }
    }

    public GridObject GetGridObject(GridPosition gridPosition) // Get the grid object;
    {
        return gridObjectArray[gridPosition.x, gridPosition.z]; // Return the grid object;
    }

    public bool IsValidGridPosition(GridPosition gridPosition) // Check if the grid position is valid;
    {
        return gridPosition.x >= 0 && gridPosition.z >= 0 && gridPosition.x < width && gridPosition.z < height; // Return true if the grid position is valid;
    }

    public int GetWidth() // Get the width of the grid;
    {
        return width; // Return the width of the grid;
    }

    public int GetHeight() // Get the height of the grid;
    {
        return height; // Return the height of the grid;
    }
}