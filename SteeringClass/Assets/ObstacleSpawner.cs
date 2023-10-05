using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float radio;
    public List<GameObject> obstacles;
    public List<Vector3> obstaclePositions;

    private void Start()
    {
        float total = Random.Range(50, 100);
        for (int i = 0; i <= total; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-60f, 60f), 1f, Random.Range(-60f,60f));
            if (IsPositionEmpty(randomPos))
            {
                GameObject NewInst = Instantiate(obstacle, randomPos, Quaternion.identity);
                obstacles.Add(NewInst);
                obstaclePositions.Add(NewInst.transform.position);
            }
        }
    }
  
    bool IsPositionEmpty(Vector3 position)
    {
        foreach (var obstacle in obstacles)
        {
            if (Vector3.Distance(position, obstacle.transform.position) < radio)
            {
                return false;
            }
        }

        return true;
    }

}