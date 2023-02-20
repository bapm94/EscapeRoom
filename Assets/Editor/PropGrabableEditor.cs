using UnityEditor;

[CustomEditor(typeof(PropGrabable), true), CanEditMultipleObjects]
public class PropGrabableEditor : Editor
{
    SerializedProperty pepe;

    private void OnEnable()
    {
        pepe = serializedObject.FindProperty("pepe");
    }
    public override void OnInspectorGUI()
    {

        serializedObject.Update();

       

        EditorGUILayout.PropertyField(pepe);

        serializedObject.ApplyModifiedProperties();
    }
}
