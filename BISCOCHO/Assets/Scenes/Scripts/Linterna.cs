using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{

    Light linterna;

    // Start is called before the first frame update
    void Start()
    {
gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.F)) {

            gameObject.SetActive(!gameObject.activeSelf);
        }


    }
}
