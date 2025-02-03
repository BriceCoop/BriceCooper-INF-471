using UnityEngine;

public class Door2 : MonoBehaviour
{
    public GameObject gate;    
    public GameObject Player;
    Transform t;
    float speed = 0f;
    public Rollable collect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = gate.GetComponent<Transform>();
        collect = Player.GetComponent<Rollable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collect.score == 8)
        {
            speed = -0.01f;
        }   
        
        t.Translate(0,speed,0);
    }
}
