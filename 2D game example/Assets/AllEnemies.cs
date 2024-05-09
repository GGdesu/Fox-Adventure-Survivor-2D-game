using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemies : MonoBehaviour
{
    private Transform[] child;

    private bool isCooldown = false;
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isCooldown)
        {
            isCooldown = true;
            child = GetComponentsInChildren<Transform>();

            for (int i = 0; i < child.Length; i++)
            {
                if (child[i] == transform)
                {
                    continue;
                }

                StartCoroutine(FreezeMovement(child[i]));
            }

        }

    }

    IEnumerator FreezeMovement(Transform childObj)
    {

        MonsterLogic monsterLogic = childObj.GetComponent<MonsterLogic>();
        Renderer monsterRender = childObj.GetComponent<Renderer>();
        float auxSpeed = 0;
        if (monsterLogic != null)
        {
            auxSpeed = monsterLogic.speed;
            monsterLogic.speed = 0f;
        }

        if(monsterRender != null){
            monsterRender.material.color = new Color(22f/255f, 208f/255f, 224f/255f); 
        }

        yield return new WaitForSeconds(5f);

        if (monsterLogic != null)
        {
            monsterLogic.speed = auxSpeed;
            monsterRender.material.color = Color.white;
        }

        yield return new WaitForSeconds(5f);
        isCooldown = false;
    }
}
