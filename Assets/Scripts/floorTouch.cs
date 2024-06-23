using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class floorTouch : MonoBehaviour
{
[SerializeField] private GameObject firstFood;
[SerializeField] private UnityEvent gameLose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject != firstFood){
            gameLose?.Invoke();
        }        
    }
}
