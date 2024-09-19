using UnityEngine;

public class AssignTagToRangers : MonoBehaviour
{
    [SerializeField] private string tagName = "ranger"; // Thay đổi tên tag ở đây

    void Start()
    {
        // Tìm tất cả các GameObject có tên là "Ranger"
        GameObject[] rangers = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject ranger in rangers)
        {
            if (ranger.name == "Ranger")
            {
                ranger.tag = tagName;
            }
        }
    }

}
