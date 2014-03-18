using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
	/// <summary>
	/// The speed of the player
	/// </summary>
	public float speed;

	// Store the movement
	private Vector2 movement;

	// Timers that handle delaying of shooting:
	public float shootingDelay;
	private float shootingTimer;

	// Reference to the prefab that is the arrow:
	public Transform arrowPrefab;

	void Update()
	{
		// Poll for left/right movement:
		float inputX = Input.GetAxis( "Horizontal" );
		movement = new Vector2( speed * inputX, 0.0f );

		// Poll for firing the arrow:
		this.shootingTimer -= Time.deltaTime;
		if( this.shootingTimer <= 0.0f && Input.GetButton( "Fire1" ) )
		{
			// Create a new shot
			var shotTransform = Instantiate( arrowPrefab ) as Transform;

			// Assign position
			shotTransform.position = transform.position;

			// Delay next shot:
			this.shootingTimer = this.shootingDelay;
		}
	}

	void FixedUpdate()
	{
		// Move the physical object:
		rigidbody2D.velocity = movement;
	}
}
