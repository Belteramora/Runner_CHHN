using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinData", menuName = "GameData/SkinData", order = 0)]
public class SkinData: ScriptableObject
{
	public RuntimeAnimatorController currentSkin;
	public Vector2 offsetPosition;

	[ExecuteAlways]
	public SkinData(RuntimeAnimatorController choosedSkin, Vector2 offsetPosition)
	{
		currentSkin = choosedSkin;
		this.offsetPosition = offsetPosition;

	}

	public string GetPath()
	{
		return "Data\\Scriptables\\" + name;
	}


}