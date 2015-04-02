using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {
	private float time = 0;
	private int tri = 0;
	AudioSource audioSource;
	public AudioClip huusenHit;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.maxDistance = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(time <= 2f){
		time += Time.deltaTime;
		if(time > 1f){
			this.gameObject.tag = "Trap5";
				tri = 1;
		}
		}
		
	}
	private void OnTriggerStay(Collider c){
		
		if(c.gameObject.tag == "Player" || c.gameObject.tag == "Decoy1" || c.gameObject.tag == "withTrap"
			 ){
		}else{
			if(tri == 1){
				Destroy (this.gameObject,0.5f);
				this.collider.enabled = false;
				audioSource.clip = huusenHit;
				audioSource.PlayOneShot( huusenHit );
				//モデル消す;
				GetComponentInChildren<EnemyMotion>().Clear();
			}
		}
	}
}
