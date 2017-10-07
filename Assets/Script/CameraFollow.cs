using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject Player;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 playerPosiiton = Player.transform.position;
        gameObject.transform.position = new Vector3(0, playerPosiiton.y, gameObject.transform.position.z);
	}
}
