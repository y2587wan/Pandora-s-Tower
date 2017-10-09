using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour {

    public GameObject[] players;

    private float highestPoint;

	void Update () {
        if (players.Length > 1)
        {
            highestPoint = Math.Max(players[0].transform.position.y, players[1].transform.position.y);
        }
        else
        {
            highestPoint = players[0].transform.position.y;
        }
        gameObject.transform.position = new Vector3(0, highestPoint, gameObject.transform.position.z);
	}
}
