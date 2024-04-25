using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NodePlacer))]
public class NodePlacerUI : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw default inspector property editor
        DrawDefaultInspector();

        // Get a reference to the script
        NodePlacer nodePlacer = (NodePlacer)target;
        
        if(GUILayout.Button("Scan"))
        {
            nodePlacer.Scan();
        }
    }
}