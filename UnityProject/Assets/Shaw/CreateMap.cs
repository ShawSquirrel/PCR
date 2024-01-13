using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;





public class MapItem : MonoBehaviour
{
    public TextMeshPro _Text;
    private void OnMouseEnter()
    {
        transform.GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseDown()
    {
        CreateMap.ClickMapItem?.Invoke(new Vector3(transform.position.x, transform.position.y, -10));
    }

    private void OnMouseExit()
    {
        transform.GetComponent<SpriteRenderer>().color = Color.white;
    }
}


public class CreateMap : MonoBehaviour
{
    public static Action<Vector3> ClickMapItem;
    public TextAsset _MapAsset;
    public List<List<int>> _MapList;
    public Transform _MapRoot;
    public Sprite _Sprite;
    public Transform _Player;

    private void Awake()
    {
        Load();
        ClickMapItem += (v3) =>
        {
            _Player.position = new Vector3(v3.x, v3.y, 0);
        };
    }

    [Button("Load")]
    public void Load()
    {
        _MapList = new List<List<int>>();
        string text = _MapAsset.text;
        string[] mapRow = text.Trim('\n').Split('\n');
        foreach (string row in mapRow)
        {
            List<int> mapColList = new List<int>();
            string[] mapCol = row.Trim('\t').Split('\t');
            foreach (string col in mapCol)
            {
                mapColList.Add(int.Parse(col));
            }

            _MapList.Add(mapColList);
        }


        for (int i = 0; i < _MapRoot.childCount; i++)
        {
            Destroy(_MapRoot.GetChild(i).gameObject);
        }


        for (int i = 0; i < _MapList.Count; i++)
        {
            List<int> col = _MapList[i];
            for (int ii = 0; ii < col.Count; ii++)
            {
                GameObject mapItem = new GameObject($"({ii},{i})");
                mapItem.transform.SetParent(_MapRoot);
                SpriteRenderer spriteRenderer = mapItem.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = _Sprite;
                spriteRenderer.color = _MapList[i][ii] switch
                {
                    0 => Color.black,
                    1 => Color.blue,
                    2 => Color.clear,
                    3 => Color.red,
                    _ => Color.white
                };

                mapItem.AddComponent<BoxCollider2D>();
                mapItem.AddComponent<MapItem>();
                mapItem.transform.localPosition = new Vector3(ii, i);
                mapItem.transform.localRotation = Quaternion.Euler(Vector3.zero);
                mapItem.transform.localScale = Vector3.one;



                TextMeshPro tmp = new GameObject("Text").AddComponent<TextMeshPro>();
                tmp.transform.SetParent(mapItem.transform);
                mapItem.GetComponent<MapItem>()._Text = tmp;
            }
        }
    }
}