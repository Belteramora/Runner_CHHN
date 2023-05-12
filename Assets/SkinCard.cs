using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinCard : MonoBehaviour
{
	[SerializeField]
	private SkinData skinData;

	[HideInInspector]
	public GameObject checkImage;


	public void Start()
	{
		SkinCardController.cards.Add(this);

		checkImage = transform.GetChild(1).GetChild(1).gameObject;

		if(skinData == GameManager.CurrentSkinData)
			checkImage.SetActive(true);
	}

	public void UpdateSkin()
	{
		GameManager.SetSkinData(skinData);

		foreach (var card in SkinCardController.cards)
		{
			card.checkImage.SetActive(false);
		}

		checkImage.SetActive(true);
	}

}
