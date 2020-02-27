using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkillEditor : EditorWindow
{
    [MenuItem("Window/Skill Editor")]
    public static void ShowWindow()
    { 
        GetWindow(typeof(SkillEditor));
    }

    private void Awake()
    {
        
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Test");
    }
}
