using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameObjectRepeater : MonoBehaviour
{

    public GameObject objectToRepeat;
    public int repeatCountX = 10; // Number of repetitions in the X direction
    public int repeatCountY = 10; // Number of repetitions in the Y direction
    public float spacing = 1.0f; // Spacing between repeated objects


    void Start()

    {
        int c = 0;
        int u = 0;

        Vector3 position = new Vector3(c * spacing, u * spacing, 0);
        GameObject TurretSlotClone = Instantiate(objectToRepeat, position, Quaternion.identity);

        for (int y = 0; y < repeatCountY; y++)
        {
            Vector4 position2 = new Vector4(c * spacing, y * spacing, 0);

            // Instantiate or place the object at the calculated position
            GameObject instantiatedObject = Instantiate(objectToRepeat, position, Quaternion.identity);

        }





        /*
        for (int x = 0; x < repeatCountX; x++)
        {
            for (int y = 0; y < repeatCountY; y++)
            {
                Vector4 position2 = new Vector4(x * spacing, y * spacing, 0);

                // Instantiate or place the object at the calculated position
                GameObject instantiatedObject = Instantiate(objectToRepeat, position, Quaternion.identity);

            }

        }*/





    }

    
    
    
   
    
}



