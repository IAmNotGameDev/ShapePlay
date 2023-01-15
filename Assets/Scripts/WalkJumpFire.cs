using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class WalkJumpFire : MonoBehaviour {

	Rigidbody2D rb;
	float dirX;

	[SerializeField]
	float moveSpeed = 5f, jumpForce = 600f;
	void Awake()
	{
		Application.targetFrameRate = 60;
	}
		// Use this for initialization
		void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		dirX = CrossPlatformInputManager.GetAxis ("Horizontal");

		if (CrossPlatformInputManager.GetButtonDown ("Jump"))
			Jump ();
		
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);
	}



	void Jump()
	{
		if (rb.velocity.y == 0)
			rb.AddForce (Vector2.up * jumpForce);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name.Equals("Cloud"))
			this.transform.parent = col.transform;
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.name.Equals("Cloud"))
			this.transform.parent = null;
	}
}
