using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float offset = 10f;      // сдвиг камеры от игрока.
    public Transform target;        // сам игрок.
	
	// Update is called once per frame
	void Update () {
        // всегда смотрим на игрока.
        transform.LookAt(target);

        // тут всё изи.
        Vector3 targetPosition = target.position;
        transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z - offset);
        
	}
}
