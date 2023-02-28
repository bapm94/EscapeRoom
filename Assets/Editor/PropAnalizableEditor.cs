using System;
using UnityEditor;

[CustomEditor(typeof(PropAnalizable))]
public class  PropAnalizableEditor : PropEditor
{
    //SerializedProperty hasDialogue;
    protected SerializedProperty localAnalizingScale;
    protected SerializedProperty localAnalizingEulerAngles;

    new public SerializedProperty hasDialogue;
    new protected SerializedProperty isInteracatable;
    new protected SerializedProperty dialogueBeggining;
    new protected SerializedProperty dialogueEnd;
    new protected SerializedProperty deactivateAfterDialogue;

    SerializedProperty dialogueOnlyOnce;

    bool dialogueOptionsGroup1, analizingOptions = true;
   
    private void OnEnable()
    {

        hasDialogue = serializedObject.FindProperty("hasDialogue");
        isInteracatable = serializedObject.FindProperty("isInteractable");
        dialogueBeggining = serializedObject.FindProperty("dialogueBeggining");
        dialogueEnd = serializedObject.FindProperty("dialogueEnd");
        deactivateAfterDialogue = serializedObject.FindProperty("deactivateAfterDialogue"); 


        localAnalizingScale = serializedObject.FindProperty("localAnalizingScale");
        localAnalizingEulerAngles = serializedObject.FindProperty("localAnalizingEulerAngles");

        dialogueOnlyOnce = serializedObject.FindProperty("dialogueOnlyOnce");

    }
    public override void OnInspectorGUI()
    {
        
        
        serializedObject.Update();

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

        serializedObject.ApplyModifiedProperties();
    }
}