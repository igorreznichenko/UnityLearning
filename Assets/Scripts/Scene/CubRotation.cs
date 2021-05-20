using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubRotation : MonoBehaviour
{
    [SerializeField] float _angle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateByQuat();
        if(Input.GetKey(KeyCode.R))
            RotateByQuat();

        if (Input.GetKey(KeyCode.T))
            RotateByEuler();

    }
    void RotateByQuat()
    {

        Quaternion rotate = Quaternion.Euler(new Vector3(0f, (_angle / 60f) * Time.deltaTime, 0f));
        transform.rotation *= new Quaternion(rotate.x, rotate.y, rotate.z, rotate.w);
    }
    void RotateByEuler()
    {
        Quaternion rotate = Quaternion.Euler(0, _angle, 0);
        transform.rotation *= rotate;
    }
}
