using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aidkit : MonoBehaviour
{
    public float CartidgeAmount = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var fireballCaster = other.gameObject.GetComponent<FireballCaster>();
        if (fireballCaster != null)
        {
            fireballCaster.AndCartidge(CartidgeAmount);
        }
        Destroy(gameObject);
       
    }
}
