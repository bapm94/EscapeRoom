using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PropGrabable), true), CanEditMultipleObjects]
public class PropGrabableEditor : Editor
{
    protected   SerializedProperty spriteScale;
    protected SerializedProperty localAnalizingScale;
    protected SerializedProperty localAnalizingEulerAngles;

    public SerializedProperty hasDialogue;
    protected SerializedProperty isInteracatable;
    protected SerializedProperty dialogueBeggining;
    protected SerializedProperty dialogueEnd;
    protected SerializedProperty deactivateAfterDialogue;

    SerializedProperty dialogueOnlyOnce;
    SerializedProperty canBeCollectedAgain;

    bool dialogueOptionsGroup1, analizingOptions = true;

    private void OnEnable()
    {
        spriteScale = serializedObject.FindProperty("spriteScale");
        hasDialogue = serializedObject.FindProperty("hasDialogue");
        isInteracatable = serializedObject.FindProperty("isInteractable");
        dialogueBeggining = serializedObject.FindProperty("dialogueBeggining");
        dialogueEnd = serializedObject.FindProperty("dialogueEnd");
        deactivateAfterDialogue = serializedObject.FindProperty("deactivateAfterDialogue");


        localAnalizingScale = serializedObject.FindProperty("localAnalizingScale");
        localAnalizingEulerAngles = serializedObject.FindProperty("localAnalizingEulerAngles");

        dialogueOnlyOnce = serializedObject.FindProperty("dialogueOnlyOnce");
        canBeCollectedAgain = serializedObject.FindProperty("canBeCollectedAgain");
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
            dialogueOptionsGroup1 = EditorGUILayout.BeginFoldoutHeaderGroup(dialogueOptionsGroup1, "Dialogue Options");
            if (dialogueOptionsGroup1)
            {
                EditorGUILayout.PropertyField(dialogueOnlyOnce);
                EditorGUILayout.PropertyField(deactivateAfterDialogue);
                EditorGUILayout.PropertyField(dialogueBeggining);
                EditorGUILayout.PropertyField(dialogueEnd);
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }

        analizingOptions = EditorGUILayout.BeginFoldoutHeaderGroup(analizingOptions, "Analizing Transform");
        if (analizingOptions)
        {
            EditorGUILayout.PropertyField(localAnalizingScale);
            EditorGUILayout.PropertyField(localAnalizingEulerAngles);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        EditorGUILayout.PropertyField(spriteScale);
        EditorGUILayout.PropertyField(canBeCollectedAgain);

        serializedObject.ApplyModifiedProperties();
    }
}
