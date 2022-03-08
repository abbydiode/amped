using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float VerticalOffset = 2;
    Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate() {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + VerticalOffset, transform.position.z);
    }
}
