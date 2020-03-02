using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkillRequirementEditor : EditorWindow
{
    [MenuItem("Skill Window/Skill Requirement Editor")]
    public static void ShowWindow()
    {
        GetWindow(typeof(SkillRequirementEditor));
    }

    private void Awake()
    {

    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Skill Requirement Welcome Message");

        if (GUILayout.Button("Make New Skill Requirement"))
        {

        }

    }
}
