using UnityEngine;
using System.Collections;

public class EnemyMotion : MonoBehaviour {
	public Animator animator;
	private int flag;
	private int hanabiflag;
	private float time;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(hanabiflag == 1){
			time += Time.deltaTime;
			if(time > 0.5){
				animator.SetBool("hanabi",false);
				//animator.SetBool("rightHit",false);
				//animator.SetBool("leftHit",false);
				hanabiflag = 0;
				time = 0;
			}
		}
	}
	
	public void Hanabi(){
		if(hanabiflag == 0){
			time = 0;
			hanabiflag = 1;
			animator.SetBool("hanabi",true);
		}
	}
	
	public void Clear(){
		//this.gameObject.layer = 15;
		MoveToLayer(this.transform , 15);
	}
	//子のレイヤーもまとめて変更.
	void MoveToLayer(Transform root, int layer) {
    	root.gameObject.layer = layer;
    	foreach(Transform child in root)
        	MoveToLayer(child, layer);
	}
}
