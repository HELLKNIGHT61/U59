using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    public bool oyundurdumu = false;
  public void oyunudurdur()
    {
        if (oyundurdumu==false)
        {
            Time.timeScale = 0f;
            oyundurdumu = true; 
        }
        else
        {
            Time.timeScale = 1f;
            oyundurdumu = false;
        }
    }
}
