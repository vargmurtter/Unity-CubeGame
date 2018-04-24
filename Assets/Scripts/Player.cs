using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = 5f;        // скорость игрока.

    private bool canMove = true;                // можем ли мы двигаться?

    private void Update()
    {
        // если можем двигаться, то двигаемся (как бы очевидно это не было).
        if (canMove) {
            float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

            transform.Translate(new Vector3(moveX, 0, moveZ), Space.World);
        }
    }

    private void OnTriggerEnter(Collider col) 
    {
        // если мы упали, то запрещаем двигаться.
        if (col.gameObject.tag == "Drop")
        {
            canMove = false;
        }
    }

}
