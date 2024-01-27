using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Especular : MonoBehaviour
{

    public int m_Clicks = 50, m_ViewersPenalty = 10, m_MoneyReward = 25;
    public float m_Time = 10f;
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
        m_Time -= Time.deltaTime;
        if (m_Time <= 0 && m_Clicks > 0)
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
}
