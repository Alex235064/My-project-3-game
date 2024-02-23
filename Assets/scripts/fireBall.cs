using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    public float Speed;
    public float lifetime;
    public float damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFireBall", lifetime);
    }

    private void OnCollisionEnter( Collision collision)
    {
       
        DamageEnemy(collision);
        DestroyFireBall();
    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.value -= damage;
            }
    }

    private void DestroyFireBall()
    {
         Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveFixedUpdate();
     
    }
     private void MoveFixedUpdate()
    {
       transform.position += transform.forward * Speed * Time.deltaTime;
    }
}