using UnityEngine;

// suppress variable assigned but not used warning
#pragma warning disable 0414

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    #region PROPERTIES
    [SerializeField]
    private float runVel = 1;
    [SerializeField]
    private float jumpForce = 1;
    [SerializeField]
    private float terminalFallVelocity = 1.0f;
    #endregion
    #region PRIVATE MEMBERS
    private bool isGrounded = true;
    private Rigidbody2D rb;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // move player horizontally based on arrow keys
        rb.linearVelocityX = Input.GetAxisRaw("Horizontal") * runVel;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }
    }

    void TryJump()
    {
        if(Mathf.Approximately(rb.linearVelocityY, 0))
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }

    void Land()
    {

    }

    public void Die()
    {
        Debug.Log("player died");
    }
}
