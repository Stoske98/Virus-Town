using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour
{
    public Text HighScore;
    public Text hsShadow;
    void Start()
    {
        // PlayerPrefs.SetInt("HighScore", 0) ;
        HighScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        hsShadow.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
