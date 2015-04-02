using UnityEngine;
using System.Collections;

public class BoxDamage : MonoBehaviour {
	float time;
	int oldHP;
	public GameObject box1,box2,box3;
	AudioSource audioSource;
	public AudioClip boxHit;
	// Use this for initialization
	void Start () {
		time = 3;
		oldHP  = GameState.damagecount;
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameState.damagecount > 10){
			box1.SetActive(true);
			box2.SetActive(false);
			box3.SetActive(false);
		}else{
			box1.SetActive(false);
			box2.SetActive(true);
			box3.SetActive(false);
		}
		if(GameState.damagecount == 0){
			box1.SetActive(false);
			box2.SetActive(false);
			box3.SetActive(true);
		}
		if(time < 2){
			time += Time.deltaTime;
		}
		if(time > 0.5f){
			GetComponentInChildren<EnemyMotion>().animator.SetBool("damage",false);
		}
		if(oldHP != GameState.damagecount){
			GetComponentInChildren<EnemyMotion>().animator.SetBool("damage",true);
			//audioSource.clip = boxHit;
			audioSource.PlayOneShot( boxHit );
			time = 0;
		}
		oldHP = GameState.damagecount;
	}
}
