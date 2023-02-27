using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PropRestorePuzzleParent), true)]
public class PropRestorePuzzleParentEditor : Editor
{
    public static PropRestorePuzzleParentEditor instance;
    new public SerializedProperty hasDialogue;
    protected SerializedProperty isInteracatable;
    protected SerializedProperty dialogueBeggining;
    protected SerializedProperty dialogueEnd;
    protected SerializedProperty deactivateAfterDialogue;

    protected SerializedProperty dialogueOnlyOnce;
    protected SerializedProperty VictoryConditions;
    protected SerializedProperty FinalPositionOfItem;

    protected SerializedProperty subMision;
    bool dialogueOptionsGroup = true;

    MonoScript script = null;
    private void OnEnable()
    {
        //script = MonoScript.FromMonoBehaviour((MyScript)target);
        instance = this;
        hasDialogue = serializedObject.FindProperty("hasDialogue");
        isInteracatable = serializedObject.FindProperty("isInteractable");
        dialogueBeggining = serializedObject.FindProperty("dialogueBeggining");
        dialogueEnd = serializedObject.FindProperty("dialogueEnd");
        deactivateAfterDialogue = serializedObject.FindProperty("deactivateAfterDialogue");

        dialogueOnlyOnce = serializedObject.FindProperty("dialogueOnlyOnce");
        VictoryConditions = serializedObject.FindProperty("VictoryConditions");
        FinalPositionOfItem = serializedObject.FindProperty("FinalPositionOfItem");

        subMision = serializedObject.FindProperty("subMision");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUI.enabled = false;
        SerializedProperty prop = serializedObject.FindProperty("m_Script");
        EditorGUILayout.PropertyField(prop, true, new GUILayoutOption[0]);
        GUI.enabled = true;

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

        EditorGUILayout.PropertyField(VictoryConditions);
        EditorGUILayout.PropertyField(FinalPositionOfItem);
        EditorGUILayout.PropertyField(subMision);
       

        serializedObject.ApplyModifiedProperties();
    }


}
