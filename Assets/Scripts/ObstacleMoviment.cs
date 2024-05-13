using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoviment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var gameManager = GameManager.Instance;

        if(gameManager.IsGameOver())
        {
            return;
        }

        float x = gameManager.ObstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);

        if(transform.position.x <= -gameManager.ObstacleOffsetX)
        {
            Destroy(gameObject);
        }
    }
}
