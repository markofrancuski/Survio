using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkillEditor : EditorWindow
{
    [MenuItem("Skill Window/Skill Editor")]
    public static void ShowWindow()
    { 
        GetWindow(typeof(SkillEditor));
    }

    private void Awake()
    {
        
    }

    public bool isSkillEditorTrue;
    public bool isEffectEditorTrue;
    public bool isRequirementsEditorTrue;


    private void OnGUI()
    {
        /*EditorGUILayout.LabelField("Test");

        if(GUILayout.Button("Make New Skill"))
        {
           
        }
        */

        if (GUI.Button(new Rect(0, 0,200, 75), "Skill"))
        {
            isSkillEditorTrue = true;
            isEffectEditorTrue = false;
            isRequirementsEditorTrue = false;
        }
        if (GUI.Button(new Rect(200, 0, 200, 75), "Effect"))
        {
            isSkillEditorTrue = false;
            isEffectEditorTrue = true;
            isRequirementsEditorTrue = false;
        }
        if (GUI.Button(new Rect(400, 0, 200, 75), "Requirement"))
        {
            isSkillEditorTrue = false;
            isEffectEditorTrue = false;
            isRequirementsEditorTrue = true;
        }

        if(isSkillEditorTrue)
        {
            GUI.Label(new Rect(200, 200, 150, 50),"Skill Tab");
            GUI.Label(new Rect(200, 350, 150, 50), "Testing");
        }
        if (isEffectEditorTrue)
        {
            GUI.Label(new Rect(200, 200, 150, 50), "Effect Tab");
        }
        if (isRequirementsEditorTrue)
        {
            GUI.Label(new Rect(200, 200, 150, 50), "Requirement Tab");
        }

    }


}
