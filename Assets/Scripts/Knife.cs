using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Knife : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public bool IsInWood;
    public ScriptableKnife SKnife;

    private void Start()
    {
        this.name = SKnife.KnifeName;
        this.GetComponent<Image>().sprite = SKnife.KnifeSkin;
    }

    private void WinTrigger()
    {
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<GamePanels>().WinGame = true;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wood")
        {
            Vibration.Init();
            Vibration.Vibrate(500);
            Vibration.Cancel();
            int AddPoint = int.Parse(GameObject.FindGameObjectWithTag("Points").GetComponent<TextMeshProUGUI>().text)+1;
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<GamePanels>().Points+=1;
            GameObject.FindGameObjectWithTag("Points").GetComponent<TextMeshProUGUI>().text = AddPoint.ToString();
            rigidbody.velocity = Vector2.zero;
            transform.parent = col.transform;
            IsInWood= true;
            if(GameObject.Find("KnifeCounter").GetComponent<KnifeCounter>().KnifeCount == 0)
            {
               WinTrigger();
            }
        }
        if(col.gameObject.tag == "Knife")
        {
            if (col.gameObject.GetComponent<Knife>().IsInWood == true)
            {
                Vibration.Init();
                Vibration.Vibrate(500);
                Vibration.Cancel();
                this.GetComponent<Collider2D>().gameObject.SetActive(false);
                GameObject.Find("KnifeThrower").SetActive(false);
                GameObject.Find("Wood").SetActive(false);
                GameObject.FindGameObjectWithTag("Canvas").GetComponent<GamePanels>().LoseGame = true;
            }
        }
        if(col.gameObject.tag == "Apple")
        {
            for(int i = 0; i < 2; i++)
            {
                col.transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 1;
                col.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(Vector2.up * Random.Range(1,10), ForceMode2D.Impulse);
                col.transform.GetChild(0).SetParent(null);
            }  
            Destroy(col.gameObject);

            int AddApplePoint = int.Parse(GameObject.Find("AppleCounter").GetComponent<TextMeshProUGUI>().text) + 1;
            GameObject.Find("AppleCounter").GetComponent<TextMeshProUGUI>().text = AddApplePoint.ToString();
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<GamePanels>().Apples += 1;
        }
    }
}
