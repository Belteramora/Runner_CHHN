using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{

    [SerializeField]
    private string gameplaySceneName;

	public void Awake()
	{
		if(LanguageChanger.changers != null)
			LanguageChanger.changers.Clear();

		if (GameManager.GameData == null)
			GameManager.Load();

		if (Leaderboard.leaderData == null)
			Leaderboard.LoadLeaderData();
	}

	public void ChangeLanguage()
	{
		if(LanguageChanger.currentLanguage == "en")
		{
			LanguageChanger.currentLanguage = "ru";
		}
		else if(LanguageChanger.currentLanguage == "ru")
		{
			LanguageChanger.currentLanguage = "en";
		}

		foreach(LanguageChanger changer in LanguageChanger.changers)
		{
			changer.OnLanguageChanged();
		}
	}

	public void OnStartPressed()
	{ 
        SceneManager.LoadScene(gameplaySceneName, LoadSceneMode.Single);
    }

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Leaderboard.SaveLeaderData();
		}
	}

}
