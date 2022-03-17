using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Apple", menuName = "Apple")]
public class ScriptableApple : ScriptableObject
{
    public string AppleName;
    public Sprite AppleSkin;
    public int AppearChance;
}
