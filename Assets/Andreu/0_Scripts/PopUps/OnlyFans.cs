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
    public void YesOF()
    {
        Stats.Money++;
        Stats.Viewers++;
        Stats.Health--;

        GetPullOut();
    }
    public void NoOF()
    {
        Debug.Log("Menudo monger");
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
