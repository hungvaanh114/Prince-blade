using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class AutoAddSkeletonData : MonoBehaviour
{
    public SkeletonList skeletonList;

#if UNITY_EDITOR
    [ContextMenu("Auto Add Skeleton Data")]
    public void AddAllSkeletonData()
    {
        string[] guids = AssetDatabase.FindAssets("t:SkeletonData");//Tìm tất cả các tài sản trong dự án có kiểu SkeletonData.
        List<SkeletonData> allSkeletonData = new List<SkeletonData>();

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);// Chuyển đổi GUID của tài sản thành đường dẫn tài sản.
            SkeletonData skeletonData = AssetDatabase.LoadAssetAtPath<SkeletonData>(path);//Tải tài sản từ đường dẫn cụ thể
            if (skeletonData != null)
            {
                allSkeletonData.Add(skeletonData);
            }
        }

        // Gán tất cả các SkeletonData vào skeletonList
        skeletonList.skeletons = allSkeletonData;

        // Lưu thay đổi
        EditorUtility.SetDirty(skeletonList);//Đảm bảo rằng những thay đổi được lưu lại trong tài sản SkeletonList.
        AssetDatabase.SaveAssets();
    }
#endif
}
