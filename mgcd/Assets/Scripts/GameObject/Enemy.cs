using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy{

	private string name;
	public Image img;

	private int maxMove=1000;
	private float speedX,speedY;
	private Vector3 target;
	private static float DELAY = 0.01f;

	private Timer timer;
	public Enemy(string name,Image img,Canvas parent,Vector3 target,Sprite[] swarm){
		this.name = name;
		this.img = img;

		this.img.name = this.name;

		if(this.img.transform.position.x < 0)this.img.GetComponent<Image> ().sprite = swarm [1];
		else this.img.sprite = swarm [0	];
		this.img.transform.SetParent (parent.transform,false);

		                                             
		this.timer = new Timer(DELAY);
		this.target = target;

		selectLevel ();
	}

	public static string getNewName(){return "Enemy" + (System.DateTime.Now + "" + System.DateTime.Now.Millisecond);}
	public string getName(){return name;}
	public Image getObject(){return img;}

	private void selectLevel(){

		for (int i = 1; i < EnemyController.GAME_LEVEL; i++) {
			this.maxMove = this.maxMove*5/6;
				}
		Debug.Log (this.maxMove);
		this.speedX = (target.x - this.img.transform.position.x )/ maxMove;
		this.speedY = (target.y - this.img.transform.position.y )/ maxMove;
	}

	public void move(Vector3 p){
		float x = this.img.transform.position.x;
		float y = this.img.transform.position.y;

		if (timer.getTimer () < Time.time) {
			x+= speedX;
			y+= speedY;

			timer.setTimer(DELAY);
			this.img.transform.position = new Vector3(x,y,-236);
		}
	}

	public bool checkIntersect(GameController gameController){

		Vector3 playerPos = new Vector3 (gameController.player.rectTransform.position.x+23/2,
		                                 gameController.player.rectTransform.position.y+20/2);
		Vector3 enemyPos = new Vector3 (this.img.transform.position.x+40*0.75f/2,
		                                 this.img.transform.position.y+28.4f*0.75f/2);
//		Debug.Log (this.img.rectTransform.sizeDelta);
		//Debug.Log ("enemy:"+this.img.transform.position + " and  " + this.img.sprite.rect.width + ",h:"+this.img.sprite.rect.height);
		//Debug.Log ("player:"+gameController.player.rectTransform.position + " and  " + gameController.player.sprite.rect.width + ",h:"+gameController.player.sprite.rect.height);
		if(new Bounds(this.img.transform.position,
		              new Vector3(40*0.75f,28.4f*0.75f)).
		              Intersects(new Bounds(gameController.player.rectTransform.position,new Vector3(23,20)))){
			return true;
		}
		return false;

	}

}
