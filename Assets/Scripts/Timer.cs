using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Timer : MonoBehaviour
{

Image timerBar;
public Text textTime;
public float maTime = 20f;
private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timeLeft > 0){
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maTime;
            textTime.GetComponent<Text>().text = Convert.ToString(Math.Round(timeLeft,0)) + " seconds";

            if(timeLeft < 4){
                textTime.GetComponent<Text>().color = Color.red;
                textTime.GetComponent<Animator>().enabled = true;
            }
        }
        else{
            textTime.GetComponent<Text>().text = "GameOver";
            textTime.GetComponent<Text>().color = Color.black;
            textTime.GetComponent<Animator>().enabled = false;
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    
}
