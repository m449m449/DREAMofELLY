using UnityEngine;
using System.Collections;

public class TrapInstantiate : MonoBehaviour {
	
	Vector3 pos;
	private float scroll;
	public  GameObject trap;
	public  GameObject trap1;
	public  GameObject trap2;
	public  GameObject trap3;
	public  GameObject trap4;
	public  GameObject trap5;
	public  GameObject trap6;
	public  GameObject trap7;
	public  GameObject trap8;
	public  GameObject Mcamera = null;
	private GameObject	player = null;
	public static int possible = 1;
	public static int keyflag = 1;
	public static int coreflag = 0;
	public AudioClip hanabi;
	public AudioClip settyakuzai;
	public AudioClip wanasettion;
	AudioSource audioSource;
	
	public GameObject alignment;
	// Use this for initialization
	void Start () {
		possible = 1;
		keyflag = 1;
		coreflag = 0;
		this.player = GameObject.FindGameObjectWithTag("Player");
		this.Mcamera = GameObject.FindGameObjectWithTag("MainCamera");
		audioSource = gameObject.GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Pop.escselect == 0){//Pause.
			scroll = Input.GetAxis("Mouse ScrollWheel");
			if(scroll > 0){
				keyflag--;
			}else if(scroll < 0){
				keyflag++;
			}
			if(keyflag < 1){
				keyflag = 6;
			}else if(keyflag > 6){
				keyflag = 1;
			}
			if(Input.GetKeyDown (KeyCode.Alpha0)|| Input.GetKeyDown(KeyCode.Keypad0)){
				//keyflag = 0;
			}else if(Input.GetKeyDown (KeyCode.Alpha1)|| Input.GetKeyDown(KeyCode.Keypad1)){
				keyflag = 1;
			}else if(Input.GetKeyDown (KeyCode.Alpha2)|| Input.GetKeyDown(KeyCode.Keypad2)){
				keyflag = 2;
			}else if(Input.GetKeyDown (KeyCode.Alpha3)|| Input.GetKeyDown(KeyCode.Keypad3)){
				keyflag = 3;
			}else if(Input.GetKeyDown (KeyCode.Alpha4)|| Input.GetKeyDown(KeyCode.Keypad4)){
				keyflag = 4;
			}else if(Input.GetKeyDown (KeyCode.Alpha5)|| Input.GetKeyDown(KeyCode.Keypad5)){
				keyflag = 5;	
			}else if(Input.GetKeyDown (KeyCode.Alpha6)|| Input.GetKeyDown(KeyCode.Keypad6)){
				keyflag = 6;		
			}else if(Input.GetKeyDown (KeyCode.Return) || Input.GetMouseButtonUp(0)){
				if(coreflag == 0){
					if(possible == 0){
						if(keyflag == 1){
							TrapInstall ();
						}else{
							GetComponent<Pop>().NotInstall();
						}
					}else{
						TrapInstall ();
					}
				}
			}	
			if(GameState.statusflag == 2){
				Destroy(this);
			}
		}
		
	}
	
	
	
	private void TrapInstall(){
		
		if(keyflag == 1){
			//風船.
			if(GameState.candycount >= 1){
				GameState.candycount -= 1;//コスト.
				//audioSource.clip = hanabi;
				//audioSource.PlayOneShot( hanabi );
				Vector3 pos;
				pos = this.player.transform.position + (this.player.transform.forward * 0.1f);
				pos.y = 1;
				Instantiate (trap1,pos,new Quaternion(0,0,0,0));
			}else{
				GetComponent<Pop>().ErrorPop();
			}
		}else if(keyflag == 2){
			//スライム.
			//x軸が0.1でないなら生成する.
			if(PlaneTrapCollision.efx != 0.1f){
				if(GameState.candycount >= 3){
					GameState.candycount -= 3;//コスト.
					audioSource.clip = settyakuzai;
					audioSource.PlayOneShot( settyakuzai );
					Instantiate (trap3,new Vector3(PlaneTrapCollision.efx,0.5f,PlaneTrapCollision.efz),Quaternion.Euler(0f, PlaneTrapCollision.ery, 0f));
				}else{
					GetComponent<Pop>().ErrorPop();
				}
			}
		}else if(keyflag == 3){
			//スプリング.
			//x軸が0.1でないなら生成する.
			if(PlaneTrapCollision.efx != 0.1f){
				if(GameState.candycount >= 8){
					GameState.candycount -= 8;//コスト.
					audioSource.clip = wanasettion;
					audioSource.PlayOneShot( wanasettion );
					Instantiate (trap4,new Vector3(PlaneTrapCollision.efx,0.5f,PlaneTrapCollision.efz),Quaternion.Euler(0f, PlaneTrapCollision.ery, 0f));
				}else{
					GetComponent<Pop>().ErrorPop();
				}
			}
		}else if(keyflag == 4){
			//壁トラップ.
			if(GameState.candycount >= 8){
				//y軸が0でないなら設置する.
				if(WallTrapCollision.efy != 0){
					GameState.candycount -= 8;
					audioSource.clip = wanasettion;
					audioSource.PlayOneShot( wanasettion );
					Instantiate (trap5,new Vector3(WallTrapCollision.efx,WallTrapCollision.efy,WallTrapCollision.efz),Quaternion.Euler(0f, WallTrapCollision.ery, 90f));
				}else{
					GetComponent<Pop>().NotInstall();
				}
				
			}else{
				GetComponent<Pop>().ErrorPop();
			}
		}else if(keyflag == 5){
			//振り子.
			if(GameState.candycount >= 15){
				//y軸が-1でないなら設置する.
				if(CeilingTrapCollision.efy != -1){
					GameState.candycount -= 15;
					audioSource.clip = wanasettion;
					audioSource.PlayOneShot( wanasettion );
					Instantiate (trap6,new Vector3(CeilingTrapCollision.efx,CeilingTrapCollision.efy,CeilingTrapCollision.efz),Quaternion.Euler(0f, CeilingTrapCollision.ery, 0f));
				}else{
					GetComponent<Pop>().NotInstall();
				}
			}else{
				GetComponent<Pop>().ErrorPop();
			}
		}else if(keyflag == 6){
			//タライ大.
			if(GameState.candycount >= 15){
				GameState.candycount -= 15;
				audioSource.clip = wanasettion;
				audioSource.PlayOneShot( wanasettion );
				Instantiate (trap8,new Vector3(CeilingTrapCollision.efx,CeilingTrapCollision.efy,CeilingTrapCollision.efz),Quaternion.Euler(0f, CeilingTrapCollision.ery, 0f));
				
			}else{
				GetComponent<Pop>().ErrorPop();
			}
			/*
			 //水風船.
			//Instantiate (trap1,this.player.transform.position,Quaternion.Euler(0, 0, 0));
			*/
		}
		
		
	
	}
}
