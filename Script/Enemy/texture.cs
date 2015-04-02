using UnityEngine;
using System.Collections;

public class texture : MonoBehaviour {
	float max = 5;
	float min = 0;
	public Material[] bodytexture  = new Material[18]; 
	// Use this for initialization
	void Start () {
		int m = 5;
		if(GameState.enemylevel == 0){
			min = 0;
			max = 5;
		}else if(GameState.enemylevel == 1){
			min = 6;
			max = 11;
		}else if(GameState.enemylevel == 2){
			min = 12;
			max = 17;
		}
		m = (int)Mathf.Round(UnityEngine.Random.Range(min,max));
		this.renderer.material = bodytexture[m];
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
