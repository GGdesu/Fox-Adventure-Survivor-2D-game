using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    
    //public GameObject prefabEnemy;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnEnemy(GameObject enemy)
    {
        StartCoroutine(Respawn(enemy));
    }

    IEnumerator Respawn(GameObject enemy)
    {

        yield return new WaitForSeconds(0.72f);
        
        enemy.SetActive(false);

        yield return new WaitForSeconds(10f);
        Debug.Log("agora vai ativar");
        enemy.SetActive(true);
        
    }
}
