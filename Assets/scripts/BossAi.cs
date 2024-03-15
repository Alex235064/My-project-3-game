using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAi : MonoBehaviour
{
   public float timer = 0;
   public fireBall fireballprefab;
    public Transform fireballSourceTransform;
    public float secondfirebollcoster = 5;
    public List<Transform> patrolPoints;
    public plaerController player;
    public float ViewAngle;
    public float damage = 30f;

    private NavMeshAgent _navMeshAngent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        InItComponentLinks();
        PickNewPatrolposints();
    }

    private void InItComponentLinks()
    {
        _navMeshAngent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }
    private void OnCollisionEnter(Collision collision)
    {

    }

    // Update is called once per frame
    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        PortolUpdate();
        AttackUpdate();
        timer += Time.deltaTime;
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAngent.remainingDistance <= _navMeshAngent.stoppingDistance)
            {
                _playerHealth.DealDamage(damage * Time.deltaTime);
            }
        }
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
                   fireballcasterboss();
                 
                }
            }
        }
    }

    private void PortolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAngent.remainingDistance <= _navMeshAngent.stoppingDistance)
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


    private void fireballcasterboss()
    {
        if (secondfirebollcoster <= timer)
        {
            Instantiate(fireballprefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
            timer = 0;
        }
        
    }
}
