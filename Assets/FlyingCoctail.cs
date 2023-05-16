using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCoctail : MonoBehaviour
{
    [SerializeField]
    private GameObject flyingCoctailPrefab;

    private float handledTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.GameResumed += StarterOn;
    }

    public void StarterOn()
    {
		StartCoroutine(FlyRoutine(30f, 0.1f));
	}

	private IEnumerator FlyRoutine(float sec, float step)
    {
        Debug.Log("Started");
        while (true) 
        {
            float temp_i = 0;

            for (float i = 0; i < sec - handledTime; i += step)
            {
                if (GameManager.isGameActive)
                    yield return new WaitForSeconds(step);
                else
                {
                    Debug.Log("i = " + i + "; sec = " + sec  + "; sum time = " + (sec-handledTime));
                    handledTime += i;
                    Debug.Log("handled time = " + handledTime);
                    break;
                }

                temp_i = i;
            }

            if(Mathf.Round(temp_i) == Mathf.Round(sec - handledTime))
            {
                Debug.Log("Spawn time " + (sec - handledTime) + " sec last been");
                handledTime = 0;
            }

            if (handledTime != 0)
            {
                Debug.Log("Break loop");
                break;
            }

            if (!GameManager.autoPlayed && GameManager.isGameActive)
                Instantiate(flyingCoctailPrefab);

        }
    }
}
