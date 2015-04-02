using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	private Vector3 moveDirection = Vector3.zero;
	private float speed = 1f;
	private float gravity = 20.0f;
	public float angle = 0f;
	private int colflag;
	//float ry = 0f;
	private float time = 0;
	private Vector3 vec;
	private CharacterController controller;
	public Vector3	pos = Vector3.zero;
	//float ry = 0.0f;
	//float ang;
	//static int stay = 0;

	// Use this for initialization
	void Start () {
		angle = this.transform.localEulerAngles.y;
		controller = (CharacterController)GetComponent("CharacterController");
		//GetComponentInChildren<PlayerMotion>().animator.SetBool("clear",false);
	}
	
	// Update is called once per frame
	void Update () {
		if(colflag == 0){
			colflag = GetComponentInChildren<PlayerForwardCollider>().colflag;
		}
		if(colflag == 0){
			colflag = GetComponentInChildren<PlayerBackCollider>().colflag;
		}
		/*
		 * テスト用.
		if(Input.GetKey (KeyCode.Return)){
			moveDirection = this.gameObject.transform.forward * -1 * 10;
			moveDirection.y = 0.5f;
			controller.Move(moveDirection*Time.deltaTime);
		}
		*/
		if(Pop.escselect == 0 && Pop.selectfanc == 0){//Pause.
			if(colflag == 0){
				Move ();
			}else{
				Shock();
			}
		}
		
		if(GameState.statusflag == 2){
			if(GameState.clearflag == 1){
				GetComponentInChildren<PlayerMotion>().animator.SetBool("clear",true);
			}
			Destroy(this);
		}
		
	}
	
	private void Move(){
		moveDirection = Vector3.zero;
		GetComponentInChildren<PlayerMotion>().animator.SetInteger("keyflag",TrapInstantiate.keyflag);
		if (controller.isGrounded) {
			if(Input.GetKey (KeyCode.W)){
				if(speed > 3){
					GetComponentInChildren<PlayerMotion>().animator.SetBool("walk",false);
					GetComponentInChildren<PlayerMotion>().animator.SetBool("run",true);
				}else{
					GetComponentInChildren<PlayerMotion>().animator.SetBool("run",false);
					GetComponentInChildren<PlayerMotion>().animator.SetBool("walk",true);
				}
				moveDirection = this.gameObject.transform.forward * speed;
			}else {
				GetComponentInChildren<PlayerMotion>().animator.SetBool("walk",false);
				GetComponentInChildren<PlayerMotion>().animator.SetBool("run",false);
			}
			if(Input.GetKey (KeyCode.S)){
				GetComponentInChildren<PlayerMotion>().animator.SetBool("walk",false);
				GetComponentInChildren<PlayerMotion>().animator.SetBool("run",false);
				GetComponentInChildren<PlayerMotion>().animator.SetBool("backwalk",true);
				moveDirection = this.gameObject.transform.forward * -1 * 3;
			}else{
				GetComponentInChildren<PlayerMotion>().animator.SetBool("backwalk",false);
			}
			if(Input.GetKey (KeyCode.A)){
				GetComponentInChildren<PlayerMotion>().animator.SetBool("walk",false);
				GetComponentInChildren<PlayerMotion>().animator.SetBool("run",false);
				GetComponentInChildren<PlayerMotion>().animator.SetBool("backwalk",false);
				moveDirection = this.gameObject.transform.right * -1 * 3;
				GetComponentInChildren<PlayerMotion>().animator.SetBool("left",true);
			}else{
				GetComponentInChildren<PlayerMotion>().animator.SetBool("left",false);
			}
			if(Input.GetKey (KeyCode.D)){
				moveDirection = this.gameObject.transform.right * 3;
				GetComponentInChildren<PlayerMotion>().animator.SetBool("walk",false);
				GetComponentInChildren<PlayerMotion>().animator.SetBool("run",false);
				GetComponentInChildren<PlayerMotion>().animator.SetBool("backwalk",false);
				GetComponentInChildren<PlayerMotion>().animator.SetBool("left",false);
				GetComponentInChildren<PlayerMotion>().animator.SetBool("right",true);
			}else{
				GetComponentInChildren<PlayerMotion>().animator.SetBool("right",false);
			}
			
		}
		
		
		//ダッシュ.
		if(Input.GetKey (KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
			speed = 6f;
		}else{
			speed = 3f;
		}
		
		//重力.
		moveDirection.y -= gravity * Time.deltaTime;
		
		//移動.
		controller.Move(moveDirection*Time.deltaTime);
		
		if(Input.GetKey (KeyCode.LeftArrow)){
				angle -= 100.0f * Time.deltaTime;
				//ry = Mathf.Cos(angle);
				this.gameObject.transform.rotation = Quaternion.Euler(this.transform.eulerAngles.x,angle,this.transform.eulerAngles.z);
		}else if(Input.GetKey (KeyCode.RightArrow)){
				angle += 100.0f * Time.deltaTime;
				//ry = Mathf.Cos(angle);
				this.gameObject.transform.rotation = Quaternion.Euler(this.transform.eulerAngles.x,angle,this.transform.eulerAngles.z);	
		}
		
		/*
		if(Input.GetKey (KeyCode.LeftArrow)){
			ry -= 1.0f;
			this.player.transform.rotation = Quaternion.Euler (0,ry,0);
		}else if(Input.GetKey (KeyCode.RightArrow)){
			ry += 1.0f;
			this.player.transform.rotation = Quaternion.Euler (0,ry,0);
		}
		*/
	}
	
	private void Shock(){
		if(colflag == 1){//後ろに転ぶ.
			if(time < 0.5f){
				GetComponentInChildren<PlayerMotion>().animator.SetBool("back",true);
				moveDirection = this.gameObject.transform.forward * -1 * 100 * Time.deltaTime;
				moveDirection.y = 0.01f;
				controller.Move(moveDirection*Time.deltaTime);
			}
		}else if(colflag == 2){//前に転ぶ.
			if(time < 0.5f){
				GetComponentInChildren<PlayerMotion>().animator.SetBool("forward",true);
				moveDirection = this.gameObject.transform.forward * 1 * 100 * Time.deltaTime;
				moveDirection.y = 0.01f;
				controller.Move(moveDirection*Time.deltaTime);
			}
		}
		
		time += Time.deltaTime;
		if(time > 1f){
			GetComponentInChildren<PlayerMotion>().animator.SetBool("forward",false);	
			GetComponentInChildren<PlayerMotion>().animator.SetBool("back",false);
			GetComponentInChildren<PlayerForwardCollider>().colflag = 0;
			GetComponentInChildren<PlayerBackCollider>().colflag = 0;
			colflag = 0;
			time = 0f;
		}
	}
}

