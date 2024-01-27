using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacienda : MonoBehaviour
{
    Statistics Stats;
    void Start()
    {
        Stats = GameObject.FindWithTag("GameController").GetComponent<Statistics>();
    }
    public void APagar()
    {
        Debug.Log("Cuota de autónomo");
        Stats.Money -= Mathf.RoundToInt(Stats.Money*0.25f);
        Destroy(gameObject);
    }
    public void NoPagar()
    {
        if (Random.Range(0,100) <= 5)
        {
            Debug.Log("Bueno pa, cagaste");
            Stats.Money -= Mathf.RoundToInt(Stats.Money * 0.65f);
        }
        else
        {
            Debug.Log("Salvadita");
        }
        Destroy(gameObject);
    }
}
