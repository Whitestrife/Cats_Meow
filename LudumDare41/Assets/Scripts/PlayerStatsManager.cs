using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatsManager : MonoBehaviour {

	int startingHealth = 100;
	public Slider healthSlider;
	public Text healthText, levelText, expText, mpText;
	public static int playerLevel = 1;
	static int expToLevel = 20;
	static int currentExp;
	public static int currentHealth, strength, defense, magicDefense, magic, critChance, potionQuantity, currentMP, maxMP;
	PlayerFighting pFighting;
	void Start () {
		if(currentHealth == 0){
			currentHealth = startingHealth;
		}
		Debug.Log("Yo I got called and my exp is " + currentExp);
		Debug.Log("this is my level " + playerLevel);
		pFighting = gameObject.GetComponent<PlayerFighting>();
		PlayerStats();
		currentMP = maxMP;
		healthText.text = ("Health Points: " + currentHealth + "/" + startingHealth);
		levelText.text = ("Level: " + playerLevel);
		expText.text = ("Exp: " + currentExp + "/" + expToLevel);
		mpText.text = ("MP: " + currentMP + "/" + maxMP);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.M)){
			strength = 50;
		}
	
	}
	public void PlayerHealth(int damageIn){

		currentHealth -= damageIn;                       

		if (currentHealth <= 0){
			currentHealth = 0;
			SceneManager.LoadScene(3);
			Destroy(this.gameObject);
			//Run Game Over Screen
		}
		if(currentHealth >= 100){
			currentHealth = startingHealth;
		}
		
		healthSlider.value = currentHealth;
		healthText.text = ("Health Points: " + currentHealth + "/" + startingHealth);
	}
	void PlayerItems(){
		//Manage items in the bag
	}
	void PlayerStats(){
		strength = playerLevel * 1;
		defense =  playerLevel * 2;
		magicDefense = playerLevel * 2;
		magic = playerLevel * 2;
		critChance =  playerLevel + 5;
		potionQuantity = 2;
		maxMP = playerLevel * 4;
	}

	public void setExp(int addedExp){
		Debug.Log("This is how much xp was added " + addedExp);
		expToLevel = playerLevel * 20;
		currentExp = currentExp + addedExp;
		expText.text = ("Exp: " + currentExp + "/" + expToLevel);
		if(currentExp == expToLevel){
			playerLevel++;
			checkLevelUnlocks();
			expText.text = ("Exp: " + currentExp + "/" + expToLevel);
		}
	}

	public int getLevel(){
		return playerLevel;
	}

	public void checkLevelUnlocks(){
		if(playerLevel >= 2){
			pFighting.canCastFire = true;
		}
		if(playerLevel >= 3){
			pFighting.canCastIce = true;
		}
		if(playerLevel >= 4){
			pFighting.canCastEarth = true;
		}
	}

	public int getDefense(){
		return defense;
	}

	public int getStrength(){
		return strength;
	}

	public int getMagicDefense(){
		return magicDefense;
	}

	public int getCurrentHealth(){
		return currentHealth;
	}

	public int getMagic(){
		return magic;
	}

	public int getCritChance(){
		return critChance;
	}

	public int getPotionQuanity(){
		return potionQuantity;
	}

	public void setPotionQuanity(int augment){
		potionQuantity -= augment;
	}

	public void setMP(int augment){
		currentMP -= augment;
		mpText.text = ("MP: " + currentMP + "/" + maxMP);
	}
	public int getMP(){
		return currentMP;
	}

}
