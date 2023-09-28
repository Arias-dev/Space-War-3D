using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<EnemyAI> enemies = new List<EnemyAI>();

    void Update()
    {
        UpdateNeighbours();
    }


    void UpdateNeighbours()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            for (int j = i + 1; j < enemies.Count; j++)
            {
                float distance = Vector3.Distance(enemies[i].transform.position, enemies[j].transform.position);
                if (distance < 10f) // Misalnya, gunakan jarak yang sesuai di sini
                {
                    if (!enemies[i].nearbyEnemies.Contains(enemies[j].transform))
                    {
                        enemies[i].nearbyEnemies.Add(enemies[j].transform);
                    }
                    if (!enemies[j].nearbyEnemies.Contains(enemies[i].transform))
                    {
                        enemies[j].nearbyEnemies.Add(enemies[i].transform);
                    }
                }
                else
                {
                    enemies[i].nearbyEnemies.Remove(enemies[j].transform);
                    enemies[j].nearbyEnemies.Remove(enemies[i].transform);
                }
            }
        }
    }
}
