using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{
    [SerializeField]private Animator unitAnimator; // Animator component of the unit;
    [SerializeField]private int maxMoveDistance = 4; // Maximum movement distance of the unit;

    private Vector3 targetPosition;

    protected override void Awake() 
    {
        base.Awake();
        targetPosition = transform.position;
    }
    
    private void Update() {
        if(!isActive) { // If the action is not active;
            return; // Exit the method;
        }
        Vector3 moveDirection = (targetPosition - transform.position).normalized; // Calculate the direction towards the target position;

        float stoppingDistance = 0.1f; // Distance threshold to consider the unit at the target positio
        if(Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            float moveSpeed = 5f; // Speed of movement per second;
            transform.position += moveDirection * moveSpeed * Time.deltaTime; // Move the unit towards the target position;   

            unitAnimator.SetBool("IsWalking",true); 
        } else
        {
            unitAnimator.SetBool("IsWalking",false);
            isActive = false;
            onActionComplete();
        }

        float rotationSpeed = 10f; // Speed of rotation per second;
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime*rotationSpeed);
    }

    public void Move(GridPosition gridPosition,Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
        this.targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
        isActive = true;
    }

    public bool IsValidActionGridPosition(GridPosition gridPosition) {
        List<GridPosition> validGridPositionList = GetValidActionGridPositionList(); // Get the list of valid grid positions;
        return validGridPositionList.Contains(gridPosition); // Check if the given grid position is in the list of valid grid positions;
    }


    public List<GridPosition> GetValidActionGridPositionList() {
        List<GridPosition> validGridPositionList = new List<GridPosition>(); // List of valid grid positions;

        GridPosition unitGridPosition = unit.GetGridPosition(); // Get the grid position of the unit;

        for(int x = -maxMoveDistance; x <= maxMoveDistance; x++) { // Loop through the x-axis;
            for(int z = -maxMoveDistance; z <= maxMoveDistance; z++) { // Loop through the z-axis;
                GridPosition offsetGridPosition = new GridPosition(x,z); // Create a grid position offset;
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition; // Create a test grid position;

                if(!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                {
                    continue; // If the test grid position is not valid, skip it;
                }

                if(testGridPosition == unitGridPosition)
                {
                    continue; // If the test grid position is the same as the current grid position, skip it;
                }

                if(LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition))
                {
                    continue; // If there is any unit on the test grid position, skip it;
                }
                validGridPositionList.Add(testGridPosition); // Add the test grid position to the list of valid grid positions;
            }
        }
        return validGridPositionList;
    }
}
