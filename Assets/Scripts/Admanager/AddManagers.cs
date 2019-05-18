using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using System;


public class AddManagers : MonoBehaviour
{
    public static AddManagers instance;

    public string AppId;

    private BannerView bannerView;

    public string bannerId;

    private InterstitialAd FulScreenAdd;

    public string FullScreenId;

    

    

    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        MobileAds.Initialize(AppId);

        RequestFullScreenAdds();

        RequestBanner();

        FulScreenAdd.OnAdClosed += HandlerOnCloased;
    }

    public void RequestBanner()
    {
        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
        bannerView.Show();
    }

    public void HideBanner()
    {
        bannerView.Hide();
    }

    public void RequestFullScreenAdds()
    {
        FulScreenAdd = new InterstitialAd(FullScreenId);
        AdRequest request = new AdRequest.Builder().Build();
        FulScreenAdd.LoadAd(request);
        
    }

    public void HandlerOnCloased(object sender, EventArgs args)
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowFullScreenAdd()
    {
        if(FulScreenAdd.IsLoaded())
        {
            FulScreenAdd.Show();
        }
        else
        {
            Debug.Log("Adds are not loaded");
        }

        
    }
}
