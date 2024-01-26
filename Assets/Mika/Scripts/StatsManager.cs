using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    int viewers;
    [SerializeField] float streamQuality;

    private void Start()
    {
        InvokeRepeating("DownViewers", 5, 5);
    }
    private void Update()
    {
        print(viewers);
    }
    public void PlusEuros()
    {
        if (streamQuality >= 41 && streamQuality <= 60)
        {
            viewers += 1;
        }
        if (streamQuality >= 61 && streamQuality <= 80)
        {
            viewers += 2;
        }
        if (streamQuality >= 81)
        {
            viewers += 3;
        }
    }
    private void DownViewers()
    {
        if (streamQuality <= 20)
        {
            viewers -= 5;
        }
    }
}
