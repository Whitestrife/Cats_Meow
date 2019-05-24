using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {
	public Enemy()
	{

	}
	public Enemy (int attack, int health, int magicAttack, int healMin, int healMax, int expDispersed) {
		this.isDead = false;
		this.attack = attack;
		this.magicAttack = magicAttack;
		this.healMin = healMin;
		this.healMax = healMax;
		this.expDispersed = expDispersed;

//		prefab = Resources.Load ("PrefabRoute");
	}
	public string imagePath;
	public Vector3 position;
	public bool isDead; //Set to true if enemy dies
	public int attack;
	public int health;
	public int magicAttack;
	public int healMin;
	public int healMax;
	public int expDispersed;
	//More data you want/need
}