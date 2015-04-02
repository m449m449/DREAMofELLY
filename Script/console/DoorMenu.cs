using UnityEngine;
using System.Collections;

public class DoorMenu : MonoBehaviour {
	public GameObject prticle;
	private int menuopne;
	private float time;
	private int count;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(menuopne == 1){
			GetKeyCode();
		}
		if(count == 1){
			time += Time.deltaTime;
			if(time > 0.1){
				if(GameObject.Find ("TargetSet(Clone)")){
					Destroy(GameObject.Find ("TargetSet(Clone)"));
				}
				time = 0;
				count = 0;
				TrapInstantiate.coreflag = 0;
				
			}
		}
	}
	//扉メニューを開いてる時の操作.
	private void GetKeyCode(){
		if(Input.GetKeyDown(KeyCode.Return)|| Input.GetMouseButtonUp(0)){
			if(Pop.menuflag >= 1){
				if(Pop.selectflag == 1){
					if((GameState.doorflag & 1) == 0){
						if(GameState.candycount >= 100){
							GameState.candycount -= 100;
							GameState.doorflag += (int)System.Math.Pow (2,Pop.selectflag-1);//閉めるドア情報をビット演算用に変えて送る.
							Pop.menuflag++;
							menuopne = 0;
						}
					}
				}else if(Pop.selectflag == 2){
					if((GameState.doorflag & 2) == 0){
						if(GameState.candycount >= 200){
							GameState.candycount -= 200;
							GameState.doorflag += (int)System.Math.Pow (2,Pop.selectflag-1);
							Pop.menuflag++;
							menuopne = 0;
						}
					}
				}else if(Pop.selectflag == 3){
					if((GameState.doorflag & 4) == 0){
						if(GameState.candycount >= 300){
							GameState.candycount -= 300;
							GameState.doorflag += (int)System.Math.Pow (2,Pop.selectflag-1);
							Pop.menuflag++;
							menuopne = 0;
						}
					}
				}else if(Pop.selectflag == 4){
					Pop.menuflag++;
					menuopne = 0;
				}
			}else{
				Pop.menuflag++;
				Pop.selectfanc = 1;
				Pop.selectflag = 1;
			}
		}
	}
	/*
	private void OnTriggerStay(Collider c){
		if(c.gameObject.tag == "Menu"){
			time = 0;
			if(count == 0){
				Instantiate(prticle);
				count = 1;
				TrapInstantiate.coreflag = 1;
			}
			if(Input.GetKeyDown(KeyCode.Return)|| Input.GetMouseButtonUp(0)){
				menuopne = 1;
			}
		}
	}
	*/
	
}
