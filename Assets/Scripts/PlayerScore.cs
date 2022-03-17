using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerScore
{
    public int Points,Apples,Stage,StageUI,BestScore;

    public PlayerScore(GamePanels PanelsData)
    {
        Points = PanelsData.Points;
        Apples = PanelsData.Apples;
        Stage = PanelsData.Stage;
        StageUI = PanelsData.StageUI;
        BestScore = PanelsData.BestScore;
    }
}
