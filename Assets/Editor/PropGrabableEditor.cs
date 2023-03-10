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
    protected SerializedProperty isNotImportant;
    protected SerializedProperty outlineColor;

    SerializedProperty dialogueOnlyOnce;
    SerializedProperty canBeCollectedAgain;
    SerializedProperty spriteEurlerAngles;
    //SerializedProperty extraActionOnCollected;

    bool dialogueOptionsGroup1, analizingOptions = true;

    private void OnEnable()
    {
        spriteScale = serializedObject.FindProperty("spriteScale");
        hasDialogue = serializedObject.FindProperty("hasDialogue");
        isInteracatable = serializedObject.FindProperty("isInteractable");
        dialogueBeggining = serializedObject.FindProperty("dialogueBeggining");
        dialogueEnd = serializedObject.FindProperty("dialogueEnd");
        deactivateAfterDialogue = serializedObject.FindProperty("deactivateAfterDialogue");
        isNotImportant = serializedObject.FindProperty("isNotImportant");
        outlineColor = serializedObject.FindProperty("outlineColor");

        localAnalizingScale = serializedObject.FindProperty("localAnalizingScale");
        localAnalizingEulerAngles = serializedObject.FindProperty("localAnalizingEulerAngles");

        dialogueOnlyOnce = serializedObject.FindProperty("dialogueOnlyOnce");
        canBeCollectedAgain = serializedObject.FindProperty("canBeCollectedAgain");

        spriteEurlerAngles = serializedObject.FindProperty("spriteEurlerAngles");
      //  extraActionOnCollected = serializedObject.FindProperty("extraActionOnCollected");
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
        EditorGUILayout.PropertyField(isNotImportant);
        EditorGUILayout.PropertyField(outlineColor);

        analizingOptions = EditorGUILayout.BeginFoldoutHeaderGroup(analizingOptions, "Analizing Transform");
        if (analizingOptions)
        {
            EditorGUILayout.PropertyField(localAnalizingScale);
            EditorGUILayout.PropertyField(localAnalizingEulerAngles);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        EditorGUILayout.PropertyField(spriteScale);
        EditorGUILayout.PropertyField(spriteEurlerAngles);
        EditorGUILayout.PropertyField(canBeCollectedAgain);
       // EditorGUILayout.PropertyField(extraActionOnCollected);

        serializedObject.ApplyModifiedProperties();
    }
}
