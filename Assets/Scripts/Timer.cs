using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public HitDetection player;

    public float currentTime;

    public bool dead;

    public Text timerText;

    public GameObject restartButton;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (player.health > 0)
        {
            currentTime += Time.deltaTime;
            currentTime = Mathf.Round(currentTime * 1000.0f) / 1000.0f;
            timerText.text = "Time: " + currentTime;
        }
        else if (player.health <= 0 && dead == false)
        {
            dead = true;
            timerText.text = "Final Time: " + currentTime;
            restartButton.SetActive(true);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }
}
