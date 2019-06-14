using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CustomMenu/RankingData", fileName = "RankingData")]
public class RankingData : ScriptableObject {

    public List<float> rankingLis = new List<float>(5);
}
