using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; // Đối tượng cần theo dõi

    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3( target.position.x,target.position.y,0);
        }
    }
}
