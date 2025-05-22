using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] GameObject gameOverUI;
    NavMeshAgent navAgent;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navAgent.destination = target.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameOverUI.SetActive(true);
        }
    }

}