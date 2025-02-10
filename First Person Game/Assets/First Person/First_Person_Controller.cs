using UnityEngine;
using UnityEngine.InputSystem;

public class First_Person_Controller : MonoBehaviour
{

    Vector2 movement;
    Vector2 mouseMove;
    float cameraUp = 0;
    //Vector3 randomVec3;
    //int timer = 0;
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
    GameObject Bullet;
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    float enemyspeed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        control = GetComponent<CharacterController>();
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
        //Vector3 actual_movement = new Vector3(moveX, 0, moveZ);
        control.Move(actual_movement * Time.deltaTime * playerspeed);

        //randomVec3 = new Vector3(Random.value * 50, 0.5f, Random.value * 50);
        //enemy.transform.rotation = Quaternion.Euler(0,0,0);
        //print(randomVec3);

        //timer += 1; 
        //if (timer == 720)
        //{
        //    timer -= 720;
        //    Instantiate(enemy, randomVec3, enemy.transform.rotation);
        //}

        EnemyChase();
    }

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnLook(InputValue LookVal)
    {
        mouseMove = LookVal.Get<Vector2>();
    }

    void OnAttack()
    {
        Instantiate(Bullet, BulletSpawner.transform.position, BulletSpawner.transform.rotation);
    }

    void EnemyChase()
    {
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, transform.position, enemyspeed * Time.deltaTime);
    }
}