using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieCounter : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private List<Transform> enemy = new List<Transform>();
    private string enemyListName = "Enemies";
    private int enemyCount = 0;
    private void Start()
    {
        Transform pointsObject = GameObject.FindGameObjectWithTag(enemyListName).transform;
        foreach (Transform t in pointsObject)
            enemy.Add(t);
        GlobalEventManager.OnDieEnemyCount.AddListener(GetDieEnemyCounter);
    }
    private void GetDieEnemyCounter()
    {
        enemyCount++;
        GetWinGame();
        Debug.Log($"Die Enemy {enemyCount}");
    }
    private void GetWinGame()
    {
        if(enemyCount >= enemy.Count)
        {
            gameManager.GetWinLevel();
        }
    }
}
