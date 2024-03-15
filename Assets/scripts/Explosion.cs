using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float armore = 25;
    public float damage = 50;
    public float Maxsize = 5;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
        
    }
     


    // Update is called once per frame
    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * speed;
        if (transform.localScale.x > Maxsize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DealDamage(damage - armore);
        }

        var enemyHEalth = other.GetComponent<EnemyHealth>();
        if (enemyHEalth != null)
        {
            enemyHEalth.DealDamage(damage);
        }
    }
}
