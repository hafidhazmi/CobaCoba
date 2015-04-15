using UnityEngine;
using System.Collections;

public class Awan : MonoBehaviour {

	public GameObject objek;
	float posx; 
	float posy = 5.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine (spawn());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator spawn() {
		yield return new WaitForSeconds (0.1f);
		while (posy < 55.0f) {
			this.posy += 4.0f;
			this.posx = Random.Range(-8.0f, 8.0f);
			Instantiate (objek, new Vector3(posx, posy, -1.0f), Quaternion.identity);
			this.posx = Random.Range(-8.0f, 8.0f);
			Instantiate (objek, new Vector3(posx, posy, -1.0f), Quaternion.identity);
			this.posx = Random.Range(-8.0f, 8.0f);
			Instantiate (objek, new Vector3(posx, posy, -1.0f), Quaternion.identity);
			this.posx = Random.Range(-8.0f, 8.0f);
			Instantiate (objek, new Vector3(posx, posy, -1.0f), Quaternion.identity);
			this.posx = Random.Range(-8.0f, 8.0f);
			Instantiate (objek, new Vector3(posx, posy, -1.0f), Quaternion.identity);
			yield return new WaitForSeconds (0.1f);

		}
	
	}
}
