using System;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class NPC : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            //Interact
        }
    }
}