using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyFans : MonoBehaviour
{
    Statistics Stats;
    void Start()
    {
        Stats = GameObject.FindWithTag("GameController").GetComponent<Statistics>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void YesOF()
    {
        Stats.Money++;
        Stats.Viewers++;
        Stats.Health--;

        Destroy(gameObject);
    }
    public void NoOF()
    {
        Debug.Log("Menudo monger");
        Destroy(gameObject);
    }
}
