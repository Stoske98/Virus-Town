using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Monetization : MonoBehaviour, IUnityAdsListener
{
    string placement1 = "video";
    string placement2 = "rewardedVideo";


    public void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize("3571993", true);

        
    }
    public void ShowAd(string p)
    {
        if (!Advertisement.IsReady(p))
        {
            return ;
        }
        else
        {
            Advertisement.Show(p);
        }
            
    }

    public void OnUnityAdsDidError(string message)
    {
       
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
           // Debug.Log("Video Odgledan");
            Time.timeScale = 1f;
        }
        else if(showResult == ShowResult.Failed)
        {
           // Debug.Log("Video nije odgledan zbog greske");
            Time.timeScale = 1f;
        }
        else
        {
            //Debug.Log("Video nije odgledan");
            Time.timeScale = 1f;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }
    public static void showAds(string kindVideo)
    {
        if (!Advertisement.IsReady(kindVideo))
        {
            return;
        }
        else
        {
            Advertisement.Show(kindVideo);
        }

    }
   


}
