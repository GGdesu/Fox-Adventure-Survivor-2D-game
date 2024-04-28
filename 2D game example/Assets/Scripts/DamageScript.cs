using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("tocou o espinho!");
            GameController.instance.ShowGameOver();
            Destroy(col.gameObject);
        }
    }
}
