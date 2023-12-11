using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booo0000 : MonoBehaviour
{
    public GameObject Susto;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(Susto);
            Destroy(gameObject);
        }
    }
}
