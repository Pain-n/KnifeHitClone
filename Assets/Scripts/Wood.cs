using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wood : MonoBehaviour
{
    public float speed;
    private bool ChangeReady = true;

    IEnumerator ChangeSpeed()
    {
        speed = speed + 2;
        ChangeReady = false;
        yield return new WaitForSecondsRealtime(3);
        speed = speed - 2;
        yield return new WaitForSecondsRealtime(3);
        ChangeReady = true;
    }
    void FixedUpdate()
    {
        if(ChangeReady == true)
        {
            StartCoroutine(ChangeSpeed());
        }
        transform.Rotate(0, 0, speed, Space.Self);
    }
}
