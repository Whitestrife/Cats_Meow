using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProgress : MonoBehaviour {
	public static float levelPosition = 0;
	public static int levelsWon = 0;
	public static string killedEnemy = "";
	public static int touchedEnemy = 0;
	private static bool created = false;
	public Slider progressBar;
	public static float currentTime;
	public static float removedTime;

	void Awake(){
	if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
	}

	void Start(){
		
		var canvasThing = GameObject.FindGameObjectWithTag("UI");
		progressBar = canvasThing.GetComponentInChildren<Slider>();
	}
	void Update(){
		currentTime = Time.time - removedTime;
		progressBar.value = currentTime;
		if(progressBar.value == progressBar.maxValue){
			Debug.Log("Time for a boss battle!");
			
		}
		
		//Debug.Log("From GameProgress I see that enemyID " + killedEnemy +" is dead");
	}

	public void setCurrentTime(float myTime){
		removedTime += myTime;
	}
	public float getCurrentTime(){
		return currentTime;
	}
}
