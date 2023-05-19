using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedButton : MonoBehaviour
{
	public void OnButtonClick()
	{
		Sequence btnSeq = DOTween.Sequence();
		btnSeq.Append(transform.DOScale(0.95f, 0.1f));
		btnSeq.Append(transform.DOScale(1f, 0.1f));
		btnSeq.onComplete = () => { OnButtonAnimComplete(); };
		btnSeq.Play();
	}

	protected virtual void OnButtonAnimComplete()
	{

	}
}
