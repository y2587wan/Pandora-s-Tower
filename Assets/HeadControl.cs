using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadControl : MonoBehaviour {

    public GameObject PlayerBody;
	// Update is called once per frame
	void Update () {
        transform.position = PlayerBody.transform.position;
	}
}
