using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{

    public GameObject JumpScareObj;
    public GameObject thePlayer;
    public GameObject Moustro;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            thePlayer.SetActive(false);
            Moustro.SetActive(false);
            JumpScareObj.SetActive(true);
        }
    }

}
