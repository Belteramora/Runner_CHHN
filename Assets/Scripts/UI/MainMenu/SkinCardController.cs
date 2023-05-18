using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinCardController : MonoBehaviour
{


	public static List<SkinCard> cards = new();

	// Start is called before the first frame update
	void Awake()
    {
        cards.Clear();
    }
}
