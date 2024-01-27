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
        GetPullOut();
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
        GetPullOut();
    }
    public void GetPullIn(Vector2 InScreenPosition)
    {
        transform.position = InScreenPosition;
    }
    public void GetPullOut()
    {
        transform.position = new Vector3(Screen.width * 5, Screen.height * 5, 0f);
    }
}
