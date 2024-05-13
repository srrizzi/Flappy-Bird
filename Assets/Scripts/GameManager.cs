using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    [FormerlySerializedAs("prefabs")]
    public List<GameObject> ObstaclePrefabs;
    public float ObstacleInterval = 1;
    public float ObstacleSpeed = 10;
    public float ObstacleOffsetX = 0;
    public Vector2 ObstacleOffsetY = Vector2.zero;

    [HideInInspector]
    public int Score;

    private bool isGameOver = false;
    
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public bool IsGameActive()
    {
        return !isGameOver;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void EndGame()
    {
        isGameOver = true;

        Debug.Log("Game Over. Your Score: " + Score);

        StartCoroutine(ReloadScene(2));
        
    }

    private IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        var sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
