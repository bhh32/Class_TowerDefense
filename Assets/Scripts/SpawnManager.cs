using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour 
{
    [SerializeField] GameObject[] enemyArr;
    List<GameObject> enemyList;
    [SerializeField] int listCount;

	// Use this for initialization
	void Start () 
    {
        enemyList = new List<GameObject>();
        StartCoroutine("Spawn");	
	}

    IEnumerator Spawn()
    {
        listCount = enemyList.Count;
        int randomEnemy = 0;
        float spawnDelay = 0f;
        GameObject newEnemy;

        if (enemyList.Count >= 5)
        {
            float counter = 0f;

            enemyList.Clear();

            while (counter < 15)
            {
                counter++;

                yield return new WaitForSeconds(1f);
            }
        }

        while (spawnDelay < 6)
        {
            randomEnemy = Random.Range(0, 2);

            switch (randomEnemy)
            {
                case 0:
                    newEnemy = Instantiate(enemyArr[0], transform.position, transform.rotation) as GameObject;
                    enemyList.Add(newEnemy);
                    break;
                case 1:
                    newEnemy = Instantiate(enemyArr[1], transform.position, transform.rotation) as GameObject;
                    enemyList.Add(newEnemy);
                    break;
            }

            spawnDelay++;

            yield return new WaitForSeconds(1.5f);
        }

            StartCoroutine("Spawn");
        }
}