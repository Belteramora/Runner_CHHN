using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScreenController : ScreenController
{
	[SerializeField]
	private Image background;

	public void InFadeBackground()
	{
		background.DOFade(0, menuTrasitionDuration);
	}

	public void OutFadeBackground()
	{
		background.DOFade(0.5f, menuTrasitionDuration);
	}

}
