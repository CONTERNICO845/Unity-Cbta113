using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public GameObject Screamer1;
    public float tiempo;
    void Start()
    {
        Destroy(gameObject, tiempo);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(Screamer1);
            Destroy(gameObject);


        }
    }
}
