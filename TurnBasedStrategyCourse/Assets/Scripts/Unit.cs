using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private GridPosition gridPosition; // Grid position of the unit;
    private MoveAction moveAction; // Reference to the MoveAction script;
    private SpinAction spinAction; // Reference to the SpinAction script;

    private void Awake() {
        moveAction = GetComponent<MoveAction>();
        spinAction = GetComponent<SpinAction>();
    }

    private void Start() {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition,this);
    }

    private void Update()
    {
       
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if(newGridPosition != gridPosition) {
            // LevelGrid.Instance.SetUnitAtGridPosition(gridPosition, null);
            // gridPosition = newGridPosition;
            // LevelGrid.Instance.SetUnitAtGridPosition(gridPosition, this);

            LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
            gridPosition = newGridPosition;
        }
    }

    public MoveAction GetMoveAction() {
        return moveAction;
    }

    public SpinAction GetSpinAction() {
        return spinAction;
    }

    public GridPosition GetGridPosition() {
        return gridPosition;
    }

}
