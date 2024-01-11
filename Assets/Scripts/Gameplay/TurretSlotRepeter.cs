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

        objectToRepeat.transform.position = new Vector3(1.0f, 2.0f, 3.0f);

        /*
        int c = 0;
        int u = 0;

        Vector3 position = new Vector3(c * spacing, u * spacing, 0);
        GameObject TurretSlotClone1 = Instantiate(objectToRepeat, position, Quaternion.identity);
        -.-.-.--.
        Vector: the nomber means that is taking the 3 locations (x,y,z) i supose you can write 2 or just vector"
        */


        RepeatGameObject();

    }

    void RepeatGameObject()
    {

        double xnum = 2.8;
        double znum = 11;

 

        for (int x = 0; x < repeatCountX; x++)
        {
            for (int z = 0; z < repeatCountY; z++)
            {
                
                //Vector3 position = new Vector3(x: x * spacing, y: 0, z: z * spacing);


                 Vector3 position = new Vector3(x: (float)((x - xnum) * spacing), 0, z: (float)((z - znum) * spacing));;

                // Instantiate or place the object at the calculated position
                GameObject TurretSlotClone = Instantiate(objectToRepeat, position, Quaternion.identity);

               
            }
        }
    }




}



