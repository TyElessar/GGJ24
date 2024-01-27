using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusGoUp : MonoBehaviour
{
    void Update()
    {
        transform.position = transform.position + Vector3.up * 5000 * Time.deltaTime;
    }
}
