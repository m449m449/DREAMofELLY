using UnityEngine;
using System.Collections;

public class Recovery : MonoBehaviour {
	public GameObject parent;
	float time;
	private int cflag;
	public Material defaultcolor;
	public Material selectcolor;
	// Use this for initialization
	void Start () {
		//defaultcolor = parent.gameObject.renderer.material.color;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameState.statusflag == 0){//休憩タイムなら.
			if(cflag == 1){
				Pop.recoveryflag = 1;
				//parent.gameObject.renderer.material = selectcolor;
				if(Input.GetKeyDown(KeyCode.E)|| Input.GetMouseButtonUp(1)){
					Pop.recoveryflag = 0;
					if(parent.gameObject.tag == "Trap2"){
						GameState.candycount += 3;
					}else if(parent.gameObject.tag == "withSpring"){
						GameState.candycount += 8;
					}else if(parent.gameObject.tag == "withPunch"){
						GameState.candycount += 8;
					}else if(parent.gameObject.tag == "Trap7"){
						GameState.candycount += 15;
					}else if(parent.gameObject.tag == "TaraiL"){
						GameState.candycount += 15;
					}
					Destroy(parent);
				}
				time += Time.deltaTime;
				if(time > 0.1f){
					cflag = 0;
					time = 0;
					parent = null;
				}
			}else{
				Pop.recoveryflag = 0;
				//オブジェクト参照がオウブジェクトインスタンスに設定されていません.
				//parent.renderer.material.color = defaultcolor;
			}
		}else{
			Pop.recoveryflag = 0;
		}
	}
	
	private void OnTriggerStay(Collider c){
		if(c.gameObject.tag == "Nucleus"){
			parent = c.transform.parent.gameObject;
			time = 0;
			cflag = 1;
		}
	}
}
