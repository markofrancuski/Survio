using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    //Singleton
    public static SaveManager Instance;

    //FilePaths
    public const string SKILL_PATH = "/skills.txt";

    private void Awake()
    {
        Instance = this;
    }



}
