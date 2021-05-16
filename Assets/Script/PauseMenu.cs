using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    public GameObject joystick;

    public Text text;
   // public GameObject button;
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject playAgain;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if(Health.health <=3 )
        {
            endGame();
           // Monetization.showAds("video");
          //  Health.health =3.1f;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Monetization.showAds("video");
        Health.brojZarazenih = 0;
        joystick.SetActive(true);
        // Health.health = 110;
        playAgain.SetActive(false);
        Time.timeScale = 1f;
        if (Fire.scoreSystem > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Fire.scoreSystem);
        }

        Fire.scoreSystem = 0;
        SceneManager.LoadScene("StartLoading");
    }
    public void PlayAgain()
    {
        Monetization.showAds("video");
        Health.brojZarazenih = 0;
        joystick.SetActive(true);
        //  Health.health = 110;
        playAgain.SetActive(false);
        Time.timeScale = 1f;
        if (Fire.scoreSystem > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Fire.scoreSystem);
        }

        Fire.scoreSystem = 0;
        SceneManager.LoadScene("GameLoading");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void endGame()
    {
        Time.timeScale = 0f;
        joystick.SetActive(false);
        playAgain.SetActive(true);
       
        //  GameIsEnded = true;
        //GameIsPaused = true;
    }
   /*IEnumerator pauza()
    {
        
        yield return new WaitForSeconds(4f);
        endGame();
    }*/

    public void adWatch()
    {
        Health.brojZarazenih = 0;
        Health.health = 110;
        text.text = "Infected x0";
        Time.timeScale = 0f;
        playAgain.SetActive(false);
        joystick.SetActive(true);
        
    }
   
}
