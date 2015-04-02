using UnityEngine;
using System.Collections;
using System;

public class GameState : MonoBehaviour {
	private int[] wave = new int[]{5,7,1,8,10,12,1,9,0};//1で休憩.
	public static int statusflag= 0;
	public static int destroycount = 0;
	public static int damagecount = 20;
	public static int candycount  = 0;
	public static int doorflag = 6;
	public static int enemylevel = 0;
	public static int mouse = 0;
	private int rushflag = 0;
	private int rushcount = 0;
	private int l = 0;
	private int n = 0;
	private int m = 0;
	private int enemynum = 0;
	private int startnum = 0;
	private int kingpop = 0;
	private int tutocount = 0;
	private float time;
	public static int maxEnemy;
	//private int maxwave;
	//private int nowwave;
	public int oldenemynum = 0;
	public int oldstartnum = 0;
	public int enemypop = 0;
	public int GameOverSelect = 0;
	public static int clearflag = 0;
	public float poptime = 0f;
	public GUITexture startpic,gameoverpic,titlepic,retrypic,titlepic2,retrypic2;
	public GameObject[] wavepic = new GameObject[6];
	public GameObject[] Enemy = new GameObject[5];
	public GameObject BGM;
	public GameObject king;
	public GameObject kiseki;
	public GameObject door1,door2,door3;
	public GameObject doormodel1,doormodel2,doormodel3;
	public Transform[] door1start = new Transform[5];
	public Transform[] door2start = new Transform[5];
	public Transform[] door3start = new Transform[5];
	public GUITexture[] itemIcon = new GUITexture[7];
	public Rect[] itemRect = new Rect[7];
	private UnityEngine.Random ran;
	public GUIText candy;
	//public GUIText wave;
	public GUIText level;
	public GUIText memory;
	public GUIText maxEnemytex;
	public GUIText countdowntex;
	private double countdown;
	private double oldcountdown;
	// Use this for initialization
	void Start () {
		//static初期値.
		statusflag= 0;
		destroycount = 0;
		damagecount = 20;
		candycount = 50;
		clearflag = 0;
		enemylevel = 0;
		doorflag = 7;
		/*
		//Wave数を取得.
		for(int p = 0;wave[p] != 0;p++){
			maxwave = p + 1;
		}
		*/
		maxEnemy = 0;
		//アイテムアイコンのRect取得.
		for(int i = 1;i < 7;i++){
			//Rect r = itemIcon[i].guiTexture.GetScreenRect();
			Rect r = itemIcon[i].guiTexture.pixelInset;
			itemRect[i] = r;
		}
		//敵の総数算出.
		if(Application.loadedLevelName == "stagep"){
			for(int i = 0;i < 4;i++){
				maxEnemy += wave[i];
			}
			maxEnemy--;
		}else if(Application.loadedLevelName == "stage3"){
			for(int i = 0;i < 9;i++){
				int k = 1;
				if(i > 6){
					k = 3;
				}else if(i > 2){
					k = 2;
				}
				maxEnemy += wave[i] * k;
			}
			maxEnemy -= 2;
		}else if(Application.loadedLevelName == "freestage"){
			for(int i = 0;i < 9;i++){
				int k = 1;
				if(i > 6){
					k = 3;
				}else if(i > 2){
					k = 2;
				}
				maxEnemy += wave[i] * k;
			}
			maxEnemy -= 2;
		}
		//テキスト初期値.
		candy.text = "　 ×" + candycount.ToString();
		memory.text = "　 :" + damagecount.ToString();
		level.text = " 　:Lv." + (enemylevel+1).ToString();
		maxEnemytex.text = "　 ×" + maxEnemy.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(Input.GetKeyDown(KeyCode.F1)){
			Application.LoadLevel("stagep");	
		}else if(Input.GetKeyDown(KeyCode.F2)){
			//Application.LoadLevel("stage2");	
		}else if(Input.GetKeyDown(KeyCode.F3)){
			Application.LoadLevel("stage3");	
		}
		*/
		if(Input.GetKeyDown (KeyCode.M)){
			if(mouse == 0){
				mouse = 1;
			}else{
				mouse = 0;
			}
		}
		if(Pop.escselect == 0){//Pause.
			DamageCalculation();
			Prameters();
			if(rushflag == 0){
				if(statusflag == 0){
					Stay();
				}else if(statusflag == 1){
					Wave ();
				}
			}else{
				EnemyRush();
			}
			
			Door();
		}
		
		//Debug.Log (destroycount);
	}
	
	void Stay(){
		time += Time.deltaTime;
		poptime += Time.deltaTime;
		if(n == 0){
			//敵の侵攻ルート.
			if(poptime > 3f){
				do{
					m = (int)Mathf.Floor(UnityEngine.Random.Range(0f,5f));
				}while(oldstartnum == m);
				oldstartnum = m;
				EnemysTrails(m);
				poptime = 0f;
			}
			//スペースで開始.
			if(Input.GetKeyDown(KeyCode.Space)){
				poptime = 0;
				statusflag = 1;
				doorflag = 6;
				startpic.pixelInset = new Rect(Screen.width*1/2 - (709/2),0,709,130);
				Instantiate(startpic,new Vector3(0,0.5f,0f), Quaternion.Euler(0f,0f,0f));

			}
		}else{
			//休憩タイム.
			if(Application.loadedLevelName == "stagep"){
				if(tutocount == 0){
					Pop.escselect = 30;
					tutocount = 1;
				}
			}
			countdown = Math.Floor (31 - time);
			  //敵の侵攻ルート.
			if(poptime > 5f){
				do{
					m = (int)Mathf.Floor(UnityEngine.Random.Range(0f,5f));
				}while(oldstartnum == m);
				oldstartnum = m;
				EnemysTrails(m);
				poptime = 0f;
			}

			countdowntex.text = countdown.ToString();
			if(oldcountdown != countdown){
				oldcountdown = countdown;
				if(GameObject.Find ("CountDown(Clone)")){
					Destroy(GameObject.Find ("CountDown(Clone)"));
				}
				if(countdown != 0){
					Instantiate(countdowntex);
				}
			}
			if(countdown == 0){
				if(GameObject.Find ("CountDown(Clone)")){
					Destroy(GameObject.Find ("CountDown(Clone)"));
				}
				statusflag = 1;
			}
		}
	}
	
	void Wave(){
		/*
		//チートコード.
		if(Input.GetKey (KeyCode.K)){
			doorflag = 7;
			
		}
		*/
		//Wave制御.
		if(doorflag != 7){
		switch (n){
			case 3:
				if(Application.loadedLevelName == "stage2" || Application.loadedLevelName == "stage3"|| Application.loadedLevelName == "freestage"){
					doorflag = 4;
				}
				break;
			case 7:
				if(Application.loadedLevelName == "stage3"|| Application.loadedLevelName == "freestage"){
					doorflag = 0;
				}
				break;
			}
			if(wave[n] == 1){
				statusflag = 0;
				time = 0;
				enemylevel++;
				n++;
			}else if(wave[n] == 0){
				doorflag = 7;
			}else if(wave[n] > enemypop){//1waveのエネミーが湧き終わるまで.
				poptime += Time.deltaTime;
				if(poptime > 1f){
					poptime = 0f;
					enemypop++;
					do{
						enemynum = (int)Mathf.Round(UnityEngine.Random.Range(0f,2.4f));
					}while(oldenemynum == enemynum);
					Debug.Log (enemynum);
					if(enemynum == 0){
						if(enemylevel == 1){
							enemynum = 3;
						}else if(enemylevel == 2){
							enemynum = 4;
						}
					}
					oldenemynum = enemynum;
					do{
						startnum = (int)Mathf.Floor(UnityEngine.Random.Range(0f,5f));
					}while(oldstartnum == startnum);
					oldstartnum = startnum;
					EnemyPop(enemynum,startnum);
				}
			}
			//1wave分の敵を倒したら.
			int b = 1;//倍数.
			if(Application.loadedLevelName  == "stagep"){
				b = 1;
			}else if(doorflag == 0){
				b = 3;
			}else if(doorflag <= 4){
				b = 2;
			}
			if(wave[n] * b <= destroycount){
				switch (n){
				case 3:
					if(Application.loadedLevelName == "stagep"){
						clearflag = 1;
						statusflag = 2;
					}
					break;
				case 5:
					if(Application.loadedLevelName == "stage2"){
						clearflag = 1;
						statusflag = 2;
					}
					break;
				case 7:
					if(Application.loadedLevelName == "stage3" || Application.loadedLevelName == "freestage"){
						doorflag = 7;
					}
					break;
				}
				enemypop = 0;
				candycount += 30;
				n++;
				destroycount = 0;
			}
		}else{
			if(Application.loadedLevelName == "stage3" || Application.loadedLevelName == "freestage"){
				if(l == 0){
					rushflag = 1;
					BGM.GetComponent<BGMplayer>().BossBGM();
					rushcount = maxEnemy;
					l++;
				}
			}else{
				clearflag = 1;
				statusflag = 2;
			}
		}
	}
	//ドアが閉まったらラッシュ開始.
	void EnemyRush(){
		//休憩中なら中断.
		if(statusflag == 0){
			statusflag = 1;
			if(GameObject.Find ("CountDown(Clone)")){
				Destroy(GameObject.Find ("CountDown(Clone)"));
			}
		}
		doorflag = 6;
		if(rushcount > 1){
			poptime += Time.deltaTime;
			if(poptime > 0.8f){
				rushcount--;
				poptime = 0f;
				do{
					enemynum = (int)Mathf.Round(UnityEngine.Random.Range(0f,4f));
				}while(oldenemynum == enemynum);
				oldenemynum = enemynum;
				do{
					startnum = (int)Mathf.Round(UnityEngine.Random.Range(0f,4f));
				}while(oldstartnum == startnum);
				oldstartnum = startnum;
				EnemyPop(enemynum,startnum);
			}
		}else if(maxEnemy == 1){
			if(kingpop == 0){
				Instantiate(king,door1start[2].position, Quaternion.Euler(0f,-90f,0f));
				kingpop++;
			}
		}
	}
	void DamageCalculation(){
		if(damagecount <= 0){
			statusflag = 2;
		}
	}
	
	
	public void EnemyPop(int n,int m){
		Instantiate(Enemy[n],door1start[m].position, Quaternion.Euler(0f,-90f,0f));
		if(doorflag <= 4){
			Instantiate(Enemy[n],door2start[m].position, Quaternion.Euler(0f,-90f,0f));
		}
		if(doorflag == 0){
			Instantiate(Enemy[n],door3start[m].position, Quaternion.Euler(0f,-90f,0f));
		}
	}
	
	public void EnemysTrails(int m){
		Instantiate(kiseki,door1start[m].position, Quaternion.Euler(0f,-90f,0f));
		if(n >= 3 && Application.loadedLevelName!= "stagep"){
			Instantiate(kiseki,door2start[m].position, Quaternion.Euler(0f,-90f,0f));
		}
		if(n >= 7){
			Instantiate(kiseki,door3start[m].position, Quaternion.Euler(0f,-90f,0f));
		}
	}
	
	public void Prameters(){
		if(candycount < 0){
			candycount = 0;
		}
		if(damagecount < 0){
			damagecount = 0;
		}
		candy.text = "　 ×" + candycount.ToString();
		//nowwave = n + 1;
		//wave.text = "WAVE:" + nowwave.ToString() + "/" + maxwave.ToString();
		memory.text = "　 :" + damagecount.ToString();
		level.text = " 　:Lv." + (enemylevel+1).ToString();
		maxEnemytex.text = "　 ×" + maxEnemy.ToString();
		itemIcon[0].pixelInset = itemRect[TrapInstantiate.keyflag];
		if(TrapInstantiate.keyflag == 1){
			GameObject.Find ("item-1").transform.position = new Vector3(0.5f,0.01f,-0.1f);
		}else{
			GameObject.Find ("item-1").transform.position = new Vector3(0.5f,0f,-0.1f);
		}
		if(TrapInstantiate.keyflag == 2){
			GameObject.Find ("item-2").transform.position = new Vector3(0.5f,0.01f,-0.1f);
		}else{
			GameObject.Find ("item-2").transform.position = new Vector3(0.5f,0f,-0.1f);
		}
		if(TrapInstantiate.keyflag == 3){
			GameObject.Find ("item-3").transform.position = new Vector3(0.5f,0.01f,-0.1f);
		}else{
			GameObject.Find ("item-3").transform.position = new Vector3(0.5f,0f,-0.1f);
		}if(TrapInstantiate.keyflag == 4){
			GameObject.Find ("item-4").transform.position = new Vector3(0.5f,0.01f,-0.1f);
		}else{
			GameObject.Find ("item-4").transform.position = new Vector3(0.5f,0f,-0.1f);
		}
		if(TrapInstantiate.keyflag == 5){
			GameObject.Find ("item-5").transform.position = new Vector3(0.5f,0.01f,-0.1f);
		}else{
			GameObject.Find ("item-5").transform.position = new Vector3(0.5f,0f,-0.1f);
		}
		if(TrapInstantiate.keyflag == 6){
			GameObject.Find ("item-6").transform.position = new Vector3(0.5f,0.01f,-0.1f);
		}else{
			GameObject.Find ("item-6").transform.position = new Vector3(0.5f,0f,-0.1f);
		}
	}
	
	public void Door(){
		if((doorflag & 1) != 0){
			if(door1.transform.position.y >= 1.6f){
				Vector3 pos;
				pos = this.door1.transform.position;
				pos.y -= Time.deltaTime;
				this.door1.transform.position = pos;
			}
		}else{
			Vector3 pos;
			pos = this.door1.transform.position;
			pos.y = 4;
			this.door1.transform.position = pos;
			doormodel1.GetComponent<EnemyMotion>().animator.SetBool("open",true);
		}
		if((doorflag & 2) != 0){
			if(door2.transform.position.y >= 1.6f){
				Vector3 pos;
				pos = this.door2.transform.position;
				pos.y -= Time.deltaTime;
				this.door2.transform.position = pos;
			}
			
		}else{
			Vector3 pos;
			pos = this.door2.transform.position;
			pos.y = 4;
			this.door2.transform.position = pos;
			doormodel2.GetComponent<EnemyMotion>().animator.SetBool("open",true);
		}
		if((doorflag & 4) != 0){
			if(door3.transform.position.y >= 1.6f){
				Vector3 pos;
				pos = this.door3.transform.position;
				pos.y -= Time.deltaTime;
				this.door3.transform.position = pos;
			}
		}else{
			Vector3 pos;
			pos = this.door3.transform.position;
			pos.y = 4;
			this.door3.transform.position = pos;
			doormodel3.GetComponent<EnemyMotion>().animator.SetBool("open",true);
		}
	}
}