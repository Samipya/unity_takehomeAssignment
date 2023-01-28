using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterManager : MonoBehaviour
{
    public static CounterManager Instance;

    public Text CounterText;
    int counter = 0;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        CounterText.text = "Counter: ";
    }

    public void UpdateCounter()
    {
        counter++;
        CounterText.text = counter.ToString();
        Debug.Log("Counter Value is " + counter);
    }
}
