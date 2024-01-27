using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotoPolla : MonoBehaviour
{
    public int m_Clicks = 50, ViewersPenalty= 10;
    public float m_Time = 10f;
    public AudioClip m_MoanAudio;

    Statistics Stats;
    void Start()
    {
        Stats = GameObject.FindWithTag("GameController").GetComponent<Statistics>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Time -= Time.deltaTime;
        if (m_Time <= 0 && m_Clicks > 0)
        {
            Stats.Viewers -= ViewersPenalty;
            Stats.Strikes++;
            Destroy(gameObject);
        }
        if (m_Clicks == 0)
        {
            Destroy(gameObject);
        }
    }
    public void Click()
    {
        if (GetComponent<AudioSource>().clip != m_MoanAudio) GetComponent<AudioSource>().clip = m_MoanAudio;
        GetComponent<AudioSource>().Play();
        m_Clicks--;
    }
}
