using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Screen : MonoBehaviour
{
	protected 
    private CanvasGroup canvasGroup;

    private float menuTrasitionDuration = 0.3f;

    [SerializeField]
    private float topdownSlidePos;

	private void Start()
	{
		canvasGroup = GetComponent<CanvasGroup>();
	}

	public void TransitTo(CanvasGroup toScreen)
    {
		HideShowScreen(canvasGroup, 0);
        AnimateMove(canvasGroup.transform as RectTransform, Vector2.zero, new Vector2(0, -topdownSlidePos));
		HideShowScreen(toScreen, 1);
        AnimateMove(toScreen.transform as RectTransform, new Vector2(0, topdownSlidePos), Vector2.zero);
    }

	protected void HideShowScreen(CanvasGroup screen, int hide)
    {
        Debug.Log(screen.name + " is fading");
		screen.DOFade(hide, menuTrasitionDuration - 0.1f).SetDelay(0.2f);
		screen.interactable = hide == 1;
		screen.blocksRaycasts = hide == 1;

        Debug.Log("Final: " + screen.name + " alpha=" + screen.alpha + " inter=" + screen.interactable + " block=" + screen.blocksRaycasts); 
	}

    protected void AnimateMove(RectTransform targetTransform, Vector2 startValue, Vector2 endValue)
    {
        targetTransform.anchoredPosition = startValue;
        targetTransform.DOAnchorPos(endValue, menuTrasitionDuration).SetDelay(0.2f);
    }

	public void OnButtonClick(GameObject thisButton)
	{
		Sequence btnSeq = DOTween.Sequence();
		btnSeq.Append(thisButton.transform.DOScale(0.95f, 0.1f));
		btnSeq.Append(thisButton.transform.DOScale(1f, 0.1f));
		btnSeq.onComplete = () => { OnButtonAnimComplete(thisButton); };
		btnSeq.Play();
	}

	protected virtual void OnButtonAnimComplete(GameObject button)
	{
		
	}
}
