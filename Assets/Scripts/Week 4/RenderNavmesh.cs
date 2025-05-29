using UnityEngine;
using Unity.AI.Navigation; //enables baking during runtime
using System.Collections.Generic; //the use of lists
using NaughtyAttributes;

public class RenderNavmesh : MonoBehaviour
{
    private NavMeshSurface surface;

    [SerializeField] private int numObby;
    [SerializeField] List<GameObject> obbyPrefab;
    [SerializeField] private Vector2 randomPos;

    [SerializeField] GameObject player;


    private void Start()
    {
        surface = GetComponent<NavMeshSurface>();
        Baker();
        surface.BuildNavMesh();
    }

    private void Baker()
    {
        for (int i = 0; i < numObby; i++)
        {
            int prefabIndex = Random.Range(0, obbyPrefab.Count);
            float xPos = Random.Range(randomPos.x, randomPos.y);
            float zPos = Random.Range(randomPos.x, randomPos.y);
            float xOffset = player.transform.position.x;
            float zOffset = player.transform.position.y;

            GameObject newObby = Instantiate(obbyPrefab[prefabIndex]);
            newObby.transform.position = new Vector3(xOffset + xPos, newObby.transform.position.y, zOffset + zPos);
        }

        surface.BuildNavMesh();
    }

    //[Button]
    //void Bake()
    //{
    //    Baker();
    //}
}


