using System;

[Serializable]
public class GameData
{
	public string savedSkinData;

	public GameData(string skinData)
	{
		savedSkinData = skinData;
	}
}

