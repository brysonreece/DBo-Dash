using UnityEngine;
using System.Collections;

public class movementController : MonoBehaviour {

	public float playerSpeed;
	private Animator animator;
	private Animation animations;
	private bool begin;
	private bool isTouchingGround;
	public float jumpHeight;
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent <Animator> ();
		animations = gameObject.GetComponent <Animation> ();
		begin = false;
		StartCoroutine ("waitForStart");
	}
	
	// Update is called once per frame
	void Update () {
		if (begin) {
			animator.SetFloat ("speed", playerSpeed);
		}

		if (!isTouchingGround) {
			/*foreach (AnimationState state in animations) {
				state.speed = speed;
			}*/
			animator.SetBool ("inAir", true);
		}
		else {
			animator.SetBool ("inAir", false);
		}

		if (Input.GetKeyDown ("j") && isTouchingGround && begin) {
			this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpHeight), ForceMode2D.Impulse);
		}
		Debug.Log ("Is Touching: " + isTouchingGround);
		//isTouchingGround = false;
	}

	IEnumerator waitForStart () {
		yield return new WaitForSeconds (4);
		Destroy (GameObject.Find ("DBo-Dash"));
		begin = true;
		StopCoroutine ("waitForStart");
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Platform")){
			isTouchingGround = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Platform")){
			isTouchingGround = false;
		}
	}

}
