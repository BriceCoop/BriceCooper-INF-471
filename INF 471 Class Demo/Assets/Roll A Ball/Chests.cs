using UnityEngine;
using System.Collections;

public class Chests : MonoBehaviour
{

    public GameObject chest;
    Animator anim;
    bool Collected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Collected", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        StartCoroutine(Collect());
    }

    IEnumerator Collect()
    {
        anim.SetBool("Collected", true);

        yield return new WaitForSeconds(1);
        
        chest.SetActive(false);
    }
}
