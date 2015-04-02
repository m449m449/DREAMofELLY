using UnityEngine;
using System.Collections;

public class CursorFalse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;//カーソルを画面内に維持.

		Screen.showCursor = false; // マウスカーソル非表示.
	}
	
	// Update is called once per frame
	void Update () {
		if(GameState.statusflag == 2 || Pop.escselect != 0 || Pop.selectfanc != 0){
			Screen.showCursor = true; // マウスカーソル表示.
			Screen.lockCursor = false;
		}else{
			Screen.lockCursor = true;
			Screen.showCursor = false; // マウスカーソル非表示.
		}
	}
}
