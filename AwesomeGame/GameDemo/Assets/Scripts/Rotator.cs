using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime); 
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			GetComponent<AudioSource>().Play();
			StartCoroutine(DestroyThis());
		}
	}

	IEnumerator DestroyThis(){
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
}

