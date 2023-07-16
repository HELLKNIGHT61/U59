using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinVideo : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            int whichScene = SceneManager.GetActiveScene().buildIndex;
            if (whichScene == 3)
            {
                SceneManager.LoadScene(4);
            }
            else if (whichScene == 1)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
