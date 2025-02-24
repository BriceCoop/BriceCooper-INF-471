using UnityEngine;
using UnityEngine.InputSystem;

public class Player_State_Manager : MonoBehaviour
{

    public Player_BaseState currentState;

    public Player_IdleState idleState = new Player_IdleState();
    public Player_WalkState walkState = new Player_WalkState();
    public Player_SneakState sneakState = new Player_SneakState();

    [HideInInspector]
    public Vector2 movement;
    public Vector2 mouseMove;
    CharacterController controller;
    public float DefaultSpeed = 1;
    float cameraUp = 0;
    [SerializeField]
    GameObject cam;
    [SerializeField]
    float mouseSensitivity = 20.0f;
    [SerializeField]
    int health = 5;

    public bool isSneaking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();

        SwitchState(idleState); 
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnMove(InputValue MoveVal)
    {
        movement = MoveVal.Get<Vector2>();
    }

    void OnLook(InputValue LookVal)
    {
        mouseMove = LookVal.Get<Vector2>();
    }

    void OnSprint(InputValue sprintVal)
    {
        if (sprintVal.isPressed)
        {
            isSneaking = true;
        } else
        {
            isSneaking = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        health -= 1;
    }

    public void MovePlayer(float speed)
    {
        float moveX = movement.x;
        float moveZ = movement.y;

        Vector3 actual_movement = (transform.forward * moveZ) + (transform.right * moveX);
        controller.Move(actual_movement * Time.deltaTime * speed);
    }

    public void MoveCamera()
    {
        float lookX = mouseMove.x * Time.deltaTime * mouseSensitivity;
        float lookY = mouseMove.y * Time.deltaTime * mouseSensitivity;

        cameraUp -= lookY;

        cameraUp = Mathf.Clamp(cameraUp, -90, 90);

        cam.transform.localRotation = Quaternion.Euler(cameraUp,0,0);

        transform.Rotate(Vector3.up * lookX);
    }

    public void SwitchState(Player_BaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}
