using UnityEngine;

public class Chests : MonoBehaviour
{

    public GameObject chest;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter (Collider other)
    {
        chest.SetActive(false);
    }
}
