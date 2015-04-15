using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public GUIText timeismoney;
	public float minutes, seconds, timer;
	public string niceTimer;
	bool timeStarted = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (timeStarted == true) {
			timer += Time.deltaTime;
//			System.TimeSpan tim = System.TimeSpan.FromSeconds(timer);
//			niceTimer = string.Format("{0:D2}:{1:D2}", tim.Minutes, tim.Seconds);
//			UpdateTime();
		}



	}

	public void AddTimer(){
		minutes = Mathf.FloorToInt (timer / 60);
		seconds = Mathf.RoundToInt (timer%60);
		niceTimer = string.Format ("{0:00}:{1:00}", minutes, seconds);
		UpdateTime ();
	}

	void UpdateTime() {
		timeismoney.text = niceTimer;
	}
}
