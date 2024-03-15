using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float regenerationDelay = 0; 
    public float regeneration = 10;
    public RectTransform valueRectTransform;
    public float value = 100;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    private float _maxValue;

    private void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }

    private void Update()
    {
        if (value < _maxValue)
        {
            Invoke("Regeneration", regenerationDelay);
            DrawHealthBar();
        }
    }

    private void DrawHealthBar()
    {
       valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            plaerisdeath();
            
        }
        DrawHealthBar();
    }

    private void plaerisdeath()
    {
            gameplayUI.SetActive(false);
            gameOverScreen.SetActive(true);
            GetComponent<plaerController>().enabled = false;
            GetComponent<FireballCaster>().enabled = false;
            GetComponent<CameraROtation>().enabled = false;
    }

    private void Regeneration()
    {
        value += regeneration * Time.deltaTime;
    }
}
