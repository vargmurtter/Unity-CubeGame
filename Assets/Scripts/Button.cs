using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public Transform mapParent;             // родитель карты.
    public GameObject simplePlatform;       // префаб обычной платформы.
    public GameObject[] platforms;          // список ловушек, которые нужно заменить.

    // проверяем косание.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ButtonPressed();
            ReplaceTrapToPlatform();
        }
    }

    // заменяем.
    void ReplaceTrapToPlatform()
    {
        foreach (GameObject go in platforms)
        {
            Vector3 platformPos = go.transform.position;
            GameObject newGO = Instantiate(simplePlatform, mapParent);
            newGO.transform.position = platformPos;
            Destroy(go);
        }
    }

    // нажимаем на кнопку (кубик).
    void ButtonPressed()
    {
        Vector3 buttonPos = gameObject.transform.position;
        buttonPos.y = 0f;
        gameObject.transform.position = buttonPos;
    }

}
