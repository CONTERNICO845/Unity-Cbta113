using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject PickUptext;
    public GameObject flaslightOnPlayer;

    void Start()
    {
        flaslightOnPlayer.SetActive(false);

        PickUptext.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")

        {
            PickUptext.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {

                this.gameObject.SetActive(false);
                flaslightOnPlayer.SetActive(true);

                PickUptext.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PickUptext.SetActive(false);
    }

}
