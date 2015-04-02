using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	private float incZ;
	public int esc;
	public int clear;
	public int door;
	public int title;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	/*
	void Update () {
	
	}
	*/
	
	void OnMouseEnter(){
		//Debug.Log (select1.a);
		if(Pop.escselect != 0){
			Pop.escselect = esc;
		}
		if(Pop.clearselect != 0){
			Pop.clearselect = clear;
		}
		if(Pop.selectfanc != 0){
			Pop.selectflag = door;
		}
		if(Application.loadedLevelName == "Title"){
			select1.a = title;
		}
		/*
		Rect tmp  = gameObject.guiTexture.pixelInset;
		Vector3 position = transform.position;
		position.z = 0.01f;
		*/
	}
	
	void OnMouseExit(){
		if(Application.loadedLevelName == "Title"){
			select1.a = 4;
		}
		if(Pop.selectfanc != 0){
			Pop.selectflag = 0;
		}
	}
}
