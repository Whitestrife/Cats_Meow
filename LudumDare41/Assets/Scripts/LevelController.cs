using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;



public class LevelController : MonoBehaviour {

	// Use this for initialization
	private List<GameObject> enemies;
	private LevelPool levelPool;
	private string enemyLastKilled = "";

	public GameObject enemy;
	public GameObject floor;
	public GameObject finishLine;

	void Start () {
		// LoadLevel ();
		enemyLastKilled = GameProgress.killedEnemy;
		StartCoroutine(Delay(2));
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

		Instantiate(floor, new Vector2(0, -3.25f), Quaternion.identity);

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

			if(!enemyLastKilled.Equals(jsonEnemy.enemyId))
			{
				Instantiate (enemy, pos, Quaternion.identity);
				EnemyData enemyData = enemy.GetComponent<EnemyData>();
				enemyData.id = jsonEnemy.enemyId;
				enemyData.enemyType = jsonEnemy.enemyEnum;
			}
		}
	}
	private IEnumerator Delay(float delayTime){
		yield return new WaitForSeconds(delayTime);
		LoadLevelsFromJson();
		LoadLevel(0);
		enemies = new List<GameObject>();	
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
	public string enemyId;
	public int enemyEnum;
	public float[] enemyPosition;
	public bool alive;
}