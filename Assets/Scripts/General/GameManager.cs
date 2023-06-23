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

    [Header("TESTING TOOLS")]
    [SerializeField]
    private float scoreToAutoPlay;

	[SerializeField]
	private float scoreToUsualPlay;

	public static GameData GameData { get; private set; }

    public static bool isGameActive = false;
    public static bool autoPlayed = false;
    public static bool endGame = false;
    public static event Action GameWinned;
	public static event Action GameSetup;
    public static event Action GamePaused;
    public static event Action GameResumed;
    public static event Action GameEnded;
    public static event Action<int> OnCoinsUpdate;
    public static event Action OnAutoPlayEnabled;



    public static SkinData CurrentSkinData { get; private set; }

	public static float currentScore = 0;
    private static float scoreModifier = 0.1f;

	private void Awake() 
	{
        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;
		Instance = this;
    }

	private void Start()
	{
        GameSetup();
        currentScore = 0;
        endGame = false;
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

        if (!endGame)
        {
            if (autoPlayed && currentScore >= Instance.scoreToAutoPlay)
            {
                GameOver(true);
            }
            else if (!autoPlayed && currentScore >= Instance.scoreToUsualPlay)
            {
                GameOver(true);
            }
        }
    }

	public static void GameOver(bool isWin)
    {
		endGame = true;
		isGameActive = false;
        autoPlayed = false;

        if(isWin)
            GameWinned();
        else
            GameEnded();
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

        if(OnAutoPlayEnabled != null)
            OnAutoPlayEnabled();
	}

	private void OnDestroy()
	{
		GameSetup = null;
		GamePaused = null;
		GameResumed = null;
		GameEnded = null;
		OnCoinsUpdate = null;
		OnAutoPlayEnabled = null;
	}
}


