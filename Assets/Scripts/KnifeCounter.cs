using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCounter : MonoBehaviour
{
    public int KnifeCount;

    private void Start()
    {
        KnifeCount = transform.childCount;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                if(transform.GetChild(i).gameObject.activeSelf == true)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                    i = transform.childCount + 1;
                    KnifeCount -= 1;
                }
            }
        }

    }
}
