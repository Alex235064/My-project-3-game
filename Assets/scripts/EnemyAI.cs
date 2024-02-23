using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public plaerController player;
    public float ViewAngle;

    private NavMeshAgent _navMeshAngent;
    private bool _isPlayerNoticed;

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
        NoticePlayerUpdate();    
        ChaseUpdate();
        PortolUpdate();
    }

    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
           RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void PortolUpdate()
    {
        if (!_isPlayerNoticed)
        {
           if (_navMeshAngent.remainingDistance == 0)
           {
              PickNewPatrolposints();
           }
        }
       
    }
    private void PickNewPatrolposints()
    {
      _navMeshAngent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAngent.destination = player.transform.position;
        }
       
    }
}
