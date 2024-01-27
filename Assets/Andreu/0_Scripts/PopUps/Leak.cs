using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leak : MonoBehaviour
{
    public bool m_OnScreen = false;
    private bool m_Invoked = false;
    public int m_Clicks, m_NeededClicks = 5,
        m_MoneyPenalty;
    //public GameObject m_StrikeAlert;

    Statistics Stats;
    void Start()
    {
        Stats = GameObject.FindWithTag("GameController").GetComponent<Statistics>();
        m_Clicks = m_NeededClicks;
    }
    void Update()
    {
        if (m_NeededClicks <= 0)
        {
            GetPullOut();
        }
        if (m_OnScreen && !m_Invoked)
        {
            InvokeRepeating("BeRobbed", 2f, 2.5f);
            m_Invoked = true;
        }
        else if (!m_OnScreen) CancelInvoke("BeRobbed");
    }
    void BeRobbed()
    {
        Stats.Money -= m_MoneyPenalty;
    }
    public void Click()
    {
        m_NeededClicks--;
        Vector3 PornPosition = new Vector3(Random.Range(-(Screen.width - 250) / 2, (Screen.width - 250) / 2), Random.Range(-(Screen.height - 250) / 2, (Screen.height - 2) / 2), 0f);
        transform.localPosition = PornPosition;
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
        m_Invoked = false;
    }
    public void ResetValues()
    {
        m_Clicks = m_NeededClicks;
    }
}
