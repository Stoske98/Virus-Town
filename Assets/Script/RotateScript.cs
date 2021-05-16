using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{

    private int rotate = 0;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, rotate + 1, 0);
        if(rotate > 360)
        {
            rotate = 0;
        }
    }
}
