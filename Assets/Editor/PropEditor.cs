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
    protected SerializedProperty isNotImportant;
    protected SerializedProperty outlineColor;

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
        isNotImportant = serializedObject.FindProperty("isNotImportant");
        outlineColor = serializedObject.FindProperty("outlineColor");

        dialogueOnlyOnce = serializedObject.FindProperty("dialogueOnlyOnce");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(hasDialogue);

         
        if (hasDialogue.boolValue)
        {
            dialogueOptionsGroup = EditorGUILayout.BeginFoldoutHeaderGroup(dialogueOptionsGroup, "Dialogue Options");
            if (dialogueOptionsGroup)
            {
                EditorGUILayout.PropertyField(dialogueOnlyOnce);
                EditorGUILayout.PropertyField(deactivateAfterDialogue);
                EditorGUILayout.PropertyField(dialogueBeggining);
                EditorGUILayout.PropertyField(dialogueEnd);
            }
            
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
        EditorGUILayout.PropertyField(isNotImportant);
        EditorGUILayout.PropertyField(outlineColor);

        serializedObject.ApplyModifiedProperties();
    }


}
