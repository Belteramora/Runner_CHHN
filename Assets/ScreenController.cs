using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Device;

public class ScreenController : MonoBehaviour
{
    [SerializeField]
    private List<Screen> screens = new List<Screen>();

	[SerializeField]
	private Vector2 movingPos;

	[SerializeField]
	protected float menuTrasitionDuration;


	public void InFadeAndMove(Screen screen)
    {
		HideShowScreen(screen.canvasGroup, 0);
		AnimateMove(screen.canvasGroup.transform as RectTransform, Vector2.zero, movingPos);
	}

	public void OutFadeAndMove(Screen screen)
	{
		HideShowScreen(screen.canvasGroup, 1);
		AnimateMove(screen.canvasGroup.transform as RectTransform, -movingPos, Vector2.zero);
	}

	protected void HideShowScreen(CanvasGroup screen, int hide)
	{
		Debug.Log(screen.name + " is fading");
		screen.DOFade(hide, menuTrasitionDuration).SetDelay(0.2f);
		screen.interactable = hide == 1;
		screen.blocksRaycasts = hide == 1;

		Debug.Log("Final: " + screen.name + " alpha=" + screen.alpha + " inter=" + screen.interactable + " block=" + screen.blocksRaycasts);
	}

	protected void AnimateMove(RectTransform targetTransform, Vector2 startValue, Vector2 endValue)
	{
		targetTransform.anchoredPosition = startValue;
		targetTransform.DOAnchorPos(endValue, menuTrasitionDuration).SetDelay(0.2f);
	}
}
