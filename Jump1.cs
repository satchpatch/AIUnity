using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump1 : MonoBehaviour {

	bool isJumping = false;
	Vector3 originalCubeSize;
	Vector3 duckCubeSize = new Vector3(.6f,.6f,.6f);
	bool isDucking = false;
	public enum State
	{
		STATE_STANDING,
		STATE_DUCKING,
		STATE_DIVING,
		STATE_JUMPING
	};
	public State myCurrentState;
	// Use this for initialization
	void Start () {
		originalCubeSize = gameObject.transform.localScale;
	}
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyDown(KeyCode.B)&!isJumping&isDucking) {
			transform.Translate(0,3f,0, Space.World);
		}
		else if (Input.GetKey(KeyCode.DownArrow)){
			gameObject.transform.localScale = duckCubeSize;
			isDucking = false;
		}
		else if (!Input.GetKey(KeyCode.DownArrow)){
			gameObject.transform.localScale = originalCubeSize;
		}*/
	
	switch (myCurrentState)
		{
		case State.STATE_STANDING:
		{
			if(Input.GetKey(KeyCode.B))
			{
				myCurrentState = State.STATE_JUMPING;
				transform.Translate(0,1,0,Space.World);
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				myCurrentState = State.STATE_DUCKING;
				gameObject.transform.localScale = duckCubeSize;
			}
			break;
		}
		case State.STATE_JUMPING:
		{
			if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				myCurrentState = State.STATE_DIVING;
				gameObject.transform.localScale = duckCubeSize;
			}
			break;
		}
		case State.STATE_DUCKING:
		{
			if(Input.GetKeyUp(KeyCode.DownArrow))
			{
				myCurrentState = State.STATE_STANDING;
				gameObject.transform.localScale = originalCubeSize;
			}
			break;
		}
		case State.STATE_DIVING:
		{
			break;
		}
		};
	Debug.Log("Current State is " + myCurrentState);
	}
	void OnCollisionEnter()
	{
		Debug.Log("NOT JUMPING: Enter Collision");
		isJumping = false;
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			myCurrentState = State.STATE_DUCKING;
		}
		else 
		{
			myCurrentState = State.STATE_STANDING;
		}
	}

	void OnCollisionExit()
	{
		Debug.Log("JUMPING: Exit collision");
		isJumping = true;
		myCurrentState = State.STATE_JUMPING;
	}

	
}