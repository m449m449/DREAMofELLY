using UnityEngine;
using System.Collections;
using System;

public class Pop : MonoBehaviour {
	private float time = 0f;
	private int helpflag;
	public GameObject obj;
	public GUITexture errormassage;
	public GUITexture notinstall;
	public GUITexture traprecovery;
	public GUITexture headshot;
	public GUITexture closedmenu;
	public GUITexture closedmenuback;
	public GUITexture menuselect;
	public GUITexture escbackground;
	public GUITexture gameover;
	public GUITexture gameclear;
	public GUITexture next1,next2;
	public GUITexture title1;
	public GUITexture title2;
	public GUITexture end1,end2;
	public GUITexture back1,back2;
	public GUITexture retry1,retry2;
	public GUITexture menuHelp1,menuHelp2;
	public GUITexture help1,help2,help3,help4,help5;
	public GUITexture tutorial,tutorial2;
	public static int escselect = 0;
	public static int clearselect = 0;
	public static int selectflag = 1;//扉メニュー.
	public static int menuflag;
	public static int selectfanc;
	public static int recoveryflag;
	// Use this for initialization
	void Start () {
		selectflag = 1;
		menuflag = 0;
		selectfanc = 0;
		recoveryflag = 0;
		escselect = 0;
		clearselect = 0;
		if(Application.loadedLevelName == "stagep"){
			escselect = 20;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find ("ERROR(Clone)")){
			time += Time.deltaTime;
			obj = GameObject.Find ("ERROR(Clone)");
		}else if(GameObject.Find ("InstallERROR(Clone)")){
			time += Time.deltaTime;
			obj = GameObject.Find ("InstallERROR(Clone)");
		}else{
			time = 0;
		}
		if(time > 1f){
			Destroy(obj);
			time = 0f;
		}
		if(menuflag != 0){
			DoorMenu ();
		}
		if(selectfanc == 1){
			Select();
		}
		TrapRecovery();
		Tutorial();
		EscMenu();
		HelpMenu();
		ClearorOverMenu();
	}
	public void TrapRecovery(){
		if(recoveryflag == 1){
			if(!GameObject.Find ("TrapRecovery(Clone)")){
				Instantiate(traprecovery);
			}
		}else{
			if(GameObject.Find ("TrapRecovery(Clone)")){
				Destroy(GameObject.Find ("TrapRecovery(Clone)"));
			}
		}
		if(TrapInstantiate.keyflag == 1){
			recoveryflag = 0;
		}
			
	}
		
	
	//キャンディが足りません.
	public void ErrorPop(){
		time = 0f;
		if(!GameObject.Find("ERROR(Clone)")){
			Instantiate(errormassage);
		}
	}
	//そこには置けません.
	public void NotInstall(){
		time = 0f;
		if(!GameObject.Find("InstallERROR(Clone)")){
			Instantiate(notinstall);
		}
	}
	//扉メニュー.
	public void DoorMenu(){
		if(!GameObject.Find ("closedmenu(Clone)")){
			Instantiate(closedmenu);
			Instantiate(closedmenuback);
		}
		if(menuflag >= 2){
			if(GameObject.Find ("closedmenu(Clone)")){
				Destroy(GameObject.Find ("closedmenu(Clone)"));
				Destroy(GameObject.Find ("closedmenuback(Clone)"));
			}
			
			if(GameObject.Find ("menuselect(Clone)")){
				Destroy(GameObject.Find ("menuselect(Clone)"));
			}
			menuflag = 0;
			selectfanc =  0;
		}
	}
	//扉メニューのセレクト.
	public void Select(){
		float y;
		if(GameObject.Find ("menuselect(Clone)")){
			Destroy(GameObject.Find ("menuselect(Clone)"));
		}
		if(selectflag == 1){
			y = 0f;
			menuselect.pixelInset = new Rect(1,y,199,200);
			Instantiate(menuselect);
		}else if(selectflag == 2){
			y = -32;
			menuselect.pixelInset = new Rect(1,y,199,200);
			Instantiate(menuselect);
		}else if(selectflag == 3){
			y = -64;
			menuselect.pixelInset = new Rect(1,y,199,200);
			Instantiate(menuselect);
		}else if(selectflag == 4){
			y = -96;
			menuselect.pixelInset = new Rect(1,y,199,200);
			Instantiate(menuselect);
		}
	}
	//チュートリアル用画像.
	void Tutorial(){
		if(escselect >= 20 && escselect < 25){
			if(!GameObject.Find("Tutorial(Clone)")){
				Instantiate(tutorial);
			}
			if(escselect == 21){
				Destroy(GameObject.Find("Tutorial(Clone)"));
				escselect = 0;
			}
		}
		if(escselect >= 30 && escselect < 35){
			if(!GameObject.Find("Tutorial2(Clone)")){
				Instantiate(tutorial2);
			}
			if(escselect == 31){
				Destroy(GameObject.Find("Tutorial2(Clone)"));
				escselect = 0;
			}
		}
	}
	void HelpMenu(){
		if(GameState.statusflag != 2){
			if(Input.GetKeyDown(KeyCode.F1)){
				if(escselect == 0){
					escselect = 11;
					help1.pixelInset = new Rect(Screen.width/-2,Screen.height/-2,Screen.width,Screen.height);
					Instantiate(help1);
					help2.pixelInset = new Rect(Screen.width/-2,Screen.height/-2,Screen.width,Screen.height);
					Instantiate(help2);
					help3.pixelInset = new Rect(Screen.width/-2,Screen.height/-2,Screen.width,Screen.height);
					Instantiate(help3);
					help4.pixelInset = new Rect(Screen.width/-2,Screen.height/-2,Screen.width,Screen.height);
					Instantiate(help4);
					help5.pixelInset = new Rect(Screen.width/-2,Screen.height/-2,Screen.width,Screen.height);
					Instantiate(help5);
				}else if(escselect >= 10){
					escselect = 14;
				}
				
			}
			if(escselect >= 10 && escselect < 20){
				if(escselect == 10){
					//GameObject.Find("Help1(Clone)")
					GameObject.Find("Help1(Clone)").transform.position = new Vector3(0.5f,0.5f,1.1f);
				}else{
					GameObject.Find("Help1(Clone)").transform.position = new Vector3(0.5f,0.5f,1f);
				}
				if(escselect == 11){
					//GameObject.Find("Help1(Clone)")
					GameObject.Find("Help1(Clone)").transform.position = new Vector3(0.5f,0.5f,1.1f);
				}else{
					GameObject.Find("Help1(Clone)").transform.position = new Vector3(0.5f,0.5f,1f);
				}
				if(escselect == 12){
					//GameObject.Find("Help2(Clone)")
					GameObject.Find("Help2(Clone)").transform.position = new Vector3(0.5f,0.5f,1.1f);
				}else{
					GameObject.Find("Help2(Clone)").transform.position = new Vector3(0.5f,0.5f,1f);
				}
				if(escselect == 13){
					//GameObject.Find("Help3(Clone)")
					GameObject.Find("Help3(Clone)").transform.position = new Vector3(0.5f,0.5f,1.1f);
				}else{
					GameObject.Find("Help3(Clone)").transform.position = new Vector3(0.5f,0.5f,1f);
				}
				if(Input.GetMouseButtonUp(0)){
					escselect++;
				}
				if(escselect == 14){
					Destroy(GameObject.Find("Help1(Clone)"));
					Destroy(GameObject.Find("Help2(Clone)"));
					Destroy(GameObject.Find("Help3(Clone)"));
					Destroy(GameObject.Find("Help4(Clone)"));
					Destroy(GameObject.Find("Help5(Clone)"));
					if(helpflag == 1){
							escselect = 1;
							helpflag = 0;
						}else{
							escselect = 0;
					}
				}
			}
		}
	}
	
	
	
	//エスケープメニュー.
	public void EscMenu(){
		if(GameState.statusflag != 2){
			if(escselect < 10){
				if(Input.GetKeyDown(KeyCode.Escape)){
					escselect++;
					if(escselect >= 2 && escselect < 10){
						switch (escselect){
						case 2:
							Destroy(GameObject.Find ("Title2(Clone)"));
							break;
						case 3:
							Destroy(GameObject.Find ("End2(Clone)"));
							break;
						case 4:
							Destroy(GameObject.Find ("Back2(Clone)"));
							break;
						case 5:
							Destroy(GameObject.Find ("MenuHelp2(Clone)"));
							break;
						}
						Destroy(GameObject.Find ("Title1(Clone)"));
						Destroy(GameObject.Find ("MenuHelp1(Clone)"));
						Destroy(GameObject.Find ("End1(Clone)"));
						Destroy(GameObject.Find ("Back1(Clone)"));
						Destroy(GameObject.Find ("background(Clone)"));
						escselect = 0;
					}
				}
				if(escselect != 0){
					if(!GameObject.Find("Title1(Clone)")){
						//title1.pixelInset = new Rect(Screen.width*1/2 - (128/2),100,128,58);
						Instantiate(title1,new Vector3(0.5f,0.75f,1.1f), Quaternion.Euler(0f,0f,0f));
					}
					if(!GameObject.Find("MenuHelp1(Clone)")){
						Instantiate(menuHelp1,new Vector3(0.5f,0.6f,1.1f), Quaternion.Euler(0f,0f,0f));
					}
					if(!GameObject.Find("End1(Clone)")){
						//end1.pixelInset = new Rect(Screen.width*1/2 - (128/2),0,128,58);
						Instantiate(end1,new Vector3(0.49f,0.45f,1.1f), Quaternion.Euler(0f,0f,0f));
					}
					if(!GameObject.Find("Back1(Clone)")){
						//back1.pixelInset = new Rect(Screen.width*1/2 - (128/2),-100,128,58);
						Instantiate(back1,new Vector3(0.5f,0.3f,1.1f), Quaternion.Euler(0f,0f,0f));
					}
					if(!GameObject.Find("background(Clone)")){
						escbackground.pixelInset = new Rect(Screen.width*1/2 - (1920/2),Screen.height*1/2 - (1080/2),1920,1080);
						Instantiate(escbackground,new Vector3(0f,0f,1f), Quaternion.Euler(0f,0f,0f));
					}
				}
				if(escselect == 2){
					if(!GameObject.Find ("Title2(Clone)")){
						//title2.pixelInset = new Rect(Screen.width*1/2 - (128/2),100,128,58);
						Instantiate(title2,new Vector3(0.5f,0.75f,1.11f), Quaternion.Euler(0f,0f,0f));
					}
				}else{
					if(GameObject.Find ("Title2(Clone)")){
						Destroy(GameObject.Find ("Title2(Clone)"));
					}
				}
				if(escselect == 3){
					if(!GameObject.Find ("End2(Clone)")){
						//end2.pixelInset = new Rect(Screen.width*1/2 - (128/2),0,128,58);
						Instantiate(end2,new Vector3(0.49f,0.45f,1.11f), Quaternion.Euler(0f,0f,0f));
					}
				}else{
					if(GameObject.Find ("End2(Clone)")){
						Destroy(GameObject.Find ("End2(Clone)"));
					}
				}if(escselect == 4){
					if(!GameObject.Find ("Back2(Clone)")){
						//back2.pixelInset = new Rect(Screen.width*1/2 - (128/2),-100,128,58);
						Instantiate(back2,new Vector3(0.5f,0.3f,1.11f), Quaternion.Euler(0f,0f,0f));
					}
				}else{
					if(GameObject.Find ("Back2(Clone)")){
						Destroy(GameObject.Find ("Back2(Clone)"));
					}
				}
				if(escselect == 5){
					if(!GameObject.Find("MenuHelp2(Clone)")){
						Instantiate(menuHelp2,new Vector3(0.5f,0.6f,1.11f), Quaternion.Euler(0f,0f,0f));
					}
				}else{
					if(GameObject.Find ("MenuHelp2(Clone)")){
						Destroy(GameObject.Find ("MenuHelp2(Clone)"));
					}
				}
				if(escselect != 0){
					/*
					if(Input.GetKeyDown(KeyCode.UpArrow)){
						if(escselect < 3){
							escselect = 2;
						}else{
							escselect--;
						}
					}
					if(Input.GetKeyDown(KeyCode.DownArrow)){
						if(escselect > 3){
							escselect = 4;
						}else{
							escselect++;
						}
					}
					*/
					if(Input.GetKeyDown(KeyCode.Return)|| Input.GetMouseButtonUp(0)){
						switch (escselect){
						case 2:
							Destroy(GameObject.Find ("Title2(Clone)"));
							escselect = 0;
							Application.LoadLevel("Title");
							break;
						case 3:
							Destroy(GameObject.Find ("End2(Clone)"));
							escselect = 0;
							Application.Quit();
							break;
						case 4:
							Destroy(GameObject.Find ("Back2(Clone)"));
							escselect = 0;
							break;
						case 5:
							Destroy(GameObject.Find ("MenuHelp2(Clone)"));
							escselect = 10;
							helpflag = 1;
							help1.pixelInset = new Rect(Screen.width/-2,Screen.height/-2,Screen.width,Screen.height);
							Instantiate(help1);
							help2.pixelInset = new Rect(Screen.width/-2,Screen.height/-2,Screen.width,Screen.height);
							Instantiate(help2);
							help3.pixelInset = new Rect(Screen.width/-2,Screen.height/-2,Screen.width,Screen.height);
							Instantiate(help3);
							help4.pixelInset = new Rect(Screen.width/-2,Screen.height/-2,Screen.width,Screen.height);
							Instantiate(help4);
							help5.pixelInset = new Rect(Screen.width/-2,Screen.height/-2,Screen.width,Screen.height);
							Instantiate(help5);
							break;
						}
						Destroy(GameObject.Find ("Title1(Clone)"));
						Destroy(GameObject.Find ("MenuHelp1(Clone)"));
						Destroy(GameObject.Find ("End1(Clone)"));
						Destroy(GameObject.Find ("Back1(Clone)"));
						Destroy(GameObject.Find ("background(Clone)"));
					}
				}
			}
		}
	}
	public void ClearorOverMenu(){
		
		if(GameState.statusflag == 2){
			/*
			if(Application.loadedLevelName == "stage3"){
				if(GameState.clearflag == 1){
					Application.LoadLevel("scene3");
				}
			}
			*/
			//ちーと用.
			if(clearselect == 0){
				clearselect = 1;
			}
			if(clearselect != 0){
				if(GameState.clearflag == 1){
					if(!GameObject.Find("Clear(Clone)")){
						Instantiate(gameclear,new Vector3(0.5f,0.8f,1.1f), Quaternion.Euler(0f,0f,0f));
					}
					if(Application.loadedLevelName == "freestage"){
						if(!GameObject.Find("Retry1(Clone)")){
							Instantiate(retry1,new Vector3(0.5f,0.6f,1.1f), Quaternion.Euler(0f,0f,0f));
						}
					}else{
						if(!GameObject.Find("Next1(Clone)")){
							//next1.pixelInset = new Rect(Screen.width*1/2 - (128/2),100,128,58);
							Instantiate(next1,new Vector3(0.5f,0.6f,1.1f), Quaternion.Euler(0f,0f,0f));
						}
					}
				}else{
					if(!GameObject.Find("GameOver(Clone)")){
						//gameover.pixelInset = new Rect(Screen.width*1/2 - (128/2),250,128,58);
						Instantiate(gameover,new Vector3(0.5f,0.8f,1.1f), Quaternion.Euler(0f,0f,0f));
					}
					if(!GameObject.Find("Retry1(Clone)")){
						//retry1.pixelInset = new Rect(Screen.width*1/2 - (128/2),100,128,58);
						Instantiate(retry1,new Vector3(0.5f,0.6f,1.1f), Quaternion.Euler(0f,0f,0f));
					}
				}
				if(!GameObject.Find("Title1(Clone)")){
					//title1.pixelInset = new Rect(Screen.width*1/2 - (128/2),0,128,58);
					Instantiate(title1,new Vector3(0.5f,0.45f,1.1f), Quaternion.Euler(0f,0f,0f));
				}
				if(!GameObject.Find("End1(Clone)")){
					//end1.pixelInset = new Rect(Screen.width*1/2 - (128/2),-100,128,58);
					Instantiate(end1,new Vector3(0.49f,0.3f,1.1f), Quaternion.Euler(0f,0f,0f));
				}
				if(!GameObject.Find("background(Clone)")){
					escbackground.pixelInset = new Rect(Screen.width*1/2 - (1920/2),Screen.height*1/2 - (1080/2),1920,1080);
					Instantiate(escbackground,new Vector3(0f,0f,1f), Quaternion.Euler(0f,0f,0f));
				}
			}
			if(clearselect == 2){
				if(GameState.clearflag == 1){
					if(Application.loadedLevelName == "freestage"){
						if(!GameObject.Find ("Retry2(Clone)")){
							//retry2.pixelInset = new Rect(Screen.width*1/2 - (128/2),100,128,58);
							Instantiate(retry2,new Vector3(0.5f,0.6f,1.11f), Quaternion.Euler(0f,0f,0f));
						}
					}else{
						if(!GameObject.Find ("Next2(Clone)")){
							//next2.pixelInset = new Rect(Screen.width*1/2 - (128/2),100,128,58);
							Instantiate(next2,new Vector3(0.5f,0.6f,1.11f), Quaternion.Euler(0f,0f,0f));
						}
					}
				}else{
					if(!GameObject.Find ("Retry2(Clone)")){
					//	retry2.pixelInset = new Rect(Screen.width*1/2 - (128/2),100,128,58);
						Instantiate(retry2,new Vector3(0.5f,0.6f,1.11f), Quaternion.Euler(0f,0f,0f));
					}
				}
			}else{
				if(GameObject.Find ("Next2(Clone)")){
					Destroy(GameObject.Find ("Next2(Clone)"));
				}
				if(GameObject.Find ("Retry2(Clone)")){
					Destroy(GameObject.Find ("Retry2(Clone)"));
				}
			}
			if(clearselect == 3){
				if(!GameObject.Find ("Title2(Clone)")){
					//title2.pixelInset = new Rect(Screen.width*1/2 - (128/2),0,128,58);
					Instantiate(title2,new Vector3(0.5f,0.45f,1.11f), Quaternion.Euler(0f,0f,0f));
				}
			}else{
				if(GameObject.Find ("Title2(Clone)")){
					Destroy(GameObject.Find ("Title2(Clone)"));
				}
			}
			if(clearselect == 4){
				if(!GameObject.Find ("End2(Clone)")){
					//end2.pixelInset = new Rect(Screen.width*1/2 - (128/2),-100,128,58);
					Instantiate(end2,new Vector3(0.49f,0.3f,1.11f), Quaternion.Euler(0f,0f,0f));
				}
			}else{
				if(GameObject.Find ("End2(Clone)")){
					Destroy(GameObject.Find ("End2(Clone)"));
				}
			}
			if(clearselect != 0){	
				/*
				if(Input.GetKeyDown(KeyCode.UpArrow)){
					Debug.Log (clearselect);		
					if(clearselect < 3){
						clearselect = 2;
					}else{
						clearselect--;
					}
				}
				if(Input.GetKeyDown(KeyCode.DownArrow)){
					if(clearselect > 3){
						clearselect = 4;
					}else{
						clearselect++;
					}
				}
				*/
				if(Input.GetKeyDown(KeyCode.Return)|| Input.GetMouseButtonUp(0)){
					switch (clearselect){
					case 2:
						if(GameState.clearflag == 1){
							if(Application.loadedLevelName == "stagep"){
								Destroy(GameObject.Find ("Next2(Clone)"));
								//Application.LoadLevel("scene2");
								Application.LoadLevel("stage3");
							}else if(Application.loadedLevelName == "stage3"){
								Destroy(GameObject.Find ("Next2(Clone)"));
								//Application.LoadLevel("scene3");
								Application.LoadLevel("Title");
							}else if(Application.loadedLevelName == "freestage"){
								Destroy(GameObject.Find ("Retry2(Clone)"));
								Application.LoadLevel("freestage");
							}
						}else{
							if(Application.loadedLevelName == "stagep"){
								Destroy(GameObject.Find ("Retry2(Clone)"));
								Application.LoadLevel("stagep");
							}else if(Application.loadedLevelName == "freestage"){
								Destroy(GameObject.Find ("Retry2(Clone)"));
								Application.LoadLevel("freestage");
							}else if(Application.loadedLevelName == "stage3"){
								Destroy(GameObject.Find ("Retry2(Clone)"));
								Application.LoadLevel("stage3");
							}
						}
						break;
					case 3:
						Destroy(GameObject.Find ("Title2(Clone)"));
						Application.LoadLevel("Title");
						break;
					case 4:
						Destroy(GameObject.Find ("End2(Clone)"));
						Application.Quit();		
						break;
					}
					if(GameObject.Find ("Next1(Clone)")){
						Destroy(GameObject.Find ("Next1(Clone)"));
					}
					if(GameObject.Find ("Retry1(Clone)")){
						Destroy(GameObject.Find ("Retry1(Clone)"));
					}
					Destroy(GameObject.Find ("Title1(Clone)"));
					Destroy(GameObject.Find ("End1(Clone)"));
					Destroy(GameObject.Find ("background(Clone)"));
					clearselect = 0;
				}
			}
		}
	}
}
