using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collision coll;
    [SerializeField] private BoxCollider2D player;

    [Header("Checks")]
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canSlide = true;
    [SerializeField] private bool isJumping = false;

    [Space]
    [Header("Jump")]
    [SerializeField] private float jumpForce;

    [Space]
    [Header("Forward Movement")]
    [SerializeField] private float speedMultiplier = 1;
    [SerializeField] private float progressiveSpeedMultiplier = 1;
    [SerializeField] private float slowDownFactor = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();
        player = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (coll.onGround)
        {
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }

        if (canMove)
        {
            speedMultiplier += Time.deltaTime / 15 ;
            speedMultiplier = Mathf.Clamp(speedMultiplier, 2, 5);

            transform.position += new Vector3 (1, 0, 0) * Time.deltaTime * 4 * speedMultiplier / slowDownFactor * progressiveSpeedMultiplier;
        }
    }

    private void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;
    }

    public void OnSlide(InputAction.CallbackContext context)
    {
        if (context.performed && !isJumping && canSlide)
        {
            StartCoroutine(Slide());
        }
    }

    private void SlideDown()
    {
        player.size = new Vector3(1, 1, 1);
        player.offset = new Vector3(0, 0, 0);
    }

    private void SlideUp()
    {
        player.size = new Vector3(1, 2, 1);
        player.offset = new Vector3(0, 0.5f, 0);
    }

    IEnumerator Slide()
    {
        canSlide = false;
        SlideDown();
        yield return new WaitForSeconds(1f);
        SlideUp();
        canSlide = true;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && !isJumping)
        {
            Jump(Vector2.up);
        }
    }
}