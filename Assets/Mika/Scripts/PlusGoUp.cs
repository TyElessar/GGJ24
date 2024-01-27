using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusGoUp : MonoBehaviour
{
    [SerializeField] bool slowDown;
    void Update()
    {
        if (slowDown)
        {
            transform.position = transform.position + Vector3.up * 100 * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + Vector3.up * 500 * Time.deltaTime;
        }
    }
}
