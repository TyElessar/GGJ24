using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collaboration : MonoBehaviour
{
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
        Destroy(gameObject);
    }
    public void Girl()
    {
        Stats.Viewers -= m_ViewersDecrement;
        Stats.Health += m_HealthAugment;
        Destroy(gameObject);
    }
}
