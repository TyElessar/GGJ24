using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotoPolla : MonoBehaviour
{
    public bool m_OnScreen = false;
    public int m_Clicks, m_NeededClicks = 50, ViewersPenalty= 10;
    public float m_Timer, m_TimeToClick = 10f;
    public AudioClip m_MoanAudio;

    Statistics Stats;
    void Start()
    {
        Stats = GameObject.FindWithTag("GameController").GetComponent<Statistics>();
        m_Clicks = m_NeededClicks;
    }
    void Update()
    {
        m_Timer -= Time.deltaTime;
        if (m_Timer <= 0 && m_Clicks > 0)
        {
            Stats.Strikes++;
            GetPullOut();
        }
        if (m_Clicks == 0)
        {
            GetPullOut();
        }
    }
    public void Click()
    {
        if (GetComponent<AudioSource>().clip != m_MoanAudio) GetComponent<AudioSource>().clip = m_MoanAudio;
        GetComponent<AudioSource>().Play();
        m_Clicks--;
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
