using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFighting : MonoBehaviour {

	public Button attackButton, skillButton, spellIceButton, spellFireButton, spellLightningButton, spellEarthButton, itemButton;
	public bool playerTurn = false;
	public Text m_MyText;
	int currentPHealth;
	int damage = 5;
	int magicDamage = 3;
	int crit = 2;
	public bool canCastIce = false;
	public bool canCastFire = false;
	public bool canCastEarth = false;

	PlayerStatsManager psMngr;
	
	public bool eTurn;
	
	void Start () {

		psMngr = GameObject.Find("Player").GetComponent<PlayerStatsManager>();
		eTurn = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyFightingBehavior>().enemyTurn;
		Button btn = attackButton.GetComponent<Button>();
		btn.onClick.AddListener(Attacking);

		Button iceButton = spellIceButton.GetComponent<Button>();
		iceButton.onClick.AddListener(Ice);

		Button fireButton = spellFireButton.GetComponent<Button>();
		fireButton.onClick.AddListener(Fire);

		Button lightningButton = spellLightningButton.GetComponent<Button>();
		lightningButton.onClick.AddListener(Lightning);

		Button earthButton = spellEarthButton.GetComponent<Button>();
		earthButton.onClick.AddListener(Earth);

		Button useButton = itemButton.GetComponent<Button>();
		useButton.onClick.AddListener(ItemUse);
		//Make a call for current player stats, health, items on Fight Start
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTurn)
			Debug.Log ("It is player's turn");
		else
			Debug.Log ("It is enemy's turn");
	}

	void Attacking (){
		Debug.Log ("Attacking");
		if(playerTurn == true){
			crit = getCrit();
			damage = getBaseDamage ();
			int damageToDeal = getFinalDamageAmount (crit, damage);
			dealDamageToEnemy ("EnemyPosition", damageToDeal);
			endTurn ();
		}
	}
	void ItemUse(){
		Debug.Log("Healing with potion");
		if(playerTurn == true)
		{
			if(psMngr.getPotionQuanity() <= 0){
				Debug.Log("You tried to heal but your potion bottle looks empty!");
			}else{
			psMngr.PlayerHealth(-20);
			psMngr.setPotionQuanity(1);
			}
		}
		endTurn();
		
	}
	void Ice()
	{
		if(playerTurn == true)
		{
			if(psMngr.getMP() < 2){
				Debug.Log("You tried to cast but your energy feels weak. Not enough MP");

			}else{
			psMngr.setMP(2);
			crit = getCrit();
			magicDamage = getBaseMagicDamage ();

			int damageToDeal = getFinalDamageAmount (crit, magicDamage);
			dealDamageToEnemy ("EnemyPosition", damageToDeal);
			endTurn ();
			}
		}
	}
	void Fire()
	{
		if(playerTurn == true)
		{
			if(psMngr.getMP() < 2){
				Debug.Log("You tried to cast but your energy feels weak. Not enough MP");

			}else{
			psMngr.setMP(2);
			crit = getCrit();
			magicDamage = getBaseMagicDamage ();
			int damageToDeal = getFinalDamageAmount (crit, magicDamage);

			dealDamageToEnemy ("EnemyPosition", damageToDeal);
			endTurn ();
			}
		}
	}
	void Lightning()
	{
		if(playerTurn == true)
		{
			if(psMngr.getMP() < 2){
				Debug.Log("You tried to cast but your energy feels weak. Not enough MP");

			}else{
			psMngr.setMP(2);
			crit = getCrit();
			magicDamage = getBaseMagicDamage ();
			int damageToDeal = getFinalDamageAmount (crit, magicDamage);

			dealDamageToEnemy ("EnemyPosition", damageToDeal);
			endTurn ();
			}

		}
	}
	void Earth()
	{
		if(playerTurn == true)
		{
			if(psMngr.getMP() < 2){
				Debug.Log("You tried to cast but your energy feels weak. Not enough MP");

			}else{
			psMngr.setMP(2);
			crit = getCrit();
			magicDamage = getBaseMagicDamage ();
			int damageToDeal = getFinalDamageAmount (crit, magicDamage);

			dealDamageToEnemy ("EnemyPosition", damageToDeal);
			endTurn ();
			}
		}
	}

	int getFinalDamageAmount(int crit, int damage) {
		if (crit >= 90 & crit < 100)
		{
			Debug.Log(crit);
			damage *= 2;
			m_MyText.text = ("Crit Damage " + damage +"!");
		}
		else if (crit >= 100)
		{
			Debug.Log("Ultra Crit!");
			crit = 100;
			damage *= 3;
			m_MyText.text = ("Ultra Crit " + damage +"!!!");
		}
		else
		{
			m_MyText.text = ("Damage Dealt " + damage);
		}

		return damage;
	}

	void dealDamageToEnemy(string enemy, int damageToDeal)
	{
		GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyFightingBehavior>().enemyHealth -=damageToDeal;
	}

	public void startTurn()
	{
		Debug.Log ("Player turn has started");
		playerTurn = true;	
		eTurn = false;
		setButtonsEnabled (true);
	}

	public void endTurn()
	{
		playerTurn = false;
		setButtonsEnabled (false);
		StartCoroutine(Delay(2f));	
	}

	int getCrit() {
		return psMngr.getCritChance() * Random.Range(1,21);
	}

	int getBaseMagicDamage() {
		return psMngr.getMagic() * Random.Range(2,6);
	}

	int getBaseDamage() {
		return psMngr.getStrength() * Random.Range(1,4);
	}

	void setButtonsEnabled(bool enabled)
	{
		attackButton.GetComponent<Button>().interactable = enabled;
		itemButton.GetComponent<Button>().interactable = enabled;
		skillButton.GetComponent<Button>().interactable = enabled;
		if(canCastFire == true){
		spellFireButton.GetComponent<Button>().interactable = enabled;
		}
		if(canCastIce == true){
		spellIceButton.GetComponent<Button>().interactable = enabled;
		}
		spellLightningButton.GetComponent<Button>().interactable = enabled;
		if(canCastEarth == true){
		spellEarthButton.GetComponent<Button>().interactable = enabled;
		}
	}
	private IEnumerator Delay(float delayTime){
		yield return new WaitForSeconds(delayTime);
		eTurn = true;
		GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyFightingBehavior> ().EnemyBehavior ();
	}
}

