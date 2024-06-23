using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class startControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Time.timeScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startMenu(){
        SceneManager.LoadScene("Level1");
    }
}
