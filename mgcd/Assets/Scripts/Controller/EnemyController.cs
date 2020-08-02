using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
	public Camera mainCamera;
	public Sprite[] swarm = new Sprite[2];
	public Text txtTimer;
	public List<Enemy> listEnemy;
	private Canvas canvas;
	private Image player;
	private Enemy temp;
	private Timer timer,gameTimer;
	private GameController gameController;
	private int sec;
	private string t;
	private bool showDialog  = false;
	private bool gameOver = false;
	public static int GAME_LEVEL = 1;

	public static float SPAWNTIME = 1f;
	private static float delay = 1f;
	public static float MINUTES = 1;


	private const int TOP = 1,DOWN = 2,LEFT = 3,RIGHT = 4;

	void Start () {
		sec = 1;
		listEnemy = new List<Enemy>();
		canvas = GameObject.FindGameObjectWithTag("canvas").GetComponent<Canvas>();
		player = GameObject.FindGameObjectWithTag ("hero").GetComponent<Image> ();
		gameController = GameObject.FindGameObjectWithTag ("gameController").GetComponent<GameController> ();
		timer = new Timer (SPAWNTIME);
		gameTimer = new Timer (delay);
		GameObject.FindGameObjectWithTag ("level").GetComponent<Text> ().text = "Level "+GAME_LEVEL;
		GameObject.FindGameObjectWithTag ("score").GetComponent<Text> ().text = GameController.kill * 100+"";

		if(GameController.GAMESTATE == GameController.STORY){
			if (MINUTES < 10) {
				t = "0"+MINUTES+":00";	
			} else {
				t = MINUTES+":00";
			}
			txtTimer.text = t;
			sec = (int) MINUTES * 60;
		}else{
			GameObject p = GameObject.FindGameObjectWithTag("timer");
			p.SetActive(false);
			GameObject.FindGameObjectWithTag("level").SetActive(false);
		}

	}

	void Update(){
		if(sec>=0 && !gameOver){
			if (GameController.GAMESTATE == GameController.STORY &&  gameTimer.getTimer () < Time.time) {
				if(sec < 5)txtTimer.color = Color.red;
				else if(sec < 10)txtTimer.color = new Color(255,255,0);
				setClock();
				gameTimer.setTimer(delay);
			}
			if (timer.getTimer() < Time.time) {
				spawnEnemy ();
				timer.setTimer(SPAWNTIME);
			}
			if (listEnemy.Count > 0) {
				moveEnemies();
			}
		}else{
			foreach (GameObject obj in GameObject.FindGameObjectsWithTag("enemy")) {
				Destroy(obj);
			}
			listEnemy.Clear();
			if(!showDialog){
				int state = -1;
				if(sec<=0){
					state = ModalController.FINISH;
					GAME_LEVEL++;
				}
				else if(gameOver){
					state = ModalController.GAMEOVER;
					GAME_LEVEL = 1;
				}
				GameObject.FindGameObjectWithTag("modalController").
					GetComponent<ModalController>().
						showModalDialog(state,GameController.kill);
				showDialog = true;
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			GameController.kill = 0;
			Application.LoadLevel("MenuScene");

		}

	}

	private void setClock(){
		t = "";
		if (sec / 60 < 10) {
			t = "0"+(sec/60);
		}else{
			t = (sec/60)+"" ;
		}
		if((sec - (sec/60 * 60))>9)t += ":"+(sec - (sec/60 * 60));
		else t += ":0"+(sec - (sec/60 * 60));

		
		txtTimer.text = t;

		sec--;
	}

	public void killEnemy(string name){
		for(int i=0; i<listEnemy.Count; i++){
			if(listEnemy[i].getName().Equals(name)){
				Destroy(GameObject.Find(name),0.1f);
				listEnemy.RemoveAt(i);
				return;
			}
		}
	}
	public void moveEnemies(){
		for (int i=0; i<listEnemy.Count; i++) {
			listEnemy[i].move(player.transform.position);
			if(listEnemy[i].checkIntersect(gameController)){
				gameOver = true;
				return;
			}
		}
	}

	public void spawnEnemy(){
		Instantiate (Resources.Load ("Enemy") as GameObject, randomDirection(),Quaternion.identity);
		Image e = GameObject.Find ("Enemy(Clone)").GetComponent<Image> ();
		temp = new Enemy(	Enemy.getNewName(),
		                 	e,
		                 	canvas,
		                 	player.transform.position,
		                 	swarm
		                 );

		listEnemy.Add (temp);
	}
         
	private Vector3 randomDirection(){
		int pos =  Random.Range (1,4);
		float x, y;
		if (pos == TOP) {
			x = Random.Range(0,Screen.width*2)-Screen.width;
			y = Screen.height;
		}else if(pos == DOWN){
			x = Random.Range(0,Screen.width*2)-Screen.width;
			y = -Screen.height;
		}else if(pos == LEFT){
			x = -Screen.width;
			y = Random.Range(0,Screen.height*2)-Screen.height;
		}else{
			x = Screen.width;
			y = Random.Range(0,Screen.height*2)-Screen.height;
		}

		return new Vector3(x,y);
	}

}
