using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;



public class LevelController : MonoBehaviour {

	// Use this for initialization
	private List<GameObject> enemies;
	private LevelPool levelPool;
	public GameObject enemy;
	public GameObject floor;
	public GameObject finishLine;

	void Start () {
		// LoadLevel ();
		LoadLevelsFromJson();
		LoadLevel(0);
		enemies = new List<GameObject>();
	}

	private void LoadLevelsFromJson()
	{
		string path;
		string jsonString;

		path = "Assets/Resources/levels.json";
		jsonString = File.ReadAllText(path);

		levelPool = JsonUtility.FromJson<LevelPool>(jsonString);
	}

	private void LoadLevel(int levelIndex)
	{
		Level level = levelPool.levels[levelIndex];

		Instantiate(floor, new Vector2(0,1), Quaternion.identity);

		Vector3 rescale = floor.transform.localScale;
		rescale.x = level.levelLength * 1.0f;
		floor.transform.localScale = rescale;

		createEnemies(level.enemies);
	}

	private void createEnemies(JsonEnemy[] enemies)
	{	
		for(int i = 0; i < enemies.Length; i++)
		{
			JsonEnemy jsonEnemy = enemies[i];
			Vector2 pos = new Vector2(jsonEnemy.enemyPosition[0], jsonEnemy.enemyPosition[1]);
			Instantiate (enemy, pos, Quaternion.identity);
		}
	}
}

[System.Serializable]
public class LevelPool
{
	public Level[] levels;
}

[System.Serializable]
public class Level
{
	public int levelId;
	public int levelLength;
	public JsonEnemy[] enemies;
}

[System.Serializable]
public class JsonEnemy
{
	public int enemyId;
	public int enemyEnum;
	public float[] enemyPosition;
	public bool alive;
}