using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class foodCreate : MonoBehaviour
{
    public GameObject pan;
    Vector3 initialPos;
    public GameObject firstFood;
    public GameObject foodFloor;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Transform foodManager;
    [SerializeField] private float randomX;
    public List<GameObject> foods;
    public int whichFood = 0;
    // Start is called before the first frame update
    void Start()
    {
        randomX = Random.Range(-2.3f, 0.5f) + 0.6f;
        foodFloor.transform.position = new Vector2(randomX, foodFloor.transform.position.y);
        initialPos = pan.transform.position;
        foods.Add(firstFood);
    }

    // Update is called once per frame
    void Update()
    {
        if(foods[whichFood].GetComponent<foodMove>().touchFloor){
            if(pan.transform.position == initialPos){
            createFood();
            } 
        }
    }
    void createFood()
        {
            GameObject newFood = Instantiate(foodPrefab, foodManager.position, Quaternion.identity);
            newFood.transform.parent = foodManager;
            foods.Add(newFood);
            whichFood += 1;
            pan.GetComponent<playerTouch>().turnOver = false;
        }
}
