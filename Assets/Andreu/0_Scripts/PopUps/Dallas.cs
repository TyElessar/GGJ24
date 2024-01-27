using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dallas : MonoBehaviour
{
    public bool m_OnScreen = false;
    public int m_Clicks, m_NeededClicks = 50,
        ViewersPenalty = 10,
        m_ViewersPenalty = 10,
        m_MoneyReward = 25;
    public float m_Timer, m_TimeToClick = 10f;
    public GameObject m_BrokenGlass, m_SorryTxt, SryTextHolder;

    void Update()
    {
        /*m_Time -= Time.deltaTime;
        if(m_Time <= 0 && m_Clicks > 0)
        {
            m_BrokenGlass.SetActive(true);
            Destroy(gameObject);
        }*/
        if (m_Clicks == 0)
        {
            Destroy(gameObject);
        }
    }
    public void Click()
    {
        m_Clicks--;
        Vector3 SryPosition = new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), Random.Range(-Screen.height / 2, Screen.height / 2), 0f);
        GameObject SryTXT = Instantiate(m_SorryTxt);
        SryTXT.transform.parent = SryTextHolder.transform;
        SryTXT.transform.localPosition = SryPosition;
    }
    public void GetPullIn(Vector2 InScreenPosition)
    {
        transform.position = InScreenPosition;
        m_OnScreen = true;
    }
    public void GetPullOut()
    {
        transform.position = new Vector3(Screen.width * 5, Screen.height * 5, 0f);
        ResetValues();
        m_OnScreen = false;
    }
    public void ResetValues()
    {
        m_Clicks = m_NeededClicks;
        m_Timer = m_TimeToClick;
    }
}
