using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHider : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        // ну изи же.
        if (collision.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
        }
    }

}
