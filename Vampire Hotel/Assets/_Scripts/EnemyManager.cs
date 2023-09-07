using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    GameManager gm;
    //Vector3 playerPos;
    float spawnTime = 5f;
    [SerializeField] Enemy enemyChild;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        //playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        StartSpawnCoroutine();
    }

    public void StartSpawnCoroutine()
    {
        StartCoroutine(SpawnTime());
        Debug.Log("Enemy started spawn coroutine");
    }

    IEnumerator SpawnTime()
    {
        bool done = false;

        while (!done)
        {
            Debug.Log("Enemy started countdown");
            yield return new WaitForSeconds(spawnTime);

            int enemyCountGlobal = GameObject.FindGameObjectsWithTag("Enemy").Length; // izracuna trenutni broj enemyja (sve skupa)
            Debug.Log("Counted " + enemyCountGlobal + " Global enemies");

            // izracuna koliko je neprijatelja u blizini
            int enemyCountLocal = 0;
            Collider[] hitColliders = Physics.OverlapSphere(enemyChild.transform.position, 5f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Enemy") && hitCollider.gameObject.activeInHierarchy)
                {
                    enemyCountLocal++;
                    Debug.Log("Counted another Local: " + hitCollider.gameObject);
                }
            }
            Debug.Log("Counted " + enemyCountLocal + " Local enemies");

            if (gm.gameOver)
            {
                done = true;
                Debug.Log("Game Over");
            }
            else
            {
                if (enemyCountGlobal < gm.enemyLimitGlobal    // Ako ima manje neprijatelja sve skupa od limita
                   && enemyCountLocal < gm.enemyLimitLocal)   // Te ako ima manje neprijatelja u blizini od limita
                {
                    // Spawnaj

                    ManageDifficulty();

                    enemyChild.gameObject.SetActive(true);

                    done = true;

                    Debug.Log("Spawned");
                }
            }
        }
        Debug.Log("Coroutine done");
    }

    void ManageDifficulty()
    {
        // ovisno o scoreu/levelu setiraj spawnTime, rotSpeed (za EnemyChild), enemyLimitGlobal (u GameManageru), enemyLimitLocal (u GameManageru)
    }
}
