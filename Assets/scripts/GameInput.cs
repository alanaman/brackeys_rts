using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput I { get; private set; }
    PlayerInputActions playerInputActions;

    Player player;

    private void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(this);
            return;
        }

        I = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.PlaterInputActionMap.Enable();


    }

    private void Start()
    {
        player = GameManager.I.Player;

        playerInputActions.PlaterInputActionMap.move.performed += player.OnMovement; 
        playerInputActions.PlaterInputActionMap.move.canceled += player.OnMovement;
        playerInputActions.PlaterInputActionMap.jump.started += player.GetComponent<PlayerJump>().OnJumpInput;
        playerInputActions.PlaterInputActionMap.jump.canceled += player.GetComponent<PlayerJump>().OnJumpInput;
        playerInputActions.PlaterInputActionMap.interact.performed += player.OnInteract;
        playerInputActions.PlaterInputActionMap.ability.performed += player.OnAttack;

        //playerInputActions.PlaterInputActionMap.ability.performed += GameManager.I.Player.GetComponent<PlayerAbility>().OnAbilityUsed;
        
    }

    //public Vector2 GetDirectionVector()
    //{
    //    //Debug.Log(playerInputActions.Player.direction.ReadValue<Vector2>());
    //    return playerInputActions.PlaterInputActionMap.move.ReadValue<Vector2>();
    //}

    /*public float GetAccelaration()
    {
        return playerInputActions.Player.accelerate.ReadValue<float>();
    }*/

}
