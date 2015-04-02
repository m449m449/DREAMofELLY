using UnityEngine;
using System.Collections;

public class StopCamera : MonoBehaviour {

	// プレイヤー.
	private GameObject	player = null;
	private GameObject	pcamera = null;
	private GameObject	Mcamera = null;

	public Vector3		offset;
	public static Vector3		pos;
	public static float angle = 0.0f;
	public static float upflag = 0f;
	float r = -1.5f;
	//float rx = 0.0f;
	// Use this for initialization
	void Start () {

		// プレイヤーのインスタンスを探しておく.
		this.player = GameObject.FindGameObjectWithTag("Player");
		this.pcamera = GameObject.FindGameObjectWithTag("Pcamera");
		this.Mcamera = GameObject.FindGameObjectWithTag("MainCamera");
		this.Mcamera.transform.eulerAngles = new Vector3 (Mcamera.transform.localEulerAngles.x,Mcamera.transform.localEulerAngles.y,Mcamera.transform.localEulerAngles.z);
		offset = Mcamera.transform.position - player.transform.position;
		//offset = -2.0f;
		pos.y = 1.0f;
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		// カメラをtargetの方向へ向かせるように設定する.
		Mcamera.transform.LookAt(this.pcamera.transform.position);	
		/*
		//矢印キーで回転.
		//if(upflag == 0){
			if(Input.GetKey (KeyCode.LeftArrow)){
				angle += 1.0f * Time.deltaTime;
				Mcamera.transform.position = new Vector3(player.transform.position.x + Mathf.Cos(angle) * r, Mcamera.transform.position.y, player.transform.position.z + Mathf.Sin(angle) * r);
			}else if(Input.GetKey (KeyCode.RightArrow)){
				angle -= 1.0f * Time.deltaTime;
				Mcamera.transform.position = new Vector3(player.transform.position.x + Mathf.Cos(angle) * r, Mcamera.transform.position.y, player.transform.position.z + Mathf.Sin(angle) * r);
			}
		//}
		
		//カメラ視点の上下.
		if(Input.GetKey (KeyCode.UpArrow)){
			//upflag += 1f;
			if(pos.y < 5.0f){
				pos.y += 3.0f * Time.deltaTime;
			}
		}else if(Input.GetKey (KeyCode.DownArrow)){
			if(pos.y > 0.0f){
				pos.y -= 3.0f * Time.deltaTime;
			}
		}
		*/
			
			this.pcamera.transform.localPosition = pos;
		// プレイヤーと一緒に移動.
			Mcamera.transform.position = new Vector3(player.transform.position.x + Mathf.Cos(angle) * r, player.transform.position.y + offset.y, player.transform.position.z + Mathf.Sin(angle) * r);
		
		//上下の向き.
		/*
		if(upflag > 1f){
			upflag = 1f;
		}else if(upflag < -1f){
			upflag = -1f;
		}
		if(upflag == 1f){
			if(pos.y < 2.0f){
				pos.y += 0.1f;
				this.pcamera.transform.localPosition = pos;
			}
		}else if(upflag == 0f){
			if(pos.y < 1.0f){
				pos.y += 0.1f;
				this.pcamera.transform.localPosition = pos;
			}else if(pos.y > 1.0f){
				pos.y -= 0.1f;
				this.pcamera.transform.localPosition = pos;
			}
		}else if(upflag == -1f){
			if(pos.y > 0.0f){
				pos.y -= 0.1f;
				this.pcamera.transform.localPosition = pos;
			}
		}
		*/
		
	}
}
