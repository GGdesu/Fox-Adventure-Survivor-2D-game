using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move2D : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed;
    private float direction;
    private Vector3 facingRight;
    private Vector3 facingLeft;

    public Animator animator;

    public bool onTheGround;// bool if on the ground is true or false
    public Transform detectGround; //check if it is touch on the ground
    public LayerMask lmGround;//indicate what is layer
    public int extraJump;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        //Movement input
        direction = Input.GetAxisRaw("Horizontal");

        Flip();

        //check if is on the ground
        onTheGround = Physics2D.OverlapCircle(detectGround.position, 0.5f, lmGround);

        Animation();

        
    }

    private void FixedUpdate(){
        //Movement physics
        rb.velocity = new Vector2(direction*moveSpeed, rb.velocity.y);
    }


    //Jump animation
    void Jump(){
        if (Input.GetButtonDown("Jump") && onTheGround)
        {
            rb.velocity = Vector2.up * 12;
            //activate jump anim
            animator.SetBool("onJump", true);
        }

        if (Input.GetButtonDown("Jump") && !onTheGround && extraJump > 0)
        {
            rb.velocity = Vector2.up * 12;
            extraJump--;
            //activate double jump anim
            animator.SetBool("onDoubleJump", true);

        }
    }

    //Crouch animation
    void Crouch(){
        if(Input.GetAxis("Vertical") < 0){
            animator.SetBool("onCrouch", true);
        }else{
            animator.SetBool("onCrouch", false);
        }
    }

    void Flip(){

        
        if (direction > 0)
        {
            //Olhando para a direita
            transform.localScale = facingRight;
        }
        if (direction < 0)
        {
            //Olhando para a esquerda
            transform.localScale = facingLeft;
        }

    }

    void Animation(){

        //run or idle animation
         if (Input.GetAxis("Horizontal") != 0)
        {
            //run
            animator.SetBool("onRun", true);
        }
        else
        {
            //idle
            animator.SetBool("onRun", false);
        }

        //jump animation and extraJump logic
        if (onTheGround && rb.velocity.y <= 1)
        {

            extraJump = 1;
            animator.SetBool("onJump", false);
            animator.SetBool("onDoubleJump", false);
        }

        
        Crouch();

        
        Jump();
    }

    

}
