using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour {

    public GameObject seguir;
    public Vector2 MinCamPos, MaxCamPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float posx = seguir.transform.position.x;

        float posy = seguir.transform.position.y;

        transform.position = new Vector3(Mathf.Clamp(posx, MinCamPos.x,MaxCamPos.x), Mathf.Clamp(posy,MinCamPos.y,MaxCamPos.y), transform.position.z);

		
	}
}
