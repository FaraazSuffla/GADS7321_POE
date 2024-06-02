using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pet", menuName = "Pet")]
public class Pet : ScriptableObject
{
    public string petName;
    public List<string> traits;
    public Sprite portrait;
}