using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class JumpScareStatus : MonoBehaviour
{
    public bool  JumpScareFinish;
    void Update()
    {
        if (JumpScareFinish == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
