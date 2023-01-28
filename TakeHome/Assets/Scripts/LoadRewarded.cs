using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class LoadRewarded : MonoBehaviour, IUnityAdsLoadListener
{
    public static LoadRewarded instance;
    [SerializeField] Button button3;
    [SerializeField] Button button5;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    string _adUnitId;
    private void Awake()
    {
        instance = this;
        _adUnitId = _androidAdUnitId;
        button3.onClick.AddListener(LoadAd);
    }
    public void LoadAd()
    {

        Debug.Log("Loading Rewarded Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Loading Rewarded Ad completed " + _adUnitId);
        button5.interactable = true;
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");

    }
    void OnDestroy()
    {
        // Clean up the button listeners:
        button3.onClick.RemoveAllListeners();
    }

}
