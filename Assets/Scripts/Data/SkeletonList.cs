using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkeletonList", menuName = "Game Data/SkeletonList")]
public class SkeletonList : ScriptableObject
{
    public List<SkeletonData> skeletons;
}

