using Tools.Scripts.Scriptable_Objects;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu]
public class Instancer : ScriptableObject
{
    public GameObject prefab;
    private int num;
    public void CreateInstance()
    {
        Instantiate(prefab);
    }

    public void CreateInstance(Vector3ScriptableObject obj)
    {
        Instantiate(prefab, obj.value, Quaternion.identity);
    }

    public void CreateInstanceFromList(Vector3DataList obj)
    {
        foreach (var t in obj.vector3SOList)
        {
            Instantiate(prefab, t.value, Quaternion.identity);
        }
    }
    
    public void CreateInstanceFromListCounting(Vector3DataList obj)
    {
        Instantiate(prefab, obj.vector3SOList[num].value, Quaternion.identity);

        num++;
        if (num == obj.vector3SOList.Count)
        {
            num = 0;
        }
    }
    public void CreateInstanceListRandomly(Vector3DataList obj)
    {
        num = Random.Range(0, obj.vector3SOList.Count - 1);
        Instantiate(prefab, obj.vector3SOList[num].value, Quaternion.identity);
    }
}
