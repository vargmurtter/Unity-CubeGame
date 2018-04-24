using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// sorry for my f**king english...
public class UnvisiblePlatform : MonoBehaviour {

    MeshRenderer mr;

    private void Start()
    {
        // при старте игры, делаем объект невидимым.
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // при коллизии с игроком, делаем объект видимым.
        if (collision.gameObject.name == "Player")
        {
            mr.enabled = true;
        }
    }
}
