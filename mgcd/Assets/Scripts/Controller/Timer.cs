using UnityEngine;
using System.Collections;

public class Timer{
	private float timer;

	public Timer(float time){
		this.timer = Time.time + time;
	}

	public void setTimer(float time){
		this.timer = Time.time + time;
	}

	public float getTimer(){return timer;}
}
