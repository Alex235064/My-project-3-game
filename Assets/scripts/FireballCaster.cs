using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireballCaster : MonoBehaviour
{
    public fireBall fireballprefab;
    public Transform fireballSourceTransform;
    public TextMeshProUGUI NumberOfCartidgetext;
    public TextMeshProUGUI TotelCartidgetext;
    public float NumberOfCartidge = 7;
    public float TotelCartidge = 30;

    private float shot = 1f;
    private float _maxNumberOfCartidge;
    private float _cartinge = 0;

    // Start is called before the first frame update
    void Start()
    {
        _maxNumberOfCartidge = NumberOfCartidge;
        DisplayTheNumberOfReadyCartridges();
        DisplayTheNumberOfCartridges();


    }

    // Update is called once per frame
    void Update()
    {
        if (NumberOfCartidge > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(fireballprefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
                DischargingWeapons();
            }
            else
            {

                if (Input.GetKey(KeyCode.R))
                {
                    Recharge();
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.R))
            {
              Recharge();
            }
            
        }
       
      
    }
    private void DischargingWeapons()
    {
        NumberOfCartidge -= shot;
        DisplayTheNumberOfReadyCartridges();


    }

    private void Recharge()
    {
        _cartinge = _maxNumberOfCartidge - NumberOfCartidge;
        if (TotelCartidge > _cartinge)
        {
           NumberOfCartidge += _cartinge;
           DisplayTheNumberOfReadyCartridges();
           TotelCartidge -= _cartinge;
           DisplayTheNumberOfCartridges();
        }
        else
        {
            NumberOfCartidge += TotelCartidge;
            DisplayTheNumberOfReadyCartridges();
            TotelCartidge -= TotelCartidge;
            DisplayTheNumberOfCartridges();
        }
      
       
    }

    private void DisplayTheNumberOfReadyCartridges()
    {
       NumberOfCartidgetext.text = NumberOfCartidge.ToString();
    }

    private void DisplayTheNumberOfCartridges()
    {
        TotelCartidgetext.text = TotelCartidge.ToString();
    }
    public void AndCartidge(float amount)
    {
        TotelCartidge += amount;
        DisplayTheNumberOfCartridges();
    }
}
