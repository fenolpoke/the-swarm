using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private EnemyController enemyController;

	public Camera mainCamera;
	public static int kill = 0;
	public static bool alive;

	public static int GAMESTATE = 0;
	public static int STORY = 1;
	public static int ENDLESS = 2;

	public Image player;
	void Start () {
		alive = true;
		player = GameObject.FindGameObjectWithTag ("hero").GetComponent<Image> ();
		enemyController = GameObject.FindGameObjectWithTag ("enemyController").GetComponent<EnemyController> ();
	}


	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "hero")
						Debug.Log ("hhhhh");
	}
}
