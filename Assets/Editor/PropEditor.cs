using UnityEditor;

[CustomEditor(typeof(Prop), true)]
public class PropEditor : Editor
{
    public static PropEditor instance;
    public SerializedProperty  hasDialogue;
    protected SerializedProperty isInteracatable;
    protected SerializedProperty dialogueBeggining;
    protected SerializedProperty dialogueEnd;
    protected SerializedProperty deactivateAfterDialogue;

    SerializedProperty dialogueOnlyOnce;

    bool dialogueOptionsGroup = true;

    private void OnEnable()
    {
        instance = this;
        hasDialogue = serializedObject.FindProperty("hasDialogue");
        isInteracatable = serializedObject.FindProperty("isInteractable");
        dialogueBeggining = serializedObject.FindProperty("dialogueBeggining");
        dialogueEnd = serializedObject.FindProperty("dialogueEnd");
        deactivateAfterDialogue = serializedObject.FindProperty("deactivateAfterDialogue");

        dialogueOnlyOnce = serializedObject.FindProperty("dialogueOnlyOnce");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(hasDialogue);

         
        if (hasDialogue.boolValue)
        {
            dialogueOptionsGroup = EditorGUILayout.BeginFoldoutHeaderGroup(dialogueOptionsGroup, "Dialogue Options");
            EditorGUILayout.PropertyField(dialogueOnlyOnce);
            EditorGUILayout.PropertyField(deactivateAfterDialogue);
            EditorGUILayout.PropertyField(dialogueBeggining);
            EditorGUILayout.PropertyField(dialogueEnd);
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
        

        serializedObject.ApplyModifiedProperties();
    }


}
