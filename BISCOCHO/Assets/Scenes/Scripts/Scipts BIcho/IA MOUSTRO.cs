using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class IAMOUSTRO : MonoBehaviour
{
    public Transform destino1, destino2, destino3, destino4, destino5, destino6, destino7, destino9, destino10, player;
    bool teleporting = true;
    public float teleportRate;
    int randomNum;
    void Start()
    {
        StartCoroutine(Teleport());
    }
   void Update ()
    {
        this.transform.LookAt(new Vector3(player.position.x, this.transform.position.y, player.position.z));
    }
    IEnumerator Teleport()
    {
        

        while(teleporting == true )
        {
            yield return new WaitForSeconds(teleportRate);
            randomNum = Random.Range(0, 10);
            if(randomNum == 0) {
                this.transform.position = destino1.position; 
}
            if (randomNum == 1)
            {
                this.transform.position = destino2.position;
            }
            if (randomNum == 2)
            {
                this.transform.position = destino3.position;
            }
            if (randomNum == 3)
            {
                this.transform.position = destino4.position;
            }
            if (randomNum == 4)
            {
                this.transform.position = destino5.position;
            }
            if (randomNum == 5)
            {
                this.transform.position = destino6.position;
            }
            if (randomNum == 6)
            {
                this.transform.position = destino7.position;
            }
            if (randomNum == 7)
            {
                this.transform.position = destino9.position;
            }
            if (randomNum == 8)
            {
                this.transform.position = destino10.position;
            }
        }

    }
}
