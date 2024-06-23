using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class foodMove : MonoBehaviour
{
    [SerializeField] GameObject pan;
    public bool touchFloor;
    private Rigidbody2D cakeRb;
    // Start is called before the first frame update
    void Start()
    {
        cakeRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject != pan){
            touchFloor = true;
            cakeRb.velocity = Vector2.zero;
            GetComponent<AudioSource>().Play();
        }
    }
}
