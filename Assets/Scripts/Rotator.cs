using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public Vector3 mPrevPos = Vector3.zero;
    public Vector3 mDeltaPos = Vector3.zero;
    public bool rotateY = true;
    public bool rotateXZ = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mDeltaPos = Input.mousePosition - mPrevPos;
            if (rotateY)
            {
                transform.Rotate(transform.up, Vector3.Dot(mDeltaPos, Camera.main.transform.right), Space.World);
            }
            if (rotateXZ)
            {
                transform.Rotate(Camera.main.transform.right, Vector3.Dot(mDeltaPos, Camera.main.transform.up), Space.World);
            }
        }

        mPrevPos = Input.mousePosition;
    }
    

}
