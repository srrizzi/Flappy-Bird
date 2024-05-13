using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private float cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gameManager = GameManager.Instance;

        if(gameManager.IsGameOver())
        {
            return;
        }

        cooldown -= Time.deltaTime;
        if(cooldown <= 0f)
        {
            cooldown = gameManager.ObstacleInterval;

            int prefabIndex = Random.Range(0, gameManager.ObstaclePrefabs.Count);
            var prefab = gameManager.ObstaclePrefabs[prefabIndex];
            var x = gameManager.ObstacleOffsetX;
            var y = Random.Range(gameManager.ObstacleOffsetY.x, gameManager.ObstacleOffsetY.y);
            var z = -0.25f;
            Vector3 position = new Vector3(x, y, z);

            Instantiate(prefab, position, prefab.transform.rotation);
        }
    }
}
