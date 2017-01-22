﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    Ray ray;
    RaycastHit hit;
    public LayerMask floorMask;
	public float height = 1.7f;

    // Update is called once per frame
    void Update ()
    {
		if (Networking.Instance.PlayerType == 1) {
			//TELEPORT 
			if (Input.GetMouseButtonDown (0)) {
				if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f, floorMask)) {
					if (VoiceLightShader2.Instance.isThisPositionOk (hit.point))
						this.transform.position = new Vector3 (hit.point.x, hit.point.y + this.height, hit.point.z);

					VoiceLightShader2.Instance.SpawnVoid (Vector3.down);
				}
			}

			//Debug.DrawLine (this.transform.position, this.transform.position + Vector3.down * 10);
			//FORZO ALTEZZA
			if (Physics.Raycast (this.transform.position, Vector3.down, out hit, 10f, floorMask)) {
				//Debug.DrawLine(this.transform.position, hit.point, Color.green);
				this.transform.position = new Vector3 (this.transform.position.x, hit.point.y + height, this.transform.position.z);
			}
		} else {

			//Refresh position dal cazzo di server, fuck!

		}
    }
}