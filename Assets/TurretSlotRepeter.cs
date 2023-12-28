using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectRepeater : MonoBehaviour
{
    
    public GameObject objectToRepeat;
    public int repeatCountX = 10; // Number of repetitions in the X direction
    public int repeatCountY = 10; // Number of repetitions in the Y direction
    public float spacing = 1.0f; // Spacing between repeated objects

    /*
    void Start()
    {
        RepeatGameObject();
    }

    void RepeatGameObject()
    {
        for (int x = 0; x < repeatCountX; x++)
        {
            for (int y = 0; y < repeatCountY; y++)
            {
                Vector3 position = new Vector3(x * spacing, y * spacing, 0);

                // Instantiate or place the object at the calculated position
                GameObject instantiatedObject = Instantiate(objectToRepeat, position, Quaternion.identity);

                //---------------

                // Add debug statement to check if instantiation occurs
                Debug.Log("Object instantiated at position: " + position);

                // Add debug statement to check the instantiated object's position
                Debug.Log("Instantiated object's position: " + instantiatedObject.transform.position);
            }
        }
    }
    */
}

