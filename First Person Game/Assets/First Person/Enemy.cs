using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    int health = 4;
    [SerializeField]
    float enemyspeed = 5.0f;
    [SerializeField]
    Transform player;
    [SerializeField]
    GameObject enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {   
        transform.LookAt(player);
        transform.position = transform.position + transform.forward * enemyspeed * Time.deltaTime;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        health = health - 1;
    }

    
    
}

