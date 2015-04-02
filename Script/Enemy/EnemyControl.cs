using UnityEngine;
using System.Collections;
using System;

public class EnemyControl : MonoBehaviour {
	
	
	public Vector3 nextpos;
	float speed = 0.0f;
	int adflag;
	int count;
	public int n = 0;
	public int shockflag = 0;
	public float absx = 0f;
	public float absz = 0f;
	public float time = 0f;
	public int num = 20;
	public Transform[] point = new Transform[300];
	public Vector3 vec;
	public Vector3 rot;
	public Vector3 pos;
	// Use this for initialization
	void Start () {
		for(int i = 0;i < 300;i++){
			point[i] = GetComponent<Root>().root[i];
		}
		pos = this.transform.position;
		for(int i = 0;i < 300; i += 20){
			if(pos == point[i].position){
				n = i;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Pop.escselect == 0){//Pause.
			if(shockflag == 0){
				shockflag = GetComponentInChildren<RightCollision>().colflag;
			}
			if(shockflag == 0){
				shockflag = GetComponentInChildren<LeftCollision>().colflag;
			}
			if(shockflag != 0){
				Shock ();
			}else{
				Move ();
			}
			//this.transform.position = pos;
		}
	}
	
	public void Move(){
		
		speed = GetComponent<Tess>().vpos * Time.deltaTime;

		//侵攻ルート.	
		nextpos = point[n].position;
		nextpos.y = this.transform.position.y;
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(nextpos - this.transform.position), 8 * speed);
		this.transform.position += this.transform.forward * speed * 1f;
		absx = Math.Abs (nextpos.x - this.transform.position.x);
		absz = Math.Abs (nextpos.z - this.transform.position.z);
		if(absx <= 0.5f && absz <= 0.5f){
			n++;
		}
		
		/*
		ry = 0
		if(ry < 180.0f){
			ry += 10.0f * Time.deltaTime;
			y = ry
			this.transform.rotation = Quaternion.Euler (0,y,0);
		}
		*/
	}
	
	public void Shock(){
		//左に吹き飛ぶ.
		if(shockflag == 1){
			//一度だけ読み込む.
			if(time == 0f){
				if(this.gameObject.tag == "Enemy3"){
					vec = transform.right * 2;
				}else{
					vec = transform.right * 4;
					vec.y = 2f;
				}
				gameObject.rigidbody.velocity = vec;
				GetComponentInChildren<EnemyMotion>().animator.SetBool("leftHit",true);
				//25度傾ける.
				//rot = transform.right * -25;
				//rot = new Vector3(rot.x, this.gameObject.transform.eulerAngles.y,rot.z);
				//this.gameObject.transform.rotation = Quaternion.Euler(rot);
			}
		//右に吹き飛ぶ.
		}else if(shockflag == 2){
			//一度だけ読み込む.
			if(time == 0f){
				vec = transform.right * -4;
				vec.y = 2f;
				gameObject.rigidbody.velocity = vec;
				GetComponentInChildren<EnemyMotion>().animator.SetBool("rightHit",true);
				//25度傾ける.
				//rot = transform.right * 25;
				//rot = new Vector3(rot.x, this.gameObject.transform.eulerAngles.y,rot.z);
				//this.gameObject.transform.rotation = Quaternion.Euler(rot);
			}
		//ちょっと後ろに飛ぶ.
		}else if(shockflag == 3){
			vec = transform.forward * -2;
			vec.y = 3f;
			gameObject.rigidbody.velocity = vec;
			shockflag = 0;
			GetComponentInChildren<EnemyMotion>().Hanabi ();
		//タライ.
		}else if(shockflag == 4){
			GetComponentInChildren<EnemyMotion>().animator.SetBool("taraiS",true);
		}else if(shockflag == 5){
			GetComponentInChildren<EnemyMotion>().animator.SetBool("taraiS",true);
		//バネ.
		}else if(shockflag == 6){
			if(count == 0){
				count++;
				vec = new Vector3(0,4,0);
			}
			gameObject.rigidbody.velocity = vec;
		}
		
		time += Time.deltaTime;
		if(time > 2f){
			count = 0;
			GetComponentInChildren<RightCollision>().colflag = 0;
			GetComponentInChildren<LeftCollision>().colflag = 0;
			switch (shockflag){
			case 1:
				GetComponentInChildren<EnemyMotion>().animator.SetBool("leftHit",false);
				break;
			case 2:
				GetComponentInChildren<EnemyMotion>().animator.SetBool("rightHit",false);
				break;
			case 4:
				GetComponentInChildren<EnemyMotion>().animator.SetBool("taraiS",false);
				break;
			case 5:
				GetComponentInChildren<EnemyMotion>().animator.SetBool("taraiS",false);
				break;
			case 6:
				GetComponentInChildren<EnemyMotion>().animator.SetBool("spring",false);
				break;
			}
			shockflag = 0;
			time = 0f;
		}
		
	}
	
	private void OnTriggerEnter(Collider c){
		if(c.gameObject.tag == "Trap5"){
			shockflag = 3;
		}
		
	}
}
