using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  // 关键命名空间

public class InputController : MonoBehaviour
{
    public float speed = 1;
    PlayerControl playerControl;
    void Awake()
    {
        var playerInput = GetComponent<PlayerInput>();
        playerControl = new PlayerControl();
        playerInput.actions = playerControl.asset;
        playerInput.currentActionMap = playerControl.Player;
        RegisterPlayerActions();
        RegisterUIActions();
    }
    void RegisterPlayerActions()
    {
        playerControl.Player.Attack.performed += context => { Debug.Log("attack"); };
    }
    void RegisterUIActions()
    {

    }
    void Update()
    {
        Vector2 move = playerControl.Player.Move.ReadValue<Vector2>();
        if(move.magnitude > 0)
        {
            var direction = new Vector3(move.x, 0, move.y);
            if (direction.magnitude >= 1)
            {
                direction.Normalize();
            }
            transform.localPosition += direction * speed * Time.deltaTime;
        }
    }
}
