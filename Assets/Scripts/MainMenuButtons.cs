using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuButtons : MonoBehaviour
{
    private void Start()
    {
        PlayerScore data = SaveProgressSystem.LoadGame();
        this.GetComponent<GamePanels>().Points = 0;
        this.GetComponent<GamePanels>().Stage = 1;
        this.GetComponent<GamePanels>().StageUI = 1;
        this.GetComponent<GamePanels>().Apples = data.Apples;
        this.GetComponent<GamePanels>().BestScore = data.BestScore;
        SaveProgressSystem.SaveGame(this.GetComponent<GamePanels>());
        GameObject.Find("AppleCounter").GetComponent<TextMeshProUGUI>().text = data.Apples.ToString();
        GameObject.Find("BestScore").GetComponent<TextMeshProUGUI>().text = data.BestScore.ToString();

    }
    public void GameStart()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
}
