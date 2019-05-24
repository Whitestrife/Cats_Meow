using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEnemyCollisionController : MonoBehaviour {
	private Rigidbody2D rb;
	private GameObject Player;
	public CameraMovementController cameraScript;
	private string enemyData;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		PlayerController();
	}
	void PlayerController(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			cameraScript.resume ();
		}

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Collider2D collider = collision.collider;
		Vector3 contactPoint = collision.contacts[0].point;
		Vector3 center = collider.bounds.center;

		GameObject other = collision.gameObject;

		bool right = contactPoint.x > center.y;
		bool top = contactPoint.y < center.y;

		print("Collided with " + other.tag);
		if (other.CompareTag("Enemy")) {
			cameraScript.pause();
			cameraScript.saveCurrentPosition();

			GameProgress.touchedEnemy = other.GetComponent<EnemyData>().enemyType;
			enemyData = other.GetComponent<EnemyData>().id;
			GameProgress.killedEnemy = enemyData;
			Debug.Log("My enemy id is " + enemyData);
			Debug.Log("GameProgress id is " + GameProgress.killedEnemy);
			SceneManager.LoadScene(2);
			
		}
		else if (other.CompareTag("FinishLine")) {
			cameraScript.pause();
		}
	}
}
