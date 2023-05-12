using System.IO;
using UnityEngine;

public class SaveManager
{
	private static string gameDataPath;
	public static GameData GameData { get; private set; }

	public static void LoadGameData()
	{
		gameDataPath = Application.persistentDataPath + "/GameData.json";

		if (File.Exists(gameDataPath))
		{
			string jsonText = File.ReadAllText(gameDataPath);
			GameData = JsonUtility.FromJson<GameData>(jsonText);
		}
		else
		{
			StreamWriter stream = File.CreateText(gameDataPath);
			GameData = new("Data/Scriptables/SkinData Girl");
			stream.Write(JsonUtility.ToJson(GameData));
			stream.Close();
		}
	}

	public static void SaveGameData() 
	{
		string jsonText = JsonUtility.ToJson(GameData);
		File.WriteAllText(gameDataPath, jsonText);
	}

	public static void SetSkinData(SkinData skinData)
	{
		GameData.savedSkinData = skinData.GetPath();
		SaveGameData();
	}
}

