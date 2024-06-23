using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class menuController : MonoBehaviour
{
    [SerializeField] GameObject pauseImage;
    [SerializeField] GameObject winImage;
    [SerializeField] GameObject loseImage;
    [SerializeField] GameObject pauseButton;
    public TextMeshProUGUI levelText;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("level") == 0){
            PlayerPrefs.SetInt("level", 1);
        }
        level = PlayerPrefs.GetInt("level");
        levelText.text = "Level " + level.ToString();    
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void pause(){
        Time.timeScale = 0f;
        pauseImage.SetActive(true);
    }
    public void conti(){
        pauseImage.SetActive(false);
        Time.timeScale = 1f;
    }

    public void exit(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }
    public void gameWin(){
        Time.timeScale = 0f;
        level += 1;
        PlayerPrefs.SetInt("level", level);
        winImage.SetActive(true);
    }
    public void gameLose(){
        Time.timeScale = 0f;
        loseImage.SetActive(true);
    }
    public void loadNextLevel(){
        winImage.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void restart(){
        loseImage.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
        
    }
}
