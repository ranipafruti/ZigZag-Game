using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject coinPrefabs;

    private Vector3 lastSpawnerPosition;
    private float width;

    // Start is called before the first frame update
    void Start()
    {

        lastSpawnerPosition = transform.position;
        width = platformPrefab.transform.localScale.x;

        for (int i = 1; i <= 20; i++)
        {
            PlatformSpawners();
        }

        InvokeRepeating("PlatformSpawners", 2, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlatformSpawners()
    {
        if(!GameManager.Instance.isGameOver)
        {
            int randomNumber = Random.Range(0, 10);

            if (randomNumber < 5)
            {
                SpawnAtX();
            }
            else
            {
                SpawnAtZ();
            }
        }
    }

    private void SpawnAtX()
    {
        Vector3 pos = lastSpawnerPosition;
        pos.x += width;

        Instantiate(platformPrefab, pos, Quaternion.identity);
        lastSpawnerPosition = pos;

        int randomX = Random.Range(0, 4);

        if (randomX < 1)
        {
            Instantiate(coinPrefabs, pos + Vector3.up, coinPrefabs.transform.rotation);
        }
    }
    private void SpawnAtZ()
    {
        Vector3 pos = lastSpawnerPosition;
        pos.z += width;

        Instantiate(platformPrefab, pos, Quaternion.identity);
        lastSpawnerPosition = pos;

        int randomX = Random.Range(0, 4);

        if (randomX < 1)
        {
            Instantiate(coinPrefabs, pos + Vector3.up, coinPrefabs.transform.rotation);
        }
    }
}
