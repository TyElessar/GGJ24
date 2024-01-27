using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collaboration : MonoBehaviour
{
    public bool m_OnScreen = false;
    public int m_ViewersAugment,
        m_HealthDecrement,
        m_ViewersDecrement,
        m_HealthAugment;
    Statistics Stats;
    void Start()
    {
        Stats = GameObject.FindWithTag("GameController").GetComponent<Statistics>();
    }
    public void Boy()
    {
        Stats.Viewers += m_ViewersAugment;
        Stats.Health -= m_HealthDecrement;
        GetPullOut();
    }
    public void Girl()
    {
        Stats.Viewers -= m_ViewersDecrement;
        Stats.Health += m_HealthAugment;
        GetPullOut();
    }
    public void GetPullIn(Vector2 InScreenPosition)
    {
        transform.position = InScreenPosition;
        m_OnScreen = true;
    }
    public void GetPullOut()
    {
        transform.position = new Vector3(Screen.width * 5, Screen.height * 5, 0f);
        m_OnScreen = false;
    }
}
