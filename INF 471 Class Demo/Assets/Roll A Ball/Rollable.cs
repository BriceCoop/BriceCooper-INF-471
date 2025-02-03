using UnityEngine;
using UnityEngine.InputSystem;

public class Rollable : MonoBehaviour
{

    Vector2 m;
    Rigidbody rb;
    public int score = 0;
    Transform t;

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

        rb.AddForce(actual_movement);

    }

    void OnMove(InputValue movement)
    {
        m = movement.Get<Vector2>();
    }

    void OnTriggerEnter(Collider chest)
    {
        score = score + 1;
        print("Score: " + score); 
    }

}
