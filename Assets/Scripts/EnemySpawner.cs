using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 2f;
    [SerializeField] List<GameObject> enemies = null;


    bool shouldSpawn = true;


    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        StartCoroutine(Spawn(enemies));
    }
    
    
    private IEnumerator Spawn(List<GameObject> enemies)
    {
        while (shouldSpawn)
        {
            var enemyIndex = Random.Range(0, enemies.Count);
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            var obj = Instantiate(enemies[enemyIndex], transform.position, Quaternion.identity);
            obj.transform.parent = transform;
        }

    }

    public void DisableSpawning()
    {
        shouldSpawn = false;
    }
}
