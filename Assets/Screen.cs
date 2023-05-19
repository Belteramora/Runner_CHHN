using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Screen : MonoBehaviour
{
	[HideInInspector]
	public CanvasGroup canvasGroup;

	private void Start()
	{
		canvasGroup = GetComponent<CanvasGroup>();
	}
}
