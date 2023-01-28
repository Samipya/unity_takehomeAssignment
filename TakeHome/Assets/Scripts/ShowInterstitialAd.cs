using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class ShowInterstitial : MonoBehaviour, IUnityAdsShowListener
{
    [SerializeField] Button button4;
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    string adUnitId;
    private void Awake()
    {
        adUnitId = _androidAdUnitId;
        button4.onClick.AddListener(ShowAd);
    }
    public void ShowAd()
    {
        Debug.Log("Showing Ad: " + adUnitId);
        Advertisement.Show(adUnitId, this);
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }
    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        button4.onClick.RemoveAllListeners();
    }

}
