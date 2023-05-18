using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
	[SerializeField]
	private GameObject logo;

	[SerializeField]
	private CanvasGroup menuScreen;


	private void Start()
	{
		Sequence logoSeq = DOTween.Sequence();
		logoSeq.Append(logo.transform.DOScale(1.2f, 0.5f).SetDelay(0.2f));
		logoSeq.Append(logo.transform.DOScale(1f, 0.5f));
		logoSeq.OnComplete(() =>
		{
			menuScreen.interactable = true;
			menuScreen.blocksRaycasts = true;
		});
		logoSeq.Play();
	}
}
