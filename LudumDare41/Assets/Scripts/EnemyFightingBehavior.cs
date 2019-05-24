using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyFightingBehavior : MonoBehaviour {

	public int enemyHealth;
	public Slider enemySlider;
	public Canvas canvas;
	public Text enemyHealthText;
	public bool enemyTurn;
	int physicalDamage, magicDamage, healHealth, pDefense, pMagicDefense, attackType, enemyMaxHealth = 25;
	bool pTurn;
	bool hasDied;
	float stoppedTime;

	PlayerFighting pFighting;
	PlayerStatsManager psMngr;
	
	void Awake(){
		SpawnEnemy();
	}

	void Start () {

		stoppedTime = Time.time;

		enemyHealthText = GameObject.FindGameObjectWithTag("EnemyHealthBar").GetComponent<Text>();
		enemyHealth = enemyMaxHealth;
		enemyTurn = true;
		pFighting = GameObject.Find("Player").GetComponent<PlayerFighting>();
		psMngr = GameObject.Find("Player").GetComponent<PlayerStatsManager>();
		//Make a call for enemy type-grab stats that coincide
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0 && hasDied == false){
			hasDied = true;
			enemyHealth = 0;
			psMngr.setExp(5);
			GameObject.FindGameObjectWithTag("GameProgressHandler").GetComponent<GameProgress>().setCurrentTime(Time.time - stoppedTime);
			StartCoroutine(Delay(2));
			
			//Run Victory Script or Go Back To Runner
		}
		enemyHealthText.text = ("Health Points: " + enemyHealth + "/" + enemyMaxHealth);
	}

	void SpawnEnemy(){

	}
	//Add Crit into Enemy Behavior for Attacks
	public void EnemyBehavior(){
		if(enemyTurn == true & enemyHealth == enemyMaxHealth){
			attackType = Random.Range(0,1);
		
			if(attackType == 0){
				physicalAttack ();
			}
			else if(attackType == 1){
				magicAttack ();
			}
			else{
				heal ();
			}
			pFighting.startTurn();
		}
		else if(enemyTurn == true && enemyHealth > 0){
			attackType = Random.Range(0,8);
		
			if(attackType == 0 || attackType == 1 || attackType == 2 || attackType == 3){
				physicalAttack ();
			}
			else if(attackType == 4 || attackType == 5 || attackType == 6){
				magicAttack ();
			}
			else{
				heal ();
			}
			pFighting.startTurn();
		}
	}

	void physicalAttack()
	{
		pDefense = psMngr.getDefense();
		physicalDamage = Random.Range(6,9) - pDefense;
		psMngr.PlayerHealth(physicalDamage);
		Debug.Log ("Enemy used physical attack");
	}

	void magicAttack()
	{
		pMagicDefense = psMngr.getMagicDefense();
		magicDamage = Random.Range(6,9) - pMagicDefense;
		psMngr.PlayerHealth(magicDamage);
		Debug.Log ("Enemy used magic attack");
	}

	void heal()
	{
		healHealth = Random.Range(0,5);
		enemyHealth += healHealth;
		if (enemyHealth >= enemyMaxHealth){
			enemyHealth = enemyMaxHealth;
		}
		Debug.Log ("Enemy used heal");
	}
	private IEnumerator Delay(float delayTime){
		yield return new WaitForSeconds(delayTime);
		SceneManager.LoadScene(1);
			Destroy(this.gameObject);
		
	}

}
