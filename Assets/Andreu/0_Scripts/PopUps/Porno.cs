using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porno : MonoBehaviour
{
    public bool m_OnScreen = false;
    private bool m_Invoked = false;
    public float m_Timer, m_TimeToClick = 7.5f;
    //public GameObject m_StrikeAlert;

    Statistics Stats;
    void Start()
    {
        Stats = GameObject.FindWithTag("GameController").GetComponent<Statistics>();
        m_Timer = m_TimeToClick;
    }
    void Update()
    {
        if (m_OnScreen)
        {
            m_Timer -= Time.deltaTime;
            if (m_Timer <= 0)
            {
                Stats.Strikes++;
                GetPullOut();
            }
        }

        if (m_OnScreen && !m_Invoked)
        {
            InvokeRepeating("ChangePosition", 2f, 1.5f);
            m_Invoked = true;
        }
        else if(!m_OnScreen) CancelInvoke("ChangePosition");
    }
    void ChangePosition()
    {
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
        m_Timer = m_TimeToClick;
    }
}
