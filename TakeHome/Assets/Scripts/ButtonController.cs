using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId = "5138479";
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
    [SerializeField] Button button5;
    [SerializeField] bool _testMode = true;
    // [SerializeField] string _iOSGameId = "5138478";
    private string _gameId;
    void Awake()
    {
        button1.interactable = true;
        button2.interactable = false;
        button3.interactable = false;
        button4.interactable = false;
        button5.interactable = false;
        button1.onClick.AddListener(InitializeAds);
    }

    public void InitializeAds()
    {
        Debug.Log("Button 1 clicked...");
        Debug.Log("initializing ads SDK");
        /* _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
             ? _iOSGameId
             : _androidGameId;*/
        _gameId = _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        button2.interactable = true;
        button3.interactable = true;
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
    void OnDestroy()
    {
        // Clean up the button listeners:
        button1.onClick.RemoveAllListeners();
    }
}
