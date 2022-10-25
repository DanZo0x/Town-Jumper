using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [Header("Ground")]
    public LayerMask groundLayer;
    public Vector2 bottomOffset;
    public Vector2 collisionSizeGround;
    public bool onGround;

    private void FixedUpdate()
    {
        //check ground
        onGround = Physics2D.OverlapBox((Vector2)transform.position + bottomOffset, collisionSizeGround, 0f, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        //ground gizmo
        Gizmos.DrawWireCube((Vector2)transform.position + bottomOffset, collisionSizeGround);
    }
}
