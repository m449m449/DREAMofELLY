using UnityEngine;
using System.Collections;

public class Root : MonoBehaviour {
    //侵攻ルート用共通空配列(各エネミーの侵攻ルートはEnemyControlで決定)
	public Transform[] root = new Transform[300];
}
