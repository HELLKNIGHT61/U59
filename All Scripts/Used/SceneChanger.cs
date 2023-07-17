using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            int whichScene = SceneManager.GetActiveScene().buildIndex;
            if(whichScene==0)
            {
                SceneManager.LoadScene(1);
            }
            else if(whichScene==1) 
            {
            SceneManager.LoadScene(2);
            }
        }
    }
}
