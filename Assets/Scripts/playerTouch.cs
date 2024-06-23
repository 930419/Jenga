using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class playerTouch : MonoBehaviour
{
    public GameObject cake;
    [SerializeField] private GameObject pan;
    [SerializeField] private GameObject foodManager;
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject leftWall;
    Vector3 initialPos;
    private Rigidbody2D cakeRb;
    private bool isDragging = false;
    public bool turnOver = false;
    private float diffferX = 0f;
    private float rightWallX = 0f;
    private float leftWallX = 0f;
    // Start is called before the first frame update
    void Start()
    {  
        rightWallX = rightWall.transform.position.x - 1f;
        leftWallX = leftWall.transform.position.x + 1.5f;
        initialPos = pan.transform.position;
        cakeRb = cake.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cake = foodManager.GetComponent<foodCreate>().foods[foodManager.GetComponent<foodCreate>().whichFood];
        cakeRb = cake.GetComponent<Rigidbody2D>();
        if(!turnOver){
            drag();
        }
    }

    void drag(){
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch(touch.phase)
            {
                case TouchPhase.Began:
                    // 檢測觸摸是否在方塊上
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    Collider2D collider = Physics2D.OverlapPoint(touchPosition);
                    if(collider != null && (collider.gameObject == pan || collider.gameObject == cake))
                    {
                        isDragging = true;
                    }
                    break;

                case TouchPhase.Moved:
                    // 跟隨手指移動
                    if(isDragging)
                    {
                        float newX = Camera.main.ScreenToWorldPoint(touch.position).x; 
                        if(newX <= rightWallX && newX >= leftWallX){
                            diffferX = newX - pan.transform.position.x;
                            Vector2 panNewPos = new Vector2(newX, pan.transform.position.y);
                            Vector2 cakeNewPos = new Vector2(cake.transform.position.x + diffferX, cake.transform.position.y);
                            pan.transform.position = panNewPos;
                            cake.transform.position = cakeNewPos;
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    // 放開手指，開始下墜
                    if(isDragging)
                    {
                       
                        isDragging = false;
                        cakeRb.gravityScale = 3f + (PlayerPrefs.GetInt("level") - 1) * 0.2f; // 啟用重力
                        turnOver = true;
                        StartCoroutine(WaitForThreeSeconds());
                    }
                    break;
            }
        }
    }
    IEnumerator WaitForThreeSeconds()
    {
        yield return new WaitForSeconds(1f);
        pan.transform.position = initialPos;
    }
}