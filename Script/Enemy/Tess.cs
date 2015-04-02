using UnityEngine;
using System.Collections;
using System;

public class Tess : MonoBehaviour {
	public float vpos = 1f;
	float time = 0;
	float HitPoint = 30;
	Vector3 y;
	int count = 0;
	int headshot;
	
	public GameObject smorke;
	private Vector3 slimePos;
	public float absx = 0f;
	public float absz = 0f;
	AudioSource audioSource;
	public AudioClip punchHit;
	public AudioClip pikohanHit;
	public AudioClip destroySE;
	// Use this for initialization
	void Start () {
		if(this.gameObject.tag == "Enemy1"){
			HitPoint = 5;
		}else if(this.gameObject.tag == "Enemy2"){
			HitPoint = 10;
		}else if(this.gameObject.tag == "Enemy3"){
			HitPoint = 80;
		}
		audioSource = gameObject.AddComponent<AudioSource>();
		HitPoint += GameState.enemylevel * 5;
		//HitPoint += 1000; //test
		//GameState.damagecount += 1000; //test
		slimePos = new Vector3(0,-1,0);
		audioSource.volume = 1f;
		//audioSource.maxDistance = 2;
	}
	
	// Update is called once per frame
	void Update () {
		//スライムを踏んでいる場合.
		absx = Math.Abs (slimePos.x - this.transform.position.x);
		absz = Math.Abs (slimePos.z - this.transform.position.z);
		if(absx <= 0.6f && absz <= 0.6f){
			GetComponentInChildren<EnemyMotion>().animator.SetBool("srime",true);
			vpos = 0.5f;
		}else{
			GetComponentInChildren<EnemyMotion>().animator.SetBool("srime",false);
			vpos = 1f;
		}
		
		if(HitPoint <= 0){
			count++;
			if(count <= 1){
				//audioSource.clip = destroySE;
				audioSource.PlayOneShot(destroySE);
				smorke.transform.position = this.transform.position;
				Instantiate(smorke);
				GetComponentInChildren<EnemyMotion>().Clear();//見えなくなる.
				GameState.maxEnemy--;
				GameState.candycount += 2;
			}
			time += Time.deltaTime;
			if(time > 1){
				GameState.destroycount++;
				if(this.gameObject.tag == "Enemy3"){
					GameState.clearflag = 1;
					GameState.statusflag = 2;
				}
				Destroy(this.gameObject);
			}
		}
	}
	
	
	private void OnCollisionEnter(Collision co)
	{
		if(co.gameObject.tag == "Goal"){
			GameState.maxEnemy--;
			GameState.destroycount++;
			GameState.damagecount--;
			if(this.gameObject.tag == "Enemy3"){
				GameState.damagecount = 0;
			}
			Destroy(this.gameObject);
		}else if(co.gameObject.tag == "Ceiling" || co.gameObject.tag == "lowCeiling"){
			if(this.gameObject.tag != "Enemy3"){
				HitPoint -= 5;
			}
		}
		//スプリング.
		if(co.gameObject.tag == "Spring"){
			if(this.gameObject.tag != "Enemy3"){
				GetComponentInChildren<EnemyMotion>().animator.SetBool("spring",true);
				GetComponent<EnemyControl>().shockflag = 6;
			}
		}
	}
	
	private void OnTriggerEnter(Collider c){
		//風船.
		if(c.gameObject.tag == "Trap5"){
			HitPoint -= 2;
		//パンチングウォール.
		}else if(c.gameObject.tag == "Trap6"){
			HitPoint -= 5;
			//audioSource.clip = punchHit;
			//audioSource.PlayOneShot( punchHit );鳴らないからアイテム側から鳴らす.
		//ピコハン.
		}else if(c.gameObject.tag == "Trap7"){
			HitPoint -= 10;
			//audioSource.clip = pikohanHit;
			audioSource.PlayOneShot( pikohanHit );
		//タライ(大).
		}else if(c.gameObject.tag == "TaraiL"){
			vpos = 0f;
			HitPoint -= 15;
			if(this.gameObject.tag == "Enemy3"){
				GetComponent<EnemyControl>().shockflag = 5;
			}else{
				GetComponent<EnemyControl>().shockflag = 4;
			}
		}
		//スライム.
		if(c.gameObject.tag == "Trap2"){
			GetComponentInChildren<EnemyMotion>().animator.SetBool("srime",true);
			slimePos = c.gameObject.transform.position;
		}
		//ドア.
		if(c.gameObject.tag == "Door1" || c.gameObject.tag == "Door2"|| c.gameObject.tag == "Door3"){
			if(this.gameObject.tag != "Enemy3"){
			count++;
			if(count <= 1){
				GameState.destroycount++;
			}
			Destroy (this.gameObject);
			}
		}
	}
}
