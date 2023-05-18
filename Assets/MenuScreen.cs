using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuScreen : Screen
{
	[SerializeField]
	private string gameplaySceneName;

	protected override void OnButtonAnimComplete(GameObject button)
	{
		base.OnButtonAnimComplete(button);

		if(button.name == "Start")
		{
			SceneManager.LoadScene(gameplaySceneName, LoadSceneMode.Single);
		}
	}
}
