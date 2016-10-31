using UnityEngine;
using System.Collections;

public class GroundMove : MonoBehaviour {
	public float speed;
	public GameObject start;
	public GameObject thing;
	Rigidbody2D rb;
	private bool begin;
	public int secondsUntilBegin;

	// Use this for initialization
	void Start () {
		begin = false;
		StartCoroutine ("waitToBegin");
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (begin) {
			rb.velocity = new Vector2 (speed, 0f);
		}
		gameObject.name = "Generated Object";
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("GroundTrigger")){
			Instantiate (thing,start.transform.position,start.transform.rotation);
			Destroy (gameObject);

		}
	}

	IEnumerator waitToBegin () {
		yield return new WaitForSeconds (secondsUntilBegin);
		begin = true;
		secondsUntilBegin = 0;
		StopCoroutine ("WaitToBegin");
	}
}
