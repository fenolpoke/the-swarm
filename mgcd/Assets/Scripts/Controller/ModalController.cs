using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ModalController : MonoBehaviour{

	private static GameObject modalFinish,modalGameOver;
	public static int GAMEOVER = 0;
	public static int FINISH = 1;

	public Sprite[] ratingImg = new Sprite[4];

	void Start(){
		modalFinish = GameObject.Find ("ModalFinishLevel");
		modalGameOver = GameObject.Find ("ModalGameOver");
		if(modalFinish) modalFinish.SetActive (false);
		if(modalGameOver) modalGameOver.SetActive (false);
	}
	public void showModalDialog(int state,int kill){
		if(state == FINISH)modalFinish.SetActive (true);
		else if(state == GAMEOVER)modalGameOver.SetActive(true);



		Text txtKill = GameObject.FindGameObjectWithTag("txtKill").GetComponent<Text>();
		Text txtScore = GameObject.FindGameObjectWithTag("txtScore").GetComponent<Text>();
		Image ratingImage = GameObject.FindGameObjectWithTag ("ratingImage").GetComponent<Image> ();
		int score = kill * 100;

		txtKill.text = kill + "";
		txtScore.text = score + "";

		if (score < 1000*EnemyController.GAME_LEVEL)ratingImage.sprite = ratingImg [0];
		else if (score < 2000*EnemyController.GAME_LEVEL)ratingImage.sprite = ratingImg [1];
		else if (score < 3000*EnemyController.GAME_LEVEL)ratingImage.sprite = ratingImg [2];
		else ratingImage.sprite = ratingImg [3];

		if (state == GAMEOVER)GameController.kill = 0;
	}

}
