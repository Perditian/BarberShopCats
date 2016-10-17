using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime); 
		Debug.Log ("Rotated a bit");
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			GetComponent<AudioSource>().Play();
			StartCoroutine(DestroyThis());
			gameController.AddScore (1);
		}
	}

	IEnumerator DestroyThis(){
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
}

