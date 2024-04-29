using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private Transform respawnPoint;
    void Start()
    {

        respawnPoint = transform;
        
    }

    public void RespawnEnemy(){
        if (gameObject.activeSelf)
    {
        StartCoroutine(RespawnCoroutine());
    }
    }

    private IEnumerator RespawnCoroutine(){
        yield return new WaitForSeconds(2f);

        GameObject newEnemy = Instantiate(enemyPrefab, respawnPoint.position, respawnPoint.rotation);
    }
}
