using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = 5f;                    // скорость игрока.

    private bool canMove = true;                    // можем ли мы двигаться?
    private Vector3 spawnPoint = Vector3.zero;      // сюда сохраняем последний чекпоинт.
    private Rigidbody rb;                           // rigidbody.

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPoint = transform.position;
    }

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

        // чекпоинт.
        if (col.gameObject.tag == "CheckPoint")
        {
            spawnPoint = transform.position;
        }

        // упали.
        if (col.gameObject.tag == "Die")
        {
            RespawnPlayer();
        }

    }

    // респавн игрока.
    private void RespawnPlayer()
    {
        canMove = true;
        rb.velocity = Vector3.zero;
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        transform.position = spawnPoint;
    }

}
