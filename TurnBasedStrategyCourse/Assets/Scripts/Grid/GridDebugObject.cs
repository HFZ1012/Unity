using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro; // Reference to the text mesh pro component;

    private GridObject gridObject; // Reference to the grid object;

    public void SetGridObject(GridObject gridObject) // Set the grid object;
    {
        this.gridObject = gridObject; // Set the grid object;
    }

    private void Update() // Update is called once per frame;
    {
        textMeshPro.text = gridObject.ToString(); // Update the text mesh pro text;
    }
}
