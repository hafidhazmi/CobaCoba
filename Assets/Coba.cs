using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

public class Coba : MonoBehaviour {

	public float speed = 1f;
	public Camera activeCamera;
	Collider2D coll;
	public float tinggiawal;
	public float tinggiakhir;
	public int score;

	GameController gameController;
	Timer timely;

	void Start () {
		coll = GetComponent<Collider2D> ();
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameControllerObject == null) {
			Debug.Log("Gagal");
		}

		GameObject timo = GameObject.FindWithTag("Timer");
		if (timo != null) {
			timely = timo.GetComponent<Timer>();
		}
		if (timo == null) {
			Debug.Log("Gagal");
		}

		tinggiawal = transform.position.y;
	}

	void Update () {
		coll.attachedRigidbody.gravityScale = 0.7f * Time.deltaTime;

		float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		float y = CrossPlatformInputManager.GetAxis ("Vertical");

		for (int i = 0; i< Input.touchCount; ++i) {
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Moved) {
				if (touch.position.x < (Screen.width/2)){
					Vector3 pos = transform.position;
					transform.Translate(new Vector3(x, y, 0.0f), Space.World);
					Vector3 controller = transform.position;
					Vector3 fwd = controller - pos;
					fwd.Normalize ();
					transform.up = fwd;
					transform.position = pos;
					transform.rotation = Quaternion.Euler (0.0f, 0.0f, transform.eulerAngles.z);
				}
			}
		}

		activeCamera.transform.position = new Vector3(0, transform.position.y, activeCamera.transform.position.z);

		tinggiakhir = transform.position.y;
		score = (int)(tinggiakhir - tinggiawal);
		gameController.AddScore (score);
		timely.AddTimer ();
	}

	public void throttle() {
		transform.Translate (0, speed, 0);
		coll.attachedRigidbody.gravityScale += -0.3f;
	}
}