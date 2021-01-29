using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage")]
public class SO_Stage : ScriptableObject
{
    public int stage;
    public List<Sprite> sprites;
    public int secondsForStage;
}
