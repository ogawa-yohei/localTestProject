﻿using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
    public float speed;
    Player2D player;

	void Start () {
        player = GameObject.Find("Player2D").GetComponent<Player2D>();
	}
	
	void Update () {
        float dist = player.pos * speed;
        if (player.pos < 0f) dist += 32f;
        dist -= ((int)dist / 32) * 32;

        Vector3 pos = transform.position;
        transform.position = new Vector3(dist * -1, pos.y, pos.z);
	}
}
