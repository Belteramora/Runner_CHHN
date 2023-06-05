using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScreenController : ScreenController
{
	[SerializeField]
	private Image background;

	private void Start()
	{
		AnimatedBuilding.OnPlayerGoToDoor += OnGameWinned;
		WinTrigger.ResetEvent();
		WinTrigger.onWinTriggerEnter += OnWinTriggerEnter;

		GameManager.GameEnded += OnDeath;
	}
	public void InFadeBackground()
	{
		background.DOFade(0, menuTrasitionDuration);
	}

	public void OutFadeBackground()
	{
		background.DOFade(0.5f, menuTrasitionDuration);
	}

	public void OnGameWinned()
	{
		OutFadeBackground();
		GetScreens();
		Screen screen = screens.Find((x) => { return x.name == "FinishScreen"; });
		OutFadeAndMove(screen);

	}

	public void OnWinTriggerEnter()
	{
		GetScreens();
		InFadeAndMove(screens.Find((x) => { return x.name == "InGameScreen"; }));
	}

	public void OnDeath()
	{
		GetScreens();
		InFadeAndMove(screens[1]);
		OutFadeAndMove(screens[2]);
		OutFadeBackground();
	}
}
