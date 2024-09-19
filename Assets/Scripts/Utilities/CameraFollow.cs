using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target; // Đối tượng mà camera sẽ theo dõi
    [SerializeField] private float smoothSpeed = 4f; // Tốc độ di chuyển mượt mà của camera
    [SerializeField] private float camDown=2f;
    [SerializeField] private float camTop=2f;
    [SerializeField] private float camTopDown=2f;
    private float oldCamTopDown;
    private void Start()
    {
        target = GameObject.Find("Knight").transform;
        oldCamTopDown = camTopDown;
    }
    void LateUpdate()
    {
        if (target == null) return; // Nếu không có đối tượng nào để theo dõi, thoát khỏi hàm

        Vector3 newPos = new Vector3(target.position.x, target.position.y+camTopDown, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, smoothSpeed * Time.deltaTime);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            camTopDown = camTop;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            camTopDown = camDown;
        }
        if(Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.S))
        {
            camTopDown = oldCamTopDown;
        }
    }
}
