using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Owner", menuName = "Owner")]
public class Owner : ScriptableObject
{
    public string ownerName;
    public List<string> traits;
}