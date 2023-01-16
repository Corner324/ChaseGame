using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Timer : MonoBehaviour
{

Image timerBar;
public float maTime = 20f;
float timeLeft;

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
        }
        else{
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    
}
