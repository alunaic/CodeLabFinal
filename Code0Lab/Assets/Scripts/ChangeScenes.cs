using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public string SceneName; 
    public void OnTriggerEnter( Collider other)
    {
        SceneSwitch();
        Debug.Log ("go to ending");
        
                // got to scene 2
    }
    public void SceneSwitch () {
        SceneManager.LoadScene (SceneName);
        }
}
