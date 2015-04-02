using UnityEngine;
using System.Collections;

public class TaraiL : MonoBehaviour {
	int triflag = 0;
	int colfalg = 0;
	int turnflag = 0;
	int hitflag = 0;
	float time = 0;
	float cooltime = 0f;
	float collisiontime;
	Vector3 startpos;
	Vector3 y;
	GameObject range;
	
	AudioSource audioSource;
	public AudioClip taraiHit;
	// Use this for initialization
	void Start () {
		//gameObject.AddComponent<Rigidbody>();
		startpos = this.transform.position;
		y = startpos;
		
		this.range = this.transform.FindChild("Range").gameObject;
		
		audioSource = gameObject.AddComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		triflag = GetComponentInChildren<TrapTrigger>().triflag;
		if(triflag == 1){
			Trriger();
		}else{
			this.transform.position = startpos;
		}
		if(hitflag > 0){
			Motion ();
		}
		
		if(GameState.statusflag != 0){
			Destroy(range);
		}
	}
	
	public void Trriger(){
		if(turnflag == 0){
			
		}else if(turnflag == 1){
			if(this.transform.position.y < 2.4f){
				y.y = this.transform.position.y + (1f * Time.deltaTime);
				this.transform.position = y;
			}else{
				turnflag = 0;
			}
		}
		if(colfalg == 0){
			y.y = this.transform.position.y - (5 * Time.deltaTime);
			this.transform.position = y;
		}else{
			cooltime += Time.deltaTime;
		}
		if(cooltime > 1.5f){
			gameObject.rigidbody.velocity = new Vector3(0f,0f,0f);
			turnflag = 1;
		}
		if(cooltime > 25){
			if(this.transform.position.y < startpos.y){
				y.y = this.transform.position.y + (0.25f * Time.deltaTime);
				this.transform.position = y;
			}else{
				GetComponentInChildren<TrapTrigger>().triflag = 0;
				cooltime = 0;
				colfalg = 0;
			}
		}
	}
	private void Motion(){
		GetComponentInChildren<EnemyMotion>().animator.SetBool("hit",true);
		hitflag = 2;
		if(hitflag == 2){
			time += Time.deltaTime;
			if(time > 1){
				GetComponentInChildren<EnemyMotion>().animator.SetBool("hit",false);
				time = 0;
				hitflag = 0;
			}
		}
	}
	private void OnTriggerEnter(Collider c){
		if(c.gameObject.tag == "Enemy1" ||c.gameObject.tag == "Enemy2" || c.gameObject.tag == "Enemy3"|| c.gameObject.tag == "Floor"){
			audioSource.clip = taraiHit;
			audioSource.PlayOneShot(taraiHit);
			time = 0;
			hitflag = 1;
			gameObject.rigidbody.velocity = new Vector3(0f,0.1f,0f);
			colfalg = 1;
		}
	}
}
