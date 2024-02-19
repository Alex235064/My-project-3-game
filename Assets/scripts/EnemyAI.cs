using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;

    private NavMeshAgent _navMeshAngent;

    // Start is called before the first frame update
    void Start()
    {
        InItComponentLinks();
        PickNewPatrolposints();
    }
    
    private void InItComponentLinks()
    {
        _navMeshAngent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        PortolUpdate();
    }

    private void PortolUpdate()
    {
        if (_navMeshAngent.remainingDistance == 0)
        {
            PickNewPatrolposints();
        }
    }
    private void PickNewPatrolposints()
    {
      _navMeshAngent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

}
