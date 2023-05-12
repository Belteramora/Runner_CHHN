using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
	public static string leaderDataPath;
	public static LeaderData leaderData;


	public GameObject leaderItemPrefab;
	public GameObject view;

	public void Start()
	{
		LoadLeaderData();

		leaderData.data.Sort();

		int i = 1;
		foreach (LeaderData.LeaderItem item in leaderData.data)
		{
			GameObject instance = Instantiate(leaderItemPrefab, view.transform);
			instance.GetComponent<LeaderItemGO>().Setup(i.ToString(), item.score, item.time);
			i++;
		}
	}

	public static void LoadLeaderData()
    {
		leaderDataPath = Application.persistentDataPath + "/LeaderboardData.json";

		Debug.Log(Application.persistentDataPath + "/LeaderboardData.json");

		if (File.Exists(leaderDataPath))
		{
			Debug.Log("File exist, loading");
			string jsonText = File.ReadAllText(leaderDataPath);
			leaderData = JsonUtility.FromJson<LeaderData>(jsonText);

			leaderData.data.ForEach(data => { Debug.Log("LEADER DATA " + data.time + data.score); });
			Debug.Log("LEADER DATA TODAY" + leaderData.today);
		}
		else
		{
			Debug.Log("File not exist, creating");
			StreamWriter stream = File.CreateText(leaderDataPath);
			leaderData = new();
			stream.Write(JsonUtility.ToJson(leaderData));
			stream.Close();
		}


		if (leaderData.today != DateTime.Today.ToLongDateString())
		{
			Debug.Log("Date not equal");
			leaderData.data.Clear();
			leaderData.today = DateTime.Today.ToLongDateString();
		}

		SaveLeaderData();
	}

	public static void SaveLeaderData()
	{
		string jsonText = JsonUtility.ToJson(leaderData);

		File.WriteAllText(leaderDataPath, jsonText);
	}

	[System.Serializable]
	public class LeaderData
	{ 
		public List<LeaderItem> data;
		public string today;

		public LeaderData()
		{
			today = DateTime.Today.ToLongDateString();

			data = new List<LeaderItem>();
		}

		[System.Serializable]
		public class LeaderItem: IComparable<LeaderItem> 
		{
			public string score;
			public string time;

			public LeaderItem(string score, string time)
			{
				this.score = score;
				this.time = time;
			}

			public int CompareTo(LeaderItem other)
			{
				int thisScore = int.Parse(score);
				int otherScore = int.Parse(other.score);
				if (thisScore > otherScore) return -1;
				else if (thisScore < otherScore) return 1;
				else return 0;
			}
		}
	}
}
