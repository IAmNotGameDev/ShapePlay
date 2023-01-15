using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class WallJump : MonoBehaviour {

	Rigidbody2D rb;
	float dirX;

	[SerializeField]
	float moveSpeed = 5f, jumpForce = 600f;
	bool jumpAllowed, wallJumpAllowed;
	bool moveallowed, wallmoveallowed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.y == 0 || wallJumpAllowed)
			jumpAllowed = true;
		else
			jumpAllowed = false;
		if (CrossPlatformInputManager.GetButtonDown("Jump") && jumpAllowed)
			Jump();
		dirX = CrossPlatformInputManager.GetAxis ("Horizontal") * moveSpeed;
		if (rb.velocity.y == 0 || wallJumpAllowed)
			jumpAllowed = true;
		else
			jumpAllowed = false;
		if (CrossPlatformInputManager.GetButtonDown ("Jump") && jumpAllowed)
			Jump ();
		
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2(dirX, rb.velocity.y);
	}



	void Jump()
	{
			rb.AddForce (Vector2.up * jumpForce);
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals("Wall"))
		{
			wallJumpAllowed = true;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals("Wall"))
			wallJumpAllowed = false;
	}
}
