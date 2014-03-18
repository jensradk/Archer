using UnityEngine;
using System.Collections;

public class ArrowControl : MonoBehaviour
{
	// Timers that control for how long the shot should live if it does not hit anything:
	public float selfDestructTime = 5.0f;
	private float selfDestructTimer;

	// Speed of the arrow:
	public float speed;
	private Vector2 movement;
	
	// Use this for initialization
	void Start()
	{
		this.selfDestructTimer = this.selfDestructTime;
		this.movement = new Vector2( 0.0f, speed > 0.0f ? speed : -speed );
	}

	// Update is called once per frame
	void Update()
	{
		// Check for self descruction:
		this.selfDestructTimer -= Time.deltaTime;
		if( this.selfDestructTimer <= 0.0f )
			Destroy( this.gameObject );
	}

	void FixedUpdate()
	{
		// Move the physical object:
		rigidbody2D.velocity = this.movement;
	}
}
