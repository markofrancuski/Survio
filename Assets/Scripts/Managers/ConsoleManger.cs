using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleManger : MonoBehaviour
{
    public static ConsoleManger Instance;

    [SerializeField] private Transform _targetTransform;

    [SerializeField] private GameObject _prefab;

    private void Awake()
    {
        Instance = this;
    }

    public void DisplayNotification(string str)
    {
        GameObject GO = Instantiate(_prefab);
        GO.transform.SetParent(_targetTransform);

        GO.GetComponent<NotificationText>().Setup(str);
    }
}


struct NotificationInfo
{
    public int NotifyIndex;


}

