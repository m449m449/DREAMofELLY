using UnityEngine;
using System.Collections;
using System;

public class WallTrapCollision : MonoBehaviour {
	public  GameObject trap;
	public  GameObject player;
	Vector3 WTpos;//,Ppos;
	public static int count = 0;
	private  float fx,fy,fz,px,py,pz,ry;
	private  float hitx,hitz,oldx,oldz;
	public static float efx,efy,efz,ery;
	private Vector3 itemPosition;
	private Vector3 itemRotate;
	// Use this for initialization
	void Start () {
		this.player = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		Delete();
		TargetPosition();
		Instant();
		Position ();
	}
	void TargetPosition(){
		Vector3 from = transform.position;
        Vector3 to = from + transform.forward * 100.0f;
        RaycastHit hit;
		LayerMask musk = 1 << 2;
        if(!Physics.Linecast(from, to, out hit,musk)){
            return;
        }
        //直線上にある最も近い物体を取得.
		itemPosition = hit.transform.position;
		ry = hit.transform.eulerAngles.y + 90;
		itemRotate = new Vector3(0,ry,90f);
	}
	
	void Instant(){
		if(TrapInstantiate.keyflag == 4){
			if(count == 0){
				Instantiate (trap,itemPosition,Quaternion.Euler(0,ry,90f));
				count++;
			}
		}
	}
	
	void Delete(){
		//デリート.
		if(GameObject.Find("pTrap2(Clone)")){
			if(TrapInstantiate.keyflag != 4){
				Destroy (GameObject.Find("pTrap2(Clone)"));
			}
		}else{
			count = 0;
		}
	}
	
	//いたずらを設置するポジション取得.
	private void Position(){
		if(GameObject.Find("pTrap2(Clone)")){
			GameObject.Find("pTrap2(Clone)").transform.position = itemPosition;
			GameObject.Find("pTrap2(Clone)").transform.eulerAngles = itemRotate;
			efx = itemPosition.x;
			efy = itemPosition.y;
			efz = itemPosition.z;
			ery = ry;
		}
	}
	/*
	private void OnTriggerStay(Collider c){
		//Debug.Log (c.gameObject.tag);
		if(c.gameObject.tag == "Wall" || c.gameObject.tag == "Goal" || c.gameObject.tag == "DummyWall"){
			time = 0;
			hitx = fx;
			hitz = fz;
			//Debug.Log ("Hitx:" + hitx + ",Hitz:" + hitz + "Oldx:" + oldx + ",Oldz:" + oldz);
			if(hitx != oldx || hitz != oldz){
				//this.transform.localPosition = defaultposition;
				hit = 0;
			}else{
				this.transform.position = new Vector3(fx,transform.position.y,fz);
				this.transform.localPosition = new Vector3(0,0,transform.localPosition.z);
				hit = 1;
				//壁に触れてる時はピンクのやつを出す.
				if(c.gameObject.tag == "Wall"){
					//time = 0;
					//Debug.Log ("Hitx:" + hitx + ",Hitz:" + hitz + "Oldx:" + oldx + ",Oldz:" + oldz);
					if(efx != fx || efz != fz){
						if(TrapInstantiate.keyflag == 4){
							colflag = 1;
							if(count == 0 ||count == 1){
									Instantiate (trap,new Vector3(efx,fy,efz),Quaternion.Euler(0,ry,90f));
									efx = hitx;
									efy = fy;
									efz = hitz;
									ery = ry;
									count++;
							}
						}
					}
				}
			}
			
			
			if(c.gameObject.tag == "Goal"){
				//time = 0;
				TrapInstantiate.coreflag = 1;
				if(Input.GetKeyDown(KeyCode.Return)){
					menuopne = 1;
					//GameState.candycount += 300;//テスト用.
				}
			}
			oldx = hitx;
			oldz = hitz;
		
		}
	}
	*/
}
