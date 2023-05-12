using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UIElements;
using Unity.Mathematics;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;

    public static GameData GameData { get; private set; }

    public static bool isGameActive = false;
    public static bool autoPlayed = false;
    public static event Action GameSetup;
    public static event Action GamePaused;
    public static event Action GameResumed;
    public static event Action<bool> GameEnded;
    public static event Action<int> OnCoinsUpdate;
    public static event Action OnAutoPlayEnabled;

    public static SkinData CurrentSkinData { get; private set; }

	public static float currentScore = 0;
    private static float autoScore = 0;
    private static float scoreModifier = 0.1f;

	private void Awake() 
	{
        Instance = this;
        GameSetup = null;
        GamePaused = null;
        GameResumed = null;
        GameEnded = null;
        OnCoinsUpdate = null;
        OnAutoPlayEnabled = null;
}

	private void Start()
	{

        GameSetup();
        currentScore = 0;

        PauseGame();
	}

	public static void Load()
    {
        SaveManager.LoadGameData();

        CurrentSkinData = Resources.Load<SkinData>(SaveManager.GameData.savedSkinData);
	}

    public static void Save()
    {
        SaveManager.SaveGameData();
    }
    
    public static void UpdateScore(int coinNomValue)
    {
        currentScore += coinNomValue;

        if (autoPlayed && currentScore >= 500)
        {
			autoPlayed = false;

			GameOver(true);
		}
        else if(!autoPlayed && currentScore >= 1500)
        {
            GameOver(true);
        }
    }

	public static void GameOver(bool isWin)
    {
        isGameActive = false;
        autoPlayed = false;
        GameEnded(isWin);
    }
    
    public void PauseGame()
    {
        isGameActive = false;

        GamePaused();
    }

    public void ResumeGame()
    {
        isGameActive = true;
        GameResumed();
    }

    public static void SetSkinData(SkinData skinData)
    {
        CurrentSkinData = skinData;
        SaveManager.SetSkinData(skinData);
    }

    public static void AutoPlay() 
    {
		autoPlayed = true;
        autoScore = 0;

        if(OnAutoPlayEnabled != null)
            OnAutoPlayEnabled();
	}

}


