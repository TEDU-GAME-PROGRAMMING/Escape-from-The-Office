using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public CharacterMovements CharMovements;

    private void OnCollisionStay(Collision other)
    {
        
        //If collided object is Player, then player's isGrounded is True.
        //Ground Checker Part of the character is entered the ground when it is landed after jump.
        if (other.gameObject.CompareTag("Player") )
        {
            CharMovements.isGrounded = true;

        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CharMovements.isGrounded = false;

        }
    }
}
