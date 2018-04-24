using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCube : MonoBehaviour {

    public Material triggerMaterial;            // материал, на который среагирует замена*.
    public Material[] materials;                // список материалов, которые будут менять кубики.

    public Transform mapParent;                 // родительский объект, содержащий карту.

    public GameObject simplePlatform;           // префаб обычной платформы.
    public GameObject[] platforms;              // какие ловушки заменить на платформы.

    private static int count = 0;               // подсчёт кол-ва активироанных кубиков.

    private int index = 0;                      // текущий идекс материала.

    private Renderer rend;                      // компонент Renderer

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        // если все кубики активированы, заменяем* ловушки на платформы.
        if (count == 3)     // костыль...
        {
            ReplaceTrapToPlatform();
            count = 0;      // тоже костыль...
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ChangeColor(collision);
    }

    // меняем материал кубика.
    void ChangeColor(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // чтобы не словить исключение IndexOutOfRange**.
            if (index < materials.Length)
            {
                // если цвет материала не тот, который нужен, продолжаем менять цвет.
                if (rend.material.color != triggerMaterial.color)
                {
                    // применяем материал к кубику.
                    rend.material = materials[index];
                    index++;

                    // если выбран нужный цвет, то...
                    if (rend.material.color == triggerMaterial.color)
                    {
                        // ...сдвигаем кубик вниз...
                        Vector3 pos = transform.position;
                        pos.y = 0.0f;
                        transform.position = pos;

                        // ...и считаем количество активированных кубиков.
                        count++;
                    }
                }
            }
            else
            {   
                // ...обнуляем**.
                index = 0;
            }
        }
    }

    // замена* ловушек на обычные платформы.
    void ReplaceTrapToPlatform()
    {
        // лень писать, сами разберётесь...
        foreach (GameObject go in platforms)
        {
            Vector3 platformPos = go.transform.position;
            GameObject newGO = Instantiate(simplePlatform, mapParent);
            newGO.transform.position = platformPos;
            Destroy(go);
        }
    }

}
