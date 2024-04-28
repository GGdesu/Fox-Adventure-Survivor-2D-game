using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Saw : MonoBehaviour
{
    //in some plataform speed = 2
    public float speed;
    //move time = 1.3
    public float moveTime;

    private bool dirRight = true;
    private float timer;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        if(dirRight){
            //if true saw direction goes to right
            transform.Translate(speed * Time.deltaTime * Vector2.right);
        }else{
            //if false saw direction goes to left
            transform.Translate(speed * Time.deltaTime * Vector2.left);
        }

        timer += Time.deltaTime;
        if(timer >= moveTime){
            dirRight = !dirRight;
            timer = 0f;
        }

    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player")){
            GameController.instance.ShowGameOver();
            Destroy(col.gameObject);
        }
    }
}
