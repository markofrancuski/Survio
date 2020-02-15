using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{

    #region Singleton

    public static DamageManager Instance;

    #endregion

    public GameObject prefab;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnText(Vector3 positionToSpawn, string text, Colors color = Colors.WHITE)
    {
        GameObject go = Instantiate(prefab);
        go.transform.GetChild(0).GetComponent<DamagePopUp>().ShowText(positionToSpawn, text, color);
      
        //Get Object From Pooler
        //Enable it
        //Set Up Values

    }


}
