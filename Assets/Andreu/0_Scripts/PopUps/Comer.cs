using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comer : MonoBehaviour
{
    public bool m_OnScreen = false;
    public int m_HealthReward = 50, m_ViewersPenalty = 10;
    public GameObject m_ManchaPantalla;

    Statistics Stats;
    void Start()
    {
        Stats = GameObject.FindWithTag("GameController").GetComponent<Statistics>();
    }
    public void AComer()
    {
        Stats.Health += m_HealthReward;
        Stats.Viewers -= m_ViewersPenalty;
        if(!m_ManchaPantalla.activeSelf) m_ManchaPantalla.SetActive(true);
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
