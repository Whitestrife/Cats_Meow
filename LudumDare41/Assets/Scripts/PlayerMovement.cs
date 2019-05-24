using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private float BASE_JUMP_POWER = 1000.0f;
	private float BASE_SPEED = 10.0f;
	private float SLIDE_TIME = 1f;
	private enum State { Jumping, Grounded, Sliding };
	private Rigidbody2D rb;
	private GameObject Player;

	State previousState;
	State myState;

	bool isJumping = false;
	// Use this for initialization
	void Start () {
		myState = previousState = State.Grounded;
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerController();
	}
	void PlayerController(){
		//Var X controllers horizontal movement
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * BASE_SPEED;

		//This is a simple jump, with force applied to the "Up" direction
		if ((Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W))){
			onUpPressed ();
		}
		if ((Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S))){
			onDownPressed ();
		}
		if ((Input.GetKeyUp(KeyCode.DownArrow)||Input.GetKeyUp(KeyCode.S))){
			//onDownReleased();
		}
//		transform.Translate(x,0,0);
	
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		
		Collider2D collider = collision.collider;
		Vector3 contactPoint = collision.contacts[0].point;
		Vector3 center = collider.bounds.center;

		bool top = contactPoint.y < center.y;

		if (!top && myState != State.Sliding) {
			myState = State.Grounded;
		}
	}

	private void onUpPressed()
	{
		if (myState == State.Grounded) {
			standardJump();
		}
	}

	private void onDownPressed()
	{
		print(myState);
		if(myState == State.Grounded)
		{
			slide();
		}
	}

	private void onDownReleased()
	{
		Player = rb.gameObject;

		float size = Player.GetComponent<Renderer> ().bounds.size.y;

		Vector3 rescale = Player.transform.localScale;

		rescale.y = 1.0f;

		Player.transform.localScale = rescale;

		previousState = myState;
		myState = State.Grounded;

	}

	private void standardJump()
	{
		rb.AddForce (transform.up * BASE_JUMP_POWER);
		previousState = myState;
		myState = State.Jumping;
	}
	
	
	private void slide()
	{
		Player = rb.gameObject;
		float size = Player.GetComponent<Renderer> ().bounds.size.y;
		Vector3 rescale = Player.transform.localScale;
		rescale.y = .5f;

		Player.transform.localScale = rescale;
		previousState = myState;
		myState = State.Sliding;

		Invoke ("onDownReleased", SLIDE_TIME);
	}
	private IEnumerator Delay(float delayTime){
		yield return new WaitForSeconds(delayTime);
		
	}
}
