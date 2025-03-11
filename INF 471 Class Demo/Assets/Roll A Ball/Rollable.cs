using UnityEngine;
using UnityEngine.InputSystem;

public class Rollable : MonoBehaviour
{

    [SerializeField]
    public float health = 5;
    Vector2 m;
    Rigidbody rb;
    public int score = 0;
    Transform t;
    [SerializeField]
    GameManager manager;
    public GameObject Chest;
    bool Sprinting = false;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m = new Vector2(0,0);
        rb = GetComponent<Rigidbody>();
        print("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        float x_dir = m.x;
        float z_dir = m.y;
        Vector3 actual_movement = new Vector3(x_dir,0,z_dir);
        //print(actual_movement);

        if (Sprinting == true)
        {
            print("Sprinting");
            actual_movement = actual_movement * 3;
        }
        if (Sprinting == false)
        {
            print("rolling");
        }
        
        rb.AddForce(actual_movement);
        
        if (score == 40)
        {
            manager.EndGame();
        }
        if (health == 0)
        {
            manager.LoseGame();
        } 
    }

    void OnMove(InputValue movement)
    {
        m = movement.Get<Vector2>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (Chest != null)
        {   
            score += 1;
            //print("Score: " + score); 
        }
    }

    void OnSprint(InputValue Sprint)
    {
        if (Sprint.isPressed)
        {
            Sprinting = true;
        } else
        {
            Sprinting = false; 
        }
    }
}
