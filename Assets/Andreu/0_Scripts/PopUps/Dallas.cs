using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dallas : MonoBehaviour
{
    public int m_Clicks = 50;
    //public float m_Time = 10f;
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
}
