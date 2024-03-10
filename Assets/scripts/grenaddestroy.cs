using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenaddestroy : MonoBehaviour
{
    public float lifegrenadetime;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroygrenade", lifegrenadetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Destroygrenade()
    {
        Destroy(gameObject);
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }
}
