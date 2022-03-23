using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 10f;

    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer myspriteRenderer;
    private Animator  myAnimator;
    public string WALK_ANIMATION = "Walk";
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    // Start is called before the first frame update

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myspriteRenderer = GetComponent<SpriteRenderer>();   
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        AnimatePlayer();
        PlayerJump();
    }
    private void PlayerMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f,0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        //We are going to the right side
        if (movementX > 0)
        {
            myAnimator.SetBool(WALK_ANIMATION, true);
            myspriteRenderer.flipX = false;
        }
        //we are going to the left side
        else if (movementX < 0)
        {
            myAnimator.SetBool(WALK_ANIMATION, true);
            myspriteRenderer.flipX = true;
        }
        else
        {
            myAnimator.SetBool(WALK_ANIMATION, false);

        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myBody.gravityScale = 1.5f  ;
            myBody.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
            isGrounded = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;

        if (collision.gameObject.CompareTag(ENEMY_TAG))
            Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }
}
