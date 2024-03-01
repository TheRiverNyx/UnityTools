using Tools.Scripts.Scriptable_Objects;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

[CreateAssetMenu]
public class Instancer : ScriptableObject
{
    public GameObject prefab;
    public GameObject playerCamera;
    private Camera camera;
    private int num;

    public void Initialize()
    {
        camera = playerCamera.GetComponent<Camera>();
    }
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

    public void CreateInstanceInTilemap(Tilemap tilemap)
    {
        Vector3 position;

        do 
        {
            // Generate a random position within tilemap's region
            position = new Vector3(
                Random.Range(tilemap.cellBounds.xMin, tilemap.cellBounds.xMax),
                Random.Range(tilemap.cellBounds.yMin, tilemap.cellBounds.yMax),
                Random.Range(tilemap.cellBounds.zMin, tilemap.cellBounds.zMax)
            );

            // Convert the position into world coordinates
            position = tilemap.CellToWorld(Vector3Int.FloorToInt(position));
        } 
        // Continue looping until an empty position outside of camera's view is found
        while (tilemap.HasTile(tilemap.WorldToCell(position)) || IsObjectVisible( position));
        
        // Instantiate the prefab at the generated position
        Instantiate(prefab, position, Quaternion.identity);
    }
    public bool IsObjectVisible(Vector3 position)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(camera);
        var pointBounds = new Bounds(position, Vector3.zero);
        return GeometryUtility.TestPlanesAABB(planes, pointBounds);
    }
}