using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectMover))]
public class ObjectMoverEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ObjectMover objectMover = (ObjectMover)target;

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Create Point"))
        {
            objectMover.CreatePoint();
            Selection.activeObject = objectMover.points[objectMover.points.Count - 1];
            PrefabUtility.RecordPrefabInstancePropertyModifications(objectMover);
        }

        // Zkontroluj, zda existují body pøed zobrazením tlaèítka "Delete Point"
        EditorGUI.BeginDisabledGroup(objectMover.points.Count == 0);
        if (GUILayout.Button("Delete Point"))
        {
            objectMover.DestroyPoint();
        }
        EditorGUI.EndDisabledGroup();

        GUILayout.EndHorizontal();
    }

    private void OnSceneGUI()
    {
        ObjectMover objectMover = (ObjectMover)target;

        Handles.color = Color.green;

        Vector3[] positions = GetPositions(objectMover);

        // Vykresli èáry mezi body
        Handles.DrawAAPolyLine(positions);

        // Zobraz èísla nad každým bodem
        for (int i = 0; i < objectMover.points.Count; i++)
        {
            Vector3 pointPosition = positions[i];

            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.black;
            style.alignment = TextAnchor.LowerCenter;

            Handles.Label(pointPosition + Vector3.up * 0.5f, i.ToString(), style);
        }
    }

    private Vector3[] GetPositions(ObjectMover objectMover)
    {
        Vector3[] positions = new Vector3[objectMover.points.Count];
        for (int i = 0; i < objectMover.points.Count; i++)
        {
            positions[i] = objectMover.points[i].transform.position;
        }
        return positions;
    }
}
