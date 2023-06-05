using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TestShowHideButton : MonoBehaviour
{
	private TextMeshProUGUI textComponent;
	private bool isHided = true;

	public void Start()
	{
		textComponent = GetComponent<TextMeshProUGUI>();
	}

	public void OnButtonClick()
	{
		RectTransform parentRect = transform.parent as RectTransform;

		if (isHided)
		{
			textComponent.text = ">";
			parentRect.DOAnchorPosX(0, 0.2f);
		}
		else
		{
			textComponent.text = "<";
			parentRect.DOAnchorPosX(450, 0.2f);

		}

		isHided = !isHided;
	}
}
