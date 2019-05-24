using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType{
		Ground1 = 1,
		Fly1,
		Ground2,
		Fly2,
		Ground3,
		Fly3
	}
public class EnemyFactory{

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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
