using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterLogic : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Animator anim;

    public float speed;

    public Transform rightCol;
    public Transform leftCol;

    public Transform headPoint;

    public LayerMask layer;

    private bool colliding;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

      

    }

    
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if(colliding){

            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed = -speed;
        }
        
    }

    void FixedUpdate(){

        
    }

    

   bool playerDestroyed = false;
   void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.CompareTag("Player")){

            float height = col.contacts[0].point.y - headPoint.position.y;
    	    //Debug.Log(height);
            if(height > 0 && !playerDestroyed){
                //Debug.Log("Houve colisão na cabeça!");
                
                col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 9;
                speed = 0;
                anim.SetTrigger("MMonster_Die");
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rb.bodyType = RigidbodyType2D.Static;

                //win 10 points per monster deaths
                GameController.instance.totalScore += 10;
                GameController.instance.UpdateScoreText();

                Destroy(gameObject, 0.72f);

                
            }else{
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(col.gameObject);
            }
        }
   }


}
