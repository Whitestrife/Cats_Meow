using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour {

	private float SCREEN_WIDTH = 20.0f;
	private float CAMERA_DX = .07f;
	// Use this for initialization
	public Camera camera;
	public GameObject p;
	bool paused;

	void Start () {
		setLevelPosition(GameProgress.levelPosition);
		paused = true;
		StartCoroutine(Delay(1.5f));
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			setLevelPosition(0);
		}

		if(Input.GetKeyDown(KeyCode.R)) {
			setLevelPosition(GameProgress.levelPosition);
		}

		if (!paused) {
			if (p.transform.position.x < camera.transform.position.x - SCREEN_WIDTH/2) {
				p.transform.position = new Vector2(camera.transform.position.x - SCREEN_WIDTH/2, p.transform.position.y);
				print ("Out of view to the left!");
			}
			if (p.transform.position.x > camera.transform.position.x + SCREEN_WIDTH/2) {
				p.transform.position = new Vector2(camera.transform.position.x + SCREEN_WIDTH/2, p.transform.position.y);
				print ("Out of view to the right!");
			}
			p.transform.position = new Vector2(camera.transform.position.x - SCREEN_WIDTH/4, p.transform.position.y);
			transform.position = new Vector2 (transform.position.x + CAMERA_DX, transform.position.y);
		}
	}

	public void saveCurrentPosition()
	{
		GameProgress.levelPosition = transform.position.x;
	}

	public void resetPosition()
	{
		GameProgress.levelPosition = 0;
	}

	public void pause()
	{
		paused = true;
	}

	public void resume()
	{
		paused = false;
	}

	public void setLevelPosition(float xPosition)
	{
		transform.position = new Vector2 (xPosition, 0);
	}
	private IEnumerator Delay(float delayTime){
		yield return new WaitForSeconds(delayTime);
		paused = false;
		p.SetActive(true);
	}
}
