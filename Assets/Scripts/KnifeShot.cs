using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeShot : MonoBehaviour
{
    public float force;
    public GameObject knifePrefab;
    GameObject knife;
    void Start()
    {
        knife = Instantiate(knifePrefab, transform);
        knife.transform.localScale = new Vector3(13,15,0);
    }


    void Update()
    {

            if (Input.GetMouseButtonDown(0))
            {
                knife.transform.parent = null;
                knife.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
                knife = Instantiate(knifePrefab, transform);
                knife.transform.localScale = new Vector3(13, 15, 0);
        }
    }
}
