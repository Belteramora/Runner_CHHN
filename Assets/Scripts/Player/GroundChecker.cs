using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private float groundCheckDistance;

    public void SetVariables(float groundChDist)
    {
        groundCheckDistance = groundChDist;
    }

    public bool IsOnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance);
        if (hit.collider != null && hit.collider.CompareTag("Ground"))
        {
            PlayerController.flying = false;
            return true;
        }

        return false;
    }
}
