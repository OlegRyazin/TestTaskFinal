using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> UI_List = new List<GameObject> ();
    [SerializeField]
    private List<GameObject> FiresUI = new List<GameObject> ();
    [SerializeField]
    private Text[] textScores;
    [SerializeField]
    private GameObject player;

    private int bestScore = 0;
    private int score = 0;

    void Start()
    {
        FireUIChange(2);
    }

    public void FireUIChange(int count)
    {
        for (int i = 0; i < FiresUI.Count; i++)
        {
            if (i < count) FiresUI[i].SetActive(true);
            else FiresUI[i].SetActive(false);
        }
    }

    public void GameStart()
    {
        UI_List[0].SetActive(false);
        UI_List[1].SetActive(true);
        Player.isGameRun = true; 
        player.SetActive(true);
    }

    public void GameFinish()
    {
        if(score > bestScore)
        {
            bestScore = score;
            textScores[1].text = "Best score: " + bestScore;
        }
        textScores[2].text = "Last score: " + score;
        score = 0;
        textScores[0].text = "Score: " + score;
        UI_List[1].SetActive(false);
        UI_List[0].SetActive(true);
    }
    public void ScoreUpAndChange()
    {
        score += 10;
        textScores[0].text = "Score: " + score;
    }
}
