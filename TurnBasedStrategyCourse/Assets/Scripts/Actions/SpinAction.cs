using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    private float totalSpinAmount;

    private void Update()
    {
        if(!isActive) // If the action is not active;
        { // Exit the method;
            return;
        }

        float spinAddAmount = 360f * Time.deltaTime; // Calculate the spin amount;
        transform.eulerAngles += new Vector3(0, spinAddAmount, 0); // Rotate the object;
        totalSpinAmount += spinAddAmount; // Add the spin amount to the total spin amount;

        if(totalSpinAmount >= 360f) // If the total spin amount is greater than or equal to 360 degrees;
        { // Exit the method;
            isActive = false; // Set the isActive flag to false;
            onActionComplete(); // Notify the spin complete delegate;   
        }
    }

    public void Spin(Action onActionComplete) // Spin the object;
    {
        this.onActionComplete = onActionComplete; // Set the spin complete delegate;
        isActive = true; // Set the isActive flag to true;
        totalSpinAmount = 0; // Reset the total spin amount;
    }
}
