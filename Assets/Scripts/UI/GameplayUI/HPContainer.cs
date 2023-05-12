using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPContainer : MonoBehaviour, IComparable
{
    public static List<HPContainer> HPContainerList;

    [SerializeField]
    private List<Sprite> hpSprites;

    private Image image;

	// Start is called before the first frame update
	void Start()
    {
		HPContainerList.Add(this);

        HPContainerList.Sort();

		image = GetComponent<Image>();

        if(hpSprites == null)
        {
            hpSprites = new List<Sprite>();
        }
    }

    public static void OnLoseHP(int currentHP)
    {
        HPContainerList[currentHP].image.sprite = HPContainerList[currentHP].hpSprites[1];
		

		Debug.Log("HP Container OnLoseHP");
    }

	public int CompareTo(object obj)
	{
        HPContainer container = obj as HPContainer;
        return string.Compare(name, container.name);
	}
}
