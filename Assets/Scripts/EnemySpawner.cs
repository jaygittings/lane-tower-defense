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
    IEnumerator Start()
    {
        while(shouldSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            var obj = Instantiate(enemies[0], transform.position, Quaternion.identity);
            obj.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
