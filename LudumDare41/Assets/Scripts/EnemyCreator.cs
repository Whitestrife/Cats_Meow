using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour {

	private static int ENEMY_POS_X = 1600;
	private static int ENEMY_POS_Y = 620;

	public GameObject ground1;
	public GameObject fly1;

	public enum EnemyDiff{
		Easy = 1,
		Medium,
		Hard,
		Boss
	}
	// Use this for initialization
	void Start () {
				//Check What Enemy Type Collided With
				//Check what level you are on
				//Check if it is a boss collision
				//Type + Level = Enemy to Spawn from Enum
				//Random.Range (1,3) to choose Difficulty of Enemy(Or something to this effect)
				//Spawn Enemy.Ground1 EnemyDiff.Medium
				//Easy is 15HP
				//Medium is 25HP
				//Hard is 35HP

				print("Enemy has been created");
				// createEnemy((EnemyType)GameProgress.touchedEnemy);
				createEnemy((EnemyType)GameProgress.touchedEnemy);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createEnemy(EnemyType type)
	{
		print("Type is " + type);
		switch(type)
		{
			case EnemyType.Ground1:
				Instantiate(ground1, new Vector2(ENEMY_POS_X, ENEMY_POS_Y), Quaternion.identity);
				break;
			case EnemyType.Fly1:
				Instantiate(fly1, new Vector2(ENEMY_POS_X, ENEMY_POS_Y), Quaternion.identity);
				break;
		}


		// Instantiate (enemy, pos, Quaternion.identity);
	}

}

public enum EnemyType{
		Ground1 = 1,
		Fly1,
		Ground2,
		Fly2,
		Ground3,
		Fly3
	
}
