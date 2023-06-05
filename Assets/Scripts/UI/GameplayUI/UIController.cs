using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject hpContainerPrefab;

    [SerializeField]
    private GameObject hpSplitter;

    [SerializeField]
    private string startSceneName;

    

	private void Awake()
	{
		PlayerController.OnLoseHP += OnLoseHP;

        HPContainer.HPContainerList = new List<HPContainer>();
	}

	public void OnLoseHP(int currentHP)
    {
        HPContainer.OnLoseHP(currentHP);
    }

    public void AutoPlayOn()
    {
        GameManager.AutoPlay();
    }

    public void OnExitButtonPressed()
    {
        GameManager.autoPlayed = false;

        if(Leaderboard.leaderData != null )
        {
            Leaderboard.leaderData.data.Add(new Leaderboard.LeaderData.LeaderItem(GameManager.currentScore.ToString(), DateTime.Now.ToShortTimeString()));
            Leaderboard.SaveLeaderData();
        }

        SceneManager.LoadScene(startSceneName, LoadSceneMode.Single);
    }
}
