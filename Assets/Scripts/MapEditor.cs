
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Note))]
[CanEditMultipleObjects]
public class MapEditor : Editor
{
    SerializedProperty pos;
    SerializedProperty beatSnap;
    // Update is called once per frame
    void OnEnable()
    {
        pos = serializedObject.FindProperty("pos");
        beatSnap = serializedObject.FindProperty("beatSnap");
    }
     public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(pos);
        EditorGUILayout.PropertyField(beatSnap);
        serializedObject.ApplyModifiedProperties();
    }
}
