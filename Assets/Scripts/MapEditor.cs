
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Note))]
[CanEditMultipleObjects]
public class MapEditor : Editor
{
    SerializedProperty pos;
    SerializedProperty beatSnap;
    SerializedProperty a;
    // Update is called once per frame
    void OnEnable()
    {
        pos = serializedObject.FindProperty("pos");
        beatSnap = serializedObject.FindProperty("beatSnap");
        a = serializedObject.FindProperty("a");
    }
     public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(pos);
        EditorGUILayout.PropertyField(beatSnap);
        EditorGUILayout.PropertyField(a);
        serializedObject.ApplyModifiedProperties();
    }
}
