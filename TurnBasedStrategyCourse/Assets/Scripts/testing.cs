using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    [SerializeField] private Unit unit;
    


    public void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)) {
            GridSystemVisual.Instance.HideAllGridPositions();
            GridSystemVisual.Instance.ShowGridPositionList(
                unit.GetMoveAction().GetValidActionGridPositionList());
        }

    }
}
