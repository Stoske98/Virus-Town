using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turtorial : MonoBehaviour
{
    public GameObject buttonLeft;
    public GameObject buttonRight;

    public Image[] image;
    public float pomeraj = 500;
    public Toggle toggle;
    // Start is called before the first frame update

        private int countImages;
    private int duzinaSlika;

    void Start()
    {
        buttonLeft.SetActive(false);
        duzinaSlika = image.Length - 1;
        countImages = 0 ;
        image[countImages].gameObject.SetActive(true);
        if (PlayerPrefs.GetInt("Turtorial", 0) == 0)
        {
            Time.timeScale = 0f;
            gameObject.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("Turtorial", 0) == 1)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
 

  

    public void slideRight()
    {
        countImages++;
        buttonLeft.SetActive(true);
        if (countImages >= duzinaSlika)
        {
            countImages = duzinaSlika;
            buttonRight.SetActive(false);
        }
        else
        {
            buttonRight.SetActive(true);
        }
       
        for (int i = 0; i <= duzinaSlika; i++)
        {
            if(i == countImages)
            {
                image[i].gameObject.SetActive(true);
            }
            else
            {
                image[i].gameObject.SetActive(false);
            }
        }


    }
    public void slideLeft()
    {
        countImages--;
        buttonRight.SetActive(true);
        if (countImages <= 0)
        {
            countImages = 0;
            buttonLeft.SetActive(false);
        }
        else
        {
            buttonLeft.SetActive(true);
        }
        for (int i = 0; i <= duzinaSlika; i++)
        {
            if (i == countImages)
            {
                image[i].gameObject.SetActive(true);
            }
            else
            {
                image[i].gameObject.SetActive(false);
            }
        }

    }
    public void cont()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        
    }

    public void onOffTurtorial()
    {
        if(!toggle.isOn)
        {
            PlayerPrefs.SetInt("Turtorial",0);

        }
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("Turtorial", 1);
          
        }
    }


}
