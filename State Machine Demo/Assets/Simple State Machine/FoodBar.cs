using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{

    public Slider HealthBar;
    public float health;
    float maxHealth = 10f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = health;
        health -= 0.5f * Time.deltaTime;
    }
}
