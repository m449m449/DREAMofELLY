using UnityEngine;
using System.Collections;
using System;

public class CeilingTrapCollision : MonoBehaviour {
	public  GameObject huriko;
	public  GameObject pikohanPos,taraiPos;
	public  GameObject bigtarai;
	public  GameObject player;
	public static Vector3 CTpos,Ppos;
	public float fx,fz,ry,py;
	public static float efx,efy,efz,ery;
	public float oldfx,oldfz;
	public int hcount,scount,lcount;
	public int keyflag = 0;
	public int possible;
	private Vector3 defaultposition;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		keyflag = TrapInstantiate.keyflag;
		defaultposition = this.transform.localPosition;
	}
		
	// Update is called once per frame
	void Update () {
		if(GameState.mouse != 0 || TrapInstantiate.keyflag == 1){
			this.transform.localPosition = defaultposition;
		}
		possible = TrapInstantiate.possible;//設置できるかどうか.
		Delete();
	}
	
	void Delete(){
		if(hcount == 1){
			if(TrapInstantiate.keyflag != 5){
				Destroy (GameObject.Find("pTrap7(Clone)"));
				hcount = 0;
			}
			//設置不可なら見えなくする.
			if(possible == 0){
				//子もfalseしないといけない.めんどくさい.モデルあがってからでいい.
				//GameObject.Find("pTrap7(Clone)").renderer.enabled = false;
			}else{
				//GameObject.Find("pTrap7(Clone)").renderer.enabled = true;
			}
		}
		if(lcount == 1){
			if(TrapInstantiate.keyflag != 6){
				Destroy (GameObject.Find("pTaraiL(Clone)"));
				lcount = 0;
			}
			//設置不可なら見えなくする.
			if(TrapInstantiate.possible == 0){
				//GameObject.Find("pTaraiL(Clone)").renderer.enabled = false;
			}else{
				//GameObject.Find("pTaraiL(Clone)").renderer.enabled = true;
			}
		}
	}
	private void Position(){
		double dx = 0;
		double dz = 0;
		CTpos.x = transform.position.x;
		CTpos.z = transform.position.z;
		Ppos = player.transform.position;
		dx = Math.Round(CTpos.x,1);
		dz = Math.Round(CTpos.z,1);
		dx -= Math.Floor(CTpos.x);
		dz -= Math.Floor(CTpos.z);
		//0.5刻みの座標を取得.
		if(dx < 0.5d){
			dx = 0.0d;
		}else{
			dx = 0.5d;
		}
		if(dz < 0.5d){
			dz = 0.0d;
		}else{
			dz = 0.5d;
		}
		dx += Math.Floor (CTpos.x);
		dz += Math.Floor (CTpos.z);
		
		//角度を調整.
		py = player.transform.localEulerAngles.y;
		if(45f <= py && py < 135f){
			ry = 90f;
		}else if(225f <= py && py < 315f){
			ry = -90f;
		}
		if(135f <= py && py  < 225f){
			ry = 0f;
		}else if((315f<= py && py <= 360f) || (0f <= py && py < 45f)){
			ry = 180f;
		}
		fx = (float)dx;
		fz = (float)dz;
	}
	
	
	private void OnTriggerStay(Collider c){
		if(c.gameObject.tag == "Ceiling" || c.gameObject.tag == "lowCeiling"){
			Position ();
			CTpos.y = c.transform.position.y;//y座標.
			if(TrapInstantiate.keyflag == 5){
				if( c.gameObject.tag == "lowCeiling" || c.gameObject.tag == "Ceiling"){
					if(hcount == 0){
						Instantiate (huriko,new Vector3(fx,CTpos.y -0.5f,fz),Quaternion.Euler(0, ry, 0));
						hcount = 1;
						pikohanPos = GameObject.Find("pTrap7(Clone)");
					}
					if(hcount == 1){
						pikohanPos.transform.position = new Vector3(fx,CTpos.y -0.5f,fz);
						pikohanPos.transform.eulerAngles = new Vector3(0,ry,0);
						efx = fx;
						efz =fz;
						efy = CTpos.y -0.5f;
						ery = ry;
					}
				}else{
					efx = 0.1f;
				}
			}
			
			if(TrapInstantiate.keyflag == 6){
				if(c.gameObject.tag == "Ceiling"){
					if(lcount == 0){
						Instantiate (bigtarai,new Vector3(fx,CTpos.y -0.5f,fz),Quaternion.Euler(0, ry, 0));
						lcount = 1;
						taraiPos = GameObject.Find("pTaraiL(Clone)");
					}
					if(lcount == 1){
						taraiPos.transform.position = new Vector3(fx,CTpos.y -0.5f,fz);
						taraiPos.transform.eulerAngles = new Vector3(0,ry,0);
						efx = fx;
						efz =fz;
						efy = CTpos.y -0.5f;
						ery = ry;
					}
				}
			}
		}
	}
}
