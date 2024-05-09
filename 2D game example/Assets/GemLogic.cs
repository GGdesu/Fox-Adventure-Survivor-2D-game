using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemLogic : MonoBehaviour
{

    private SpriteRenderer sr;
    private BoxCollider2D boxC;
    public GameObject spark;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        boxC = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player")){
            sr.enabled = false;
            boxC.enabled = false;
            spark.SetActive(true);
            GameController.instance.totalScore += 200;
            GameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.6f);
        }

    }
}
