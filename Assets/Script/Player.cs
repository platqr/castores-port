using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private Main_Scripts _mainScript;
    
    [SerializeField] private Animator _animator;

    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;
    private float horizontalMovement;
    private bool isFacingRight = true;

    void Start()
    {
        _mainScript = GameObject.FindGameObjectWithTag("Main").GetComponent<Main_Scripts>();
    }

    private void Update(){
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        Jump();
        Fall();
        Animations();
    }

    private void FixedUpdate(){
        Walk();
    }

    private void Jump(){
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void Walk(){
        rb.velocity = new Vector2(horizontalMovement * walkSpeed * Time.fixedDeltaTime, rb.velocity.y);

        if (horizontalMovement<0 && isFacingRight)
        {
            Flip();
        }

        if (horizontalMovement>0 && !isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {

        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

    }

    private bool IsGrounded(){
        float extraHeightText = .05f;
        RaycastHit2D raycastHit = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + extraHeightText, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null) {
            rayColor = Color.green;
        } else {
            rayColor = Color.red;
        }
        Debug.DrawRay(playerCollider.bounds.center, Vector2.down * (playerCollider.bounds.extents.y + extraHeightText), rayColor);
        return raycastHit.collider != null;
    }

    private void Animations(){
        _animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        _animator.SetBool("IsJumping", !IsGrounded());
    }

    private void Fall(){
        if (transform.position.y <= -5.5f){
            _mainScript.GameOver();
        }
    }

}
