using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCreator : MonoBehaviour
{
    public GameObject ApplePrefab,KnifePrefab;
    private int RandomApples;
    private int Rotation;
    GameObject Apple,Knife;
    public ScriptableApple SApple;

    private void KnifeCreate()
    {
        Knife = Instantiate(KnifePrefab, transform);
        Knife.transform.position = new Vector3(0, -0.5f, 0);
        Knife.GetComponent<Knife>().IsInWood = true;
        Knife.transform.RotateAround(this.transform.position, new Vector3(0, 0, 1), Rotation + 30);
    }
    void Start()
    {
        Rotation = 0;
        int CazinoApple = Random.Range(1, 100);
        int CazinoKnife = Random.Range(1,3);
        KnifeCreate();
        if (CazinoApple > 0 && CazinoApple < SApple.AppearChance+1)
        {
            RandomApples = Random.Range(1, 4);
            switch (RandomApples)
            {
                case 1:
                    for (int i = 0; i < 1; i++)
                    {
                        Apple = Instantiate(ApplePrefab, transform);
                        KnifeCreate();
                    }
                    break;
                case 2:
                    for (int i = 0; i < 2; i++)
                    {
                        Apple = Instantiate(ApplePrefab, transform);
                        Rotation = Rotation + 60;
                        Apple.transform.RotateAround(this.transform.position, new Vector3(0, 0, 1), Rotation);

                    }
                    for (int j = 0; j < CazinoKnife; j++)
                    {
                        KnifeCreate();
                    }
                    break;
                case 3:
                    for (int i = 0; i < 3; i++)
                    {
                        Apple = Instantiate(ApplePrefab, transform);
                        Rotation = Rotation + 60;
                        Apple.transform.RotateAround(this.transform.position, new Vector3(0, 0, 1), Rotation);
                    }
                    for (int j = 0; j < CazinoKnife; j++)
                    {
                        KnifeCreate();
                    }
                    break;
                case 4:
                    for (int i = 0; i < 4; i++)
                    {
                        Apple = Instantiate(ApplePrefab, transform);
                        Rotation = Rotation + 60;
                        Apple.transform.RotateAround(this.transform.position, new Vector3(0, 0, 1), Rotation);
                    }
                    for (int j = 0; j < CazinoKnife; j++)
                    {
                        KnifeCreate();
                    }
                    break;
            }
        }
    }


}
