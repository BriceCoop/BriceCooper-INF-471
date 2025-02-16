using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class First_Person_Controller : MonoBehaviour
{

    private enum State
    {
        Full,
        Hungry,
        Dead,
    }

    public Slider HealthBar;
    float maxHealth = 10f;
    public Slider hungerBar;
    float maxHunger = 50f;
    Vector2 movement;
    Vector2 mouseMove;
    float cameraUp = 0;
    bool hasJumped;
    CharacterController control;
    [SerializeField]
    float playerspeed = 7.0f;
    [SerializeField]
    float mouseSensitivity = 100.0f;
    [SerializeField]
    GameObject cam;
    [SerializeField]
    GameObject BulletSpawner;
    [SerializeField]
    float health = 10;
    [SerializeField]
    GameObject Text;
    [SerializeField]
    float hunger;
    //[SerializeField]
    //GameObject Bullet;

    private State currentState = State.Full;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        control = GetComponent<CharacterController>();
        health = maxHealth;
        hunger = maxHunger;
    }

    // Update is called once per frame
    void Update()
    {

        float lookX = mouseMove.x * Time.deltaTime * mouseSensitivity;
        float lookY = mouseMove.y * Time.deltaTime * mouseSensitivity;

        cameraUp -= lookY;

        cameraUp = Mathf.Clamp(cameraUp, -90, 90);

        cam.transform.localRotation = Quaternion.Euler(cameraUp,0,0);

        transform.Rotate(Vector3.up * lookX);

        float moveX = movement.x;
        float moveZ = movement.y;
        

        Vector3 actual_movement = (transform.forward * moveZ) + (transform.right * moveX);
        
        if (hasJumped)
        {
            hasJumped = false;
            actual_movement.y = 10;
        }

        actual_movement.y -= 20 * Time.deltaTime;
        
        control.Move(actual_movement * Time.deltaTime * playerspeed);
        
        hungerBar.value = hunger;
        HealthBar.value = health;

        switch(currentState)
        {
            case State.Full:
            OnFull();
            break;
            case State.Hungry:
            OnHungry();
            break;
            case State.Dead:
            OnDead();
            break;
        }
    }

    void OnFull()
    {
        print("I'm full");
        hunger -= 1f * Time.deltaTime;
        if (hunger <= 0)
        {
            currentState = State.Hungry;
        }
    }

    void OnHungry()
    {
        print("I'm hungry");
        health -= 0.5f * Time.deltaTime;
        if (health <= 0.0f)
        {
            currentState = State.Dead;
        }
    }

    void OnDead()
    {
        print("You died");
        Text.SetActive(true);
    }

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnLook(InputValue LookVal)
    {
        mouseMove = LookVal.Get<Vector2>();
    }

    void OnJump()
    {
        hasJumped = true;
    }

    //void OnAttack()
    //{
    //    Instantiate(Bullet, BulletSpawner.transform.position, BulletSpawner.transform.rotation);
    //}

    void OnTriggerEnter(Collider other)
    {
        hunger = 50;
        currentState = State.Full;
    }
}