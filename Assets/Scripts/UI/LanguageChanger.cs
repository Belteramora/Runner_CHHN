using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageChanger : MonoBehaviour
{
	private static LanguageData json;
	public static string currentLanguage = "ru";
	public static List<LanguageChanger> changers;

	[SerializeField]
	private bool spriteObject = true;
	[SerializeField]
	private bool textObject = false;

	private bool onSpriteBoolChanged = true;
	private bool onTextBoolChanged = false;

	private static void LoadJson()
	{
		json = null;
		string jsonText = Resources.Load<TextAsset>("Data/JSON data/LanguageData").text;
		json = JsonUtility.FromJson<LanguageData>(jsonText);
	}

	private void OnValidate() 
	{ 
		if(spriteObject && !onSpriteBoolChanged)
		{
            onSpriteBoolChanged = true;
            onTextBoolChanged = false;
			textObject = false;
		}

		if (textObject && !onTextBoolChanged)
		{
            onTextBoolChanged = true;
            onSpriteBoolChanged = false;
			spriteObject = false;
		}

        if (!textObject && onTextBoolChanged)
            textObject = true;

        if (!spriteObject && onSpriteBoolChanged)
            spriteObject = true;
	}



	public void Start()
	{
		changers ??= new List<LanguageChanger>();

		if (!changers.Contains(this))
			changers.Add(this);

		OnLanguageChanged();
	}

    public void OnLanguageChanged()
    {
		if (json == null)
			LoadJson();

		ObjectToChange objectToChange = json.languageObjects.Find((x) =>
		{
			return x.name == name;
		});

		if (textObject)
		{
			switch (currentLanguage)
			{
				case "ru":
					OnTextChanged(objectToChange.ru);
					break;
				case "en":
					OnTextChanged(objectToChange.en);
					break;
			}
		}
		else if (spriteObject)
		{
			switch (currentLanguage)
			{
				case "ru":
					OnSpriteChanged(objectToChange.ru);
					break;
				case "en":
					OnSpriteChanged(objectToChange.en);
					break;
			}
		}
	}


	public void OnTextChanged(string text)
    {
        GetComponent<TextMeshProUGUI>().text = text;
    }

    public void OnSpriteChanged(string path)
    {
		if (TryGetComponent<Image>(out Image img))
			img.sprite = Resources.Load<Sprite>(path);
		else if (TryGetComponent<SpriteRenderer>(out SpriteRenderer renderer))
			renderer.sprite = Resources.Load<Sprite>(path);

	}

    [System.Serializable]
    public class LanguageData 
    {
        public List<ObjectToChange> languageObjects;
    }

	[System.Serializable]
	public class ObjectToChange
	{
		public string name;
		public string ru;
		public string en;
	}
}
