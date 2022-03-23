using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject [] monsterReference;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject SpawnedEnemy;

    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnedEnemies());
    }

    IEnumerator SpawnedEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            SpawnedEnemy = Instantiate(monsterReference[randomIndex]);

            //enemies coming from left side
            if (randomSide == 0)
            {
                SpawnedEnemy.transform.position = leftPos.position;
                SpawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 10);
            }
            else //Enemies coming from right side
            {
                SpawnedEnemy.transform.position = rightPos.position;
                SpawnedEnemy.GetComponent<Enemy>().speed = - Random.Range(4, 10);
                SpawnedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
























