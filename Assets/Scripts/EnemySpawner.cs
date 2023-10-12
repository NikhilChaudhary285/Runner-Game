using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] EnemyPrefabs;

    private int randomIndex;
 
    private int prevEnemy = 1;

    private int instantiatedEnemies;
    public int destroyedEnemies;
    private int presentEnemies;
    public int wantedEnemies = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {

        while (true)
        {
            presentEnemies = instantiatedEnemies - destroyedEnemies;
            if (presentEnemies >= wantedEnemies)
            {
                yield return new WaitForSeconds(0.5f);

            }
            else
            {
                randomIndex = Random.Range(0, EnemyPrefabs.Length);
                if (prevEnemy == randomIndex)
                {
                    continue;
                }
                yield return new WaitForSeconds(Random.Range(2, 5));
                Instantiate(EnemyPrefabs[randomIndex], transform.position, transform.rotation);
                
                // prevent from repeat enemy prefabs
                prevEnemy = randomIndex;

                instantiatedEnemies++;

            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}



