using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventController : MonoBehaviour {
	public GameController gameController;
	public EnemyController enemyController;
	public void Start(){
		gameController = GameObject.FindGameObjectWithTag ("gameController").GetComponent<GameController> ();
		enemyController = GameObject.FindGameObjectWithTag ("enemyController").GetComponent<EnemyController> ();
	}
	public void enemyOnClick(){
		enemyController.killEnemy (this.name);
		GameController.kill++;
		GameObject.FindGameObjectWithTag ("score").GetComponent<Text> ().text = GameController.kill * 100+"";
	}

	public void modalHomeOnClick(){
		Application.LoadLevel (1);
	}

	public void modalRetryOnClick(){

		GameController.kill = 0;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void modalNextOnClick(){
		Application.LoadLevel(Application.loadedLevel);
	} 
}
