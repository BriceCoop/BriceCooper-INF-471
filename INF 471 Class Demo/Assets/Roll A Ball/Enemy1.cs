using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public GameObject Enemy_1;
    Transform trans;
    float speed = 0.01f;
    //float rotation = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       trans = Enemy_1.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotation = rotation + 0.001f;
        //trans.Rotate(rotation,0,0);
        if (trans.position.z < 10) 
        {
            speed = speed * -1;
            
        } else if (trans.position.z > 20)
        {
            speed = speed * -1;
        }

        trans.Translate(0,0,speed);

    }
}
