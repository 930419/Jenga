using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class scoreLineTouch : MonoBehaviour
{
    [SerializeField] GameObject scoreLine;
    [SerializeField] GameObject pan;
    [SerializeField] private UnityEvent gameWin;
    public GameObject cake;
    public GameObject foodManager;
    private Rigidbody2D cakeRb;
    private bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        if(scoreLine.transform.position.y + PlayerPrefs.GetInt("level") * 0.6f < pan.transform.position.y - 1f){
          Vector2 up = new Vector2(scoreLine.transform.position.x, scoreLine.transform.position.y + PlayerPrefs.GetInt("level") * 0.6f);
            scoreLine.transform.position = up;  
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(foodManager.GetComponent<foodCreate>().whichFood != 0){
            cake = foodManager.GetComponent<foodCreate>().foods[foodManager.GetComponent<foodCreate>().whichFood - 1];
            cakeRb = cake.GetComponent<Rigidbody2D>();        
            if(!won && cake.transform.position.y + 0.25f > scoreLine.transform.position.y){
                gameWin?.Invoke();
                won = true;
            }
        }

    }
}
