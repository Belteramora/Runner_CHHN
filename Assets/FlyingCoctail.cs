using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCoctail : MonoBehaviour
{
    [SerializeField]
    private GameObject flyingCoctailPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.GameResumed += StarterOn;
        GameManager.GamePaused += StarterOff;
    }

    public void StarterOn()
    {
		StartCoroutine(FlyRoutine());
	}

	public void StarterOff()
	{
		StopCoroutine(FlyRoutine());
	}

	private IEnumerator FlyRoutine()
    {

        while (GameManager.isGameActive ) 
        {
			yield return new WaitForSeconds(30f);

            if(!GameManager.autoPlayed)
			    Instantiate(flyingCoctailPrefab);
        }

        yield return null;
    }
}
