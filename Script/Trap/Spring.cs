using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour {
	float cooltime = 0f;
	int turn = 0;
	public int triflag = 0;
	public int setrriger = 0;
	public GameObject spring;
	Vector3 pos;
	Vector3 springpos;
	AudioSource audioSource;
	//int layerMask = 1 << 8;
	
	// Use this for initialization
	void Start () {
		this.spring = this.transform.FindChild("Springbody").gameObject;
		springpos = this.spring.transform.position;
		pos = this.spring.transform.position;
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(triflag == 1){
			Trriger ();
		}
		
	}
	
	public void Trriger(){
		if(setrriger == 0){
			GetComponentInChildren<EnemyMotion>().animator.SetBool("spring",true);
			audioSource.PlayOneShot( audioSource.clip );
			setrriger = 1;
			spring.gameObject.SetActive(true);
		}
		if(cooltime == 0){
			if(spring.transform.position.y < 1.5f){
				pos.y += Time.deltaTime * 5;
				this.spring.transform.position = pos;
			}else if(spring.transform.position.y >= 1.5f){
				GetComponentInChildren<EnemyMotion>().animator.SetBool("spring",false);
				this.spring.transform.position = springpos;
				pos = this.spring.transform.position;
				turn = 1;
				spring.gameObject.SetActive(false);
			}
		}
		if(turn == 1){
			cooltime += Time.deltaTime;
		}
		
		if(cooltime > 10){
			triflag = 0;
			turn = 0;
			cooltime = 0;
			setrriger = 0;
		}
	}
	private void OnTriggerEnter(Collider c){
		if(c.gameObject.tag == "Enemy1" ||c.gameObject.tag == "Enemy2"){
			triflag = 1;
		}
	}
}
