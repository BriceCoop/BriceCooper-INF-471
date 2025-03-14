using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private enum State
    {
        Pace,
        Follow,
    }

    [SerializeField]
    GameObject[] route;
    GameObject target;
    int routeIndex = 0;
    [SerializeField]
    float speed = 2.5f;

    private State currentState = State.Pace;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        switch(currentState)
        {
            case State.Pace:
            OnPace();
            break;
            case State.Follow:
            OnFollow();
            break;
        }
    }

    void OnPace()
    {
        //What do we do when we're pacing?
        //print("I'm pacing");
        target = route[routeIndex];

        MoveTo(target);

        if (Vector3.Distance(transform.position, target.transform.position) < 0.1)
        {
            routeIndex += 1;

            if (routeIndex >= route.Length)
            {
                routeIndex = 0;
            }
        }

        //On what condition do we switch states?

        GameObject obstacle = CheckForward();

        if (obstacle != null)
        {
            target = obstacle;
            currentState = State.Follow;
        }


    }

    void OnFollow()
    {
        //What do when follow?
        print("I'm following");
        MoveTo(target);

        //When do we stop following?
        GameObject obstacle = CheckForward();

        if (obstacle == null)
        {
            currentState = State.Pace;
        }
    }

    void MoveTo(GameObject t)
    {
        transform.position = Vector3.MoveTowards(transform.position, t.transform.position, speed * Time.deltaTime);
        transform.LookAt(t.transform, Vector3.up);
    }

    GameObject CheckForward()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

        if (Physics.Raycast(transform.position,transform.forward, out hit, 100))
        {
            Player_State_Manager player = hit.transform.gameObject.GetComponent<Player_State_Manager>();

            if (player != null)
            {
                if (player.currentState != player.sneakState)
                {
                    print(hit.transform.gameObject.name);
                    return hit.transform.gameObject;
                }
                
            }
        }

        return null;
    }
}
