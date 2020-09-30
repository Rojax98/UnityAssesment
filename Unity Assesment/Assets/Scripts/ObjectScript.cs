using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "Moveable Objects", order = 1)]
public class ObjectScript : ScriptableObject
{
    public string objectName;
    public GameObject prefab;

}
