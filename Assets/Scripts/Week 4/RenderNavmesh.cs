using UnityEngine;
using Unity.AI.Navigation; 
using System.Collections.Generic;
//using NaughtyAttributes;

public class RenderNavmesh : MonoBehaviour
{
    private NavMeshSurface surface;


    [SerializeField] private int numObby;
    [SerializeField] List<GameObject> obbyPrefab;
    [SerializeField] private Vector2 randomPos;
    [SerializeField] private Transform obstaclesParent;
    [SerializeField] private int minDistance = 5;

    [SerializeField] GameObject player;
    private Vector3 spawnPos;


    private void Start()
    {
        surface = GetComponent<NavMeshSurface>();
        Baker();
        
    }

    Vector3 RandomizePosition(float yPos)
    {
        float xPos = Random.Range(randomPos.x, randomPos.y);
        float zPos = Random.Range(randomPos.x, randomPos.y);
        return new Vector3(xPos, yPos, zPos);
    }

    private void Baker()
    {
        for (int i = 0; i < numObby; i++)
        {
            int prefabIndex = Random.Range(0, obbyPrefab.Count);
            
            Vector3 playerPos = player.transform.position;
            GameObject newObby = Instantiate(obbyPrefab[prefabIndex]);
            newObby.transform.SetParent(obstaclesParent);

            do
            {
                spawnPos = RandomizePosition(newObby.transform.position.y);
            } while (Vector3.Distance(spawnPos, playerPos) < minDistance);
            
            newObby.transform.position = spawnPos;
        }

        surface.BuildNavMesh();
    }

    //[Button]
    //void Bake()
    //{
    //    foreach (Transform obstacle in obstacles)
    //    {
    //        Destroy(obstacle.gameObject);
    //    }

    //    Baker();
    //    surface.BuildNavMesh();
    //}
}


