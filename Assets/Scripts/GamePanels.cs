using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class GamePanels : MonoBehaviour
{
    public GameObject GamePanel;
    public GameObject LosePanel;
    public GameObject StageIndicator;
    public bool LoseGame = false;
    public bool WinGame = false;
    private GameObject[] WoodPieces;
    public int Points,Apples,Stage,StageUI,BestScore;
    private void Start()
    {
            PlayerScore data = SaveProgressSystem.LoadGame();
            Points = data.Points;
            Apples = data.Apples;
            Stage = data.Stage;
            StageUI = data.StageUI;
            BestScore = data.BestScore;
            GameObject.Find("AppleCounter").GetComponent<TextMeshProUGUI>().text = Apples.ToString();
            GameObject.Find("Points").GetComponent<TextMeshProUGUI>().text = Points.ToString();
            GameObject.Find("LableStageNumber").GetComponent<TextMeshProUGUI>().text = Stage.ToString();
        switch (StageUI)
        {
            case 1:
                StageIndicator.transform.GetChild(0).GetComponent<Image>().color = Color.green;
            break;
            case 2:
                StageIndicator.transform.GetChild(0).GetComponent<Image>().color = Color.green;
                StageIndicator.transform.GetChild(1).GetComponent<Image>().color = Color.green;
                break;
            case 3:
                StageIndicator.transform.GetChild(0).GetComponent<Image>().color = Color.green;
                StageIndicator.transform.GetChild(1).GetComponent<Image>().color = Color.green;
                StageIndicator.transform.GetChild(2).GetComponent<Image>().color = Color.green;
                break;
            case 4:
                StageIndicator.transform.GetChild(0).GetComponent<Image>().color = Color.green;
                StageIndicator.transform.GetChild(1).GetComponent<Image>().color = Color.green;
                StageIndicator.transform.GetChild(2).GetComponent<Image>().color = Color.green;
                StageIndicator.transform.GetChild(3).GetComponent<Image>().color = Color.green;
                break;
            case 5:
                StageIndicator.transform.GetChild(0).GetComponent<Image>().color = Color.green;
                StageIndicator.transform.GetChild(1).GetComponent<Image>().color = Color.green;
                StageIndicator.transform.GetChild(2).GetComponent<Image>().color = Color.green;
                StageIndicator.transform.GetChild(3).GetComponent<Image>().color = Color.green;
                StageIndicator.transform.GetChild(4).GetComponent<Image>().color = Color.green;
                break;
        }
    }

    IEnumerator WinTheGame()
    {
        Vibration.Init();
        Vibration.Vibrate(500);
        Vibration.Cancel();
        GameObject.FindGameObjectWithTag("Wood").transform.gameObject.SetActive(false);
        GameObject.Find("KnifeThrower").transform.gameObject.SetActive(false);
        WoodPieces = GameObject.FindGameObjectsWithTag("WoodPiece");
        foreach (GameObject piece in WoodPieces)
        {
            piece.GetComponent<SpriteRenderer>().enabled = true;
            piece.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            piece.GetComponent<Rigidbody2D>().gravityScale = Random.Range(1, 5);
        }
        Stage += 1;
        if(StageUI == 5)
        {
            StageUI = 1;
        }
        else
        {
            StageUI += 1;
        }
        SaveProgressSystem.SaveGame(this);
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void LoseTheGame()
    {  
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
    void Update()
    {
        if (LoseGame == true)
        {
            if (Points > BestScore)
            {
                BestScore = Points;
            }
            Points = 0;
            Stage = 1;
            StageUI = 1;
            SaveProgressSystem.SaveGame(this);
            GamePanel.SetActive(false);
            LosePanel.SetActive(true);
        }
        if(WinGame == true)
        {
            StartCoroutine(WinTheGame());
        }
    }
}
