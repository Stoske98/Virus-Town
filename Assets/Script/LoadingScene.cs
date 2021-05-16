using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public string nameSceneLoad;
    public Slider slider;
    // Update is called once per frame
    void Start()
    {
       
        
            StartCoroutine(LoadScene());
            
        
       
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3f);
        AsyncOperation loading = SceneManager.LoadSceneAsync(nameSceneLoad);
        while (loading.isDone == false)
        {
            float progress = Mathf.Clamp01(loading.progress / .9f);
            slider.value = progress;


            yield return null;
        }
    }
}
