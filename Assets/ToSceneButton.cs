using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSceneButton : AnimatedButton
{
	[SerializeField]
	private string sceneName;

	protected override void OnButtonAnimComplete()
	{
		base.OnButtonAnimComplete();
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}
}
