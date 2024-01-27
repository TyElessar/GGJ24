using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Especular : MonoBehaviour
{
    public bool m_OnScreen = false;
    public int m_Clicks, m_NeededClicks = 50,
        ViewersPenalty = 10,
        m_ViewersPenalty = 10,
        m_MoneyReward = 25;
    public float m_Timer, m_TimeToClick = 10f;
    public GameObject m_SorryTxt, SryTextHolder, m_DecisionObject, m_ForgivenessObject;

    Statistics Stats;
    void Start()
    {
        Stats = GameObject.FindWithTag("GameController").GetComponent<Statistics>();
        m_DecisionObject.SetActive(true);
        m_ForgivenessObject.SetActive(false);
    }
    void Update()
    {
        if (m_ForgivenessObject.activeSelf) Forgiveness();
    }
    public void Especulate()
    {
        Stats.Viewers -= m_ViewersPenalty;
        Stats.Money += m_MoneyReward;
        m_DecisionObject.SetActive(false);
        m_ForgivenessObject.SetActive(true);
    }
    public void DontEspeculate()
    {
        Destroy(gameObject);
    }
    void Forgiveness()
    {
        m_Timer -= Time.deltaTime;
        if (m_Timer <= 0 && m_Clicks > 0)
        {
            Stats.Viewers -= m_ViewersPenalty;
            Destroy(gameObject);
        }
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
        //m_Clicks = m_NeededClicks;
        //m_Timer = m_TimeToClick;
    }
}
