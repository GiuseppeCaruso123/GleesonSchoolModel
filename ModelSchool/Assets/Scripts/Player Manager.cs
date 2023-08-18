using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;
    public GameObject pausemenu, settingmenu;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
        if (pausemenu || settingmenu == true)
        {
            inputManager.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }
     
}
