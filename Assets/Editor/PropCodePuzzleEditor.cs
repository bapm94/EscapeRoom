using UnityEditor;


[CustomEditor(typeof(PropCodePuzzle), true), CanEditMultipleObjects]
public class PropCodePuzzleEditor : PropEditor
{
    SerializedProperty numericCode;
    SerializedProperty dials;

    private void OnEnable()
    {
        numericCode = serializedObject.FindProperty("numericCode");
        dials = serializedObject.FindProperty("dials");
    }

    // Start is called before the first frame update

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //base.OnInspectorGUI();

        EditorGUILayout.PropertyField(numericCode);
        EditorGUILayout.PropertyField(dials);



        serializedObject.ApplyModifiedProperties();
    }

}
