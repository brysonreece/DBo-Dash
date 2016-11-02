using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	private bool gameRunning;

	void Start () {
		gameRunning = false;
	}

	public void pauseGame () {
		gameRunning = false;
	}

	public void unpauseGame () {
		gameRunning = true;
	}

	public bool isGameRunning () {
		return gameRunning;
	}
}
