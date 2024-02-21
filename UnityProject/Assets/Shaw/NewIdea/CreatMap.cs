using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CreatMap : MonoBehaviour
{
    public GameObject _Prefab_MapItem;

    [Button("建造")]
    public void CreateMap()
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject mapItem = Instantiate(_Prefab_MapItem);
            mapItem.SetActive(true);
            mapItem.name = i.ToString();
            mapItem.transform.position = new Vector3(i / 3 - 1, i % 3 - 1, 0);
        }
        
    }
}
