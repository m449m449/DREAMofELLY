using UnityEngine;
using System.Collections;
using System;

public class PlaneTrapCollision : MonoBehaviour {
	public  GameObject settyakuzai,hole;
	private GameObject slimePos,springPos;
	public  GameObject player;
	Vector3 PTpos;
	public int scount,hcount;
	public float fx,fz,ry,py;
	public static float efx,efz,ery;
	private Vector3 defaultposition;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		defaultposition = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
		Delete ();
		Position ();
		Instant();
		
		if(GameState.mouse != 0 || TrapInstantiate.keyflag == 1){
			this.transform.localPosition = defaultposition;
		}
		
	}
	private void Delete(){
		//オブジェクトデリート.
		if(scount == 1){
			if(TrapInstantiate.keyflag != 2){
				Destroy (GameObject.Find("pTrap(Clone)"));
				scount = 0;
			}
		}
		if(hcount == 1){
			if(TrapInstantiate.keyflag != 3){
				Destroy (GameObject.Find("pHole(Clone)"));
				hcount = 0;
			}
		}
	}
	
	private void Position(){
		double dx = 0;
		double dz = 0;
		PTpos = transform.position;
		dx = Math.Round(PTpos.x,1);
		dz = Math.Round(PTpos.z,1);
		dx -= Math.Floor(PTpos.x);
		dz -= Math.Floor(PTpos.z);
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
		//角度を調整.
		py = player.transform.localEulerAngles.y;
		if(45f <= py && py < 135f){
			ry = 180f;
		}else if(225f <= py && py < 315f){
			ry = 0f;
		}
		if(135f <= py && py  < 225f){
			ry = -90f;
		}else if((315f<= py && py <= 360f) || (0f <= py && py < 45f)){
			ry = 90f;
		}
		dx += Math.Floor (PTpos.x);
		dz += Math.Floor (PTpos.z);
		fx = (float)dx;
		fz = (float)dz;
	}
	
	private void Instant(){
		if(TrapInstantiate.keyflag == 2){
			if(scount == 0){
				Instantiate (settyakuzai,new Vector3(fx,0.5f,fz),Quaternion.Euler(0, ry, 0));
				scount = 1;
				slimePos = GameObject.Find ("pTrap(Clone)");
			}
			if(scount == 1){
				slimePos.transform.position = new Vector3(fx,0.5f,fz);
				slimePos.transform.eulerAngles = new Vector3(0, ry, 0);
				efx = fx;
				efz = fz;
				ery = ry;
			}
		}else if(TrapInstantiate.keyflag == 3){
			if(hcount == 0){
				Instantiate (hole,new Vector3(fx,0.5f,fz),Quaternion.Euler(0, ry, 0));
				hcount = 1;
				springPos = GameObject.Find("pHole(Clone)");
			}
			if(hcount == 1){
				springPos.transform.position = new Vector3(fx,0.5f,fz);
				springPos.transform.eulerAngles = new Vector3(0, ry, 0);
				efx = fx;
				efz = fz;
				ery = ry;
			}
		}
	}
}
