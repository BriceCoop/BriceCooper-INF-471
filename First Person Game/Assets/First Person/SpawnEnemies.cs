using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    Vector3 randomVec3;
    int timer = 0;
    [SerializeField]
    GameObject enemy;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomVec3 = new Vector3(Random.value * 50, 0.5f, Random.value * 50);
        enemy.transform.rotation = Quaternion.Euler(0,0,0);
        print(randomVec3);

        timer += 1; 
        if (timer == 720)
        {
            timer -= 720;
            Instantiate(enemy,randomVec3,enemy.transform.rotation);
        }
    }
}
