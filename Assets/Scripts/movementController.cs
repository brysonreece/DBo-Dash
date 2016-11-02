using UnityEngine;
using System.Collections;

public class movementController : MonoBehaviour {

	// Our player's jump height
	public float jumpHeight;
	// Our player's running speed
	public float playerSpeed;
	// Our Game Manager object
	public GameObject gameManagerObject;

	// Our animator to control David's animation
	private Animator animator;
	// Our gameManager script to read game status
	private gameManager game;
	// Whether or not David is touching the ground
	private bool isTouchingGround;

	/**
	 * Used for initialization. Called when the script is created.
	 */
	void Start () {
		// Initialize our Animator object to another component of this object
		animator = gameObject.GetComponent <Animator> ();
		// Initialize our gameManager object with our gameManager script
		game = (gameManager) gameManagerObject.GetComponent (typeof(gameManager));
		// Start the countdown at the beginning of the game
		StartCoroutine ("waitForStart");
	}
	
	/**
	 * Update is called once per frame
	 */
	void Update () {

		// Determines if David is in the air and sets the appropriate animation state
		if (!isTouchingGround) {
			animator.SetBool ("inAir", false);
		}
		else {
			animator.SetBool ("inAir", false);
		}

		// Checks for user input and moves David accordingly
		if (Input.GetKeyDown ("j") && isTouchingGround && game.isGameRunning ()) {
			this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpHeight), ForceMode2D.Impulse);
		}
		//Debug.Log ("Is touching ground: " + isTouchingGround); 
	}

	/**
	 * Acts as a countdown before the game starts
	 */
	IEnumerator waitForStart () {
		// Make sure our game is paused
		game.pauseGame ();
		// Wait for 4 seconds
		yield return new WaitForSeconds (4);
		// Get rid of our banner
		Destroy (GameObject.Find ("UI"));
		// Start the game
		game.unpauseGame ();
		// Start the player animation
		animator.SetFloat ("speed", playerSpeed);
		// End this method
		StopCoroutine ("waitForStart");
	}

	/**
	 * OnCollisionEnter2D is called when two 2D colliders touch
	 * 
	 * @param - Collision2D collision: the collider child object of
	 *          our collided-with GameObject
	 */
	void OnCollisionEnter2D (Collision2D collision) {
		// Check if we collided with our destroy marker
		if (collision.gameObject.CompareTag ("Platform")) {
			// Update our isTouchingGround boolean
			isTouchingGround = true;
		}
	}

	/**
	 * OnCollisionExit2D is called when two 2D colliders stop touching
	 * 
	 * @param - Collision2D collision: the collider child object of
	 *          our collided-with GameObject
	 */
	void OnCollisionExit2D (Collision2D collision) {
		// Check if we collided with our platform
		if (collision.gameObject.CompareTag ("Platform")) {
			// Update our isTouchingGround boolean
			isTouchingGround = false;
		}
	}

}
