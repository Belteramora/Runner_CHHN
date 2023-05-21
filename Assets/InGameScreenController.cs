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
		OutFadeAndMove(screens[0]);
	}

	public void OnWinTriggerEnter()
	{
		InFadeAndMove(screens[1]);
	}

	public void OnDeath()
	{
		InFadeAndMove(screens[1]);
		OutFadeAndMove(screens[2]);
		OutFadeBackground();
	}
}
