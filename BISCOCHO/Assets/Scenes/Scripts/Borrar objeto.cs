using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borrarobjeto : MonoBehaviour
{
    public GameObject susto;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(susto);
                

        }
    }
}
