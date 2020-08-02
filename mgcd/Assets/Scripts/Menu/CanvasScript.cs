using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour {

	public int SceneIndex;

	// Use this for initialization
	void Start () {
		GameController.kill = 0;
		DontDestroyOnLoad (GameObject.FindGameObjectWithTag ("bgm"));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(SceneIndex > 0){
				Application.LoadLevel(SceneIndex-1);
			}else{
				Application.Quit();
			}
		}
	}

	public void EnterButtonClicked(){
		StartCoroutine (changeScene ("MenuScene"));
	}
	
	public void StoryButtonClicked(){
		GameController.GAMESTATE = GameController.STORY;
		StartCoroutine (changeScene ("GameScene"));
	}
		
	public void EndlessButtonClicked(){
		GameController.GAMESTATE = GameController.ENDLESS;
		StartCoroutine (changeScene ("GameScene"));
	}
	
	public void HomeButtonClicked(){
		StartCoroutine (changeScene ("OpeningScene"));
	}
		
	public void SettingButtonClicked(){

	}

	IEnumerator changeScene(string name){
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevel (name);
	}
}
