using UnityEngine;
using System.Collections;

/**
 * @author Bryson Reece
 * 
 * Controls the scrolling movement of the player platform.
 */
public class groundScrollController : MonoBehaviour {

	// The speed at which we scroll our platform
	public float scrollSpeed;
	// A GameObject with a collider to mark when we need to change the position of our platform
	public GameObject destroyWaypointGameobject;
	// Our default platform position
	Vector3 defaultPosition;
	// A boolean to decide if our platform needs to be moving
	bool scroll;

	/**
	 * Start is used for initialization
	 */
	void Start () {
		// Assign our default platform position to defaultPosition
		defaultPosition = this.transform.position;
		// By default, our platform should be stationary
		scroll = false;
	}
	
	/**
	 * Update is called once per frame
	 */
	void Update () {
		// If we should be scrolling...
		if (scroll) {
			// Move our platform in relation to our scrollSpeed
			transform.Translate (Vector3.left * scrollSpeed);
		}
	}

	/**
	 * OnCollisionEnter2D is called when two 2D colliders touch
	 * 
	 * @param - Collision2D collision: the collider child object of
	 *          our collided-with GameObject
	 */
	void OnCollisionEnter2D (Collision2D collision) {
		// Check if we collided with our destroy marker
		if (collision.gameObject.Equals (destroyWaypointGameobject)) {
			// Reset the position of our platform
			this.transform.position = defaultPosition;
		}
	}

	void isScrolling (bool status) {
		scroll = status;
	}

}
