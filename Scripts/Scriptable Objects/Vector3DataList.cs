using System.Collections.Generic;
using Tools.Scripts.Scriptable_Objects;
using UnityEngine;
[CreateAssetMenu(fileName = "New Vector 3 List Obj", menuName = "Scriptable Objects/Vector 3 List Obj")]
public class Vector3DataList : ScriptableObject
{
    public List<Vector3ScriptableObject> vector3SOList;
}
