using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform i;
    public float center = 0.03f;
    public float x, y;

    // Update is called once per frame
    void LateUpdate()
    {
        if(i != null) {
            Vector3 iPosition = new Vector3(i.position.x+x, i.position.y+center+y, -1);

            transform.position = Vector3.Lerp(transform.position, iPosition, 0.03f);
        }
    }
}
