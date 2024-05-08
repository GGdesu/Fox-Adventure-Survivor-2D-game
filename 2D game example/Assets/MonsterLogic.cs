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
    private float onEnableSpeed;

    public Transform rightCol;
    public Transform leftCol;

    public Transform headPoint;

    public LayerMask layer;

    private bool colliding;

    private EnemyRespawn parentRef;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


        //get script reference for parent script
        parentRef = transform.parent.GetComponent<EnemyRespawn>();

    }


    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if (colliding)
        {

            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed = -speed;
        }

    }

    void FixedUpdate()
    {


    }

    void OnDisable()
    {
        
        speed = onEnableSpeed;
        Debug.Log($"speed: {speed}");
        boxCollider2D.enabled = true;
        circleCollider2D.enabled = true;

        rb.bodyType = RigidbodyType2D.Dynamic;
    }



    bool playerDestroyed = false;
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {

            float height = col.contacts[0].point.y - headPoint.position.y;
            if (height > 0 && !playerDestroyed)
            {
                //Debug.Log("Houve colisão na cabeça!");

                col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 9;
                onEnableSpeed = speed;
                speed = 0;
                anim.SetTrigger("MMonster_Die");
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rb.bodyType = RigidbodyType2D.Static;

                //win 10 points per monster deaths
                GameController.instance.totalScore += 10;
                GameController.instance.UpdateScoreText();

                //call a parent func to respawn a enemie
                if (parentRef != null)
                {
                    parentRef.RespawnEnemy(gameObject);
                }

                // Destroy(gameObject, 0.72f);
                //StartCoroutine(EnemyRespawn());

            }
            else
            {
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(col.gameObject);
            }
        }
    }



    IEnumerator EnemyRespawn()
    {

        yield return new WaitForSeconds(0.72f);

        gameObject.SetActive(false);

        yield return new WaitForSeconds(1f);
        Debug.Log("agora vai ativar");
        gameObject.SetActive(true);
    }


}
