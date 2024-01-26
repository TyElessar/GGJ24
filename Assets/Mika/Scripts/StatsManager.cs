using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    int viewers;
    [SerializeField] float streamQuality;
    public float categoryCoolDown;
    [SerializeField] string currentCategory = "null";

    private void Start()
    {
        InvokeRepeating("DownViewers", 5, 5);
    }
    private void Update()
    {
        print(viewers);
        categoryCoolDown = categoryCoolDown - 1 * Time.deltaTime;
    }
    public void PlusEuros()
    {
        if (streamQuality <= 20 && categoryCoolDown > 3)
        {
            viewers += 1;
        }
        if (streamQuality >= 21 && streamQuality <= 40 && categoryCoolDown > 3)
        {
            viewers += 2;
        }
        if (streamQuality >= 41 && streamQuality <= 60 && categoryCoolDown > 3)
        {
            viewers += 4;
        }
        if (streamQuality >= 61 && streamQuality <= 80 && categoryCoolDown > 3)
        {
            viewers += 8;
        }
        if (streamQuality >= 81 && categoryCoolDown > 3)
        {
            viewers += 16;
        }
    }
    public void ChangeCategory(string category)
    {
        if (category != currentCategory)
        {
            currentCategory = category;
            categoryCoolDown = 10;
        }
    }
    private void DownViewers()
    {
        if (categoryCoolDown <= 0)
        {
            viewers -= 5;
        }
    }
}
