using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkillEffectEditor : EditorWindow
{
    [MenuItem("Skill Window/Skill Effect Editor")]
    public static void ShowWindow()
    {
        GetWindow(typeof(SkillEffectEditor));
    }

    private void Awake()
    {

    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Skill Effect Welcome Message");

        if (GUILayout.Button("Make New Skill Effect"))
        {

        }

    }
}