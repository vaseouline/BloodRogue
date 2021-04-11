using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Utilities class for some custom function
public static class Utilities
{
    //TODO move this to utilities class
    public static float AngleBetweenTwoPoints(Vector2 a, Vector2 b) {
         return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
     }

    //Maybe goes to utilities class?
    public static Vector3 MatrixMultiplication(Vector3 a, Vector3 b) {
        Vector3 newVector = new Vector3(0,0,0);
        newVector.x = a.x * b.x;
        newVector.y = a.y * b.y;
        newVector.z = a.z * b.z;
        return newVector;
    }
}
