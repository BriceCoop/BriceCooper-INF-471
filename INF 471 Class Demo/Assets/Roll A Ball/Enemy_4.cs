using UnityEngine;

public class Enemy_4 : MonoBehaviour
{
    public GameObject Enemy4;
    Transform trans;
    float speed = 0.025f;
    //float rotation = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       trans = Enemy4.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotation = rotation + 0.001f;
        //trans.Rotate(rotation,0,0);
        if (trans.position.x > -15) 
        {
            speed = speed * -1;
            
        } else if (trans.position.x < -35)
        {
            speed = speed * -1;
        }

        trans.Translate(0,0,speed);

    }
}
