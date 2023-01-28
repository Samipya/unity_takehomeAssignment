using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class LoadInterstitial : MonoBehaviour, IUnityAdsLoadListener
{
    public static LoadInterstitial instance;
    [SerializeField] Button button2;
    [SerializeField] Button button4;
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    string _adUnitId;
    private void Awake()
    {
        instance = this;
        _adUnitId = _androidAdUnitId;
        button2.onClick.AddListener(LoadAd);
    }
    public void LoadAd()
    {
     
        Debug.Log("Loading Interstitial Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Loading Interstitial Ad completed " + _adUnitId);
        button4.interactable= true;
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
   
    }
    void OnDestroy()
    {
        // Clean up the button listeners:
        button2.onClick.RemoveAllListeners();
    }

}
