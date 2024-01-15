using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;


public class MapItem : MonoBehaviour
{
    public TextMeshPro _Text;
    public int Cost;

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

    public MapItem[,] MapItemList = new MapItem[6, 6];

    private void Awake()
    {
        Load();
        ClickMapItem += OnClickMapItem;


        AStar.Instance.Init(_MapList);
    }


    private void Update()
    {
        var result = AStar.Instance.GetAllCost(TransTo(_Player.position));
        for (int i = 0; i < 6; i++)
        {
            for (int ii = 0; ii < 6; ii++)
            {
                MapItemList[i, ii]._Text.text = $"{MapItemList[i, ii].Cost}|{result[i, ii]}";
            }
        }
    }

    public async void OnClickMapItem(Vector3 v3)
    {
        List<AStar.Node> path = AStar.Instance.FindPath(TransTo(_Player.position), TransTo(v3));
        Debug.Log(path[^1].FCost);
        foreach (AStar.Node node in path)
        {
            bool isComplete = false;
            DOTween.To(() => _Player.position,
                       (value) => _Player.position = value,
                       new Vector3(node.GridX, node.GridY), 1f).OnComplete(() => isComplete = true);

            while (!isComplete)
            {
                await UniTask.DelayFrame(1);
            }
        }
    }

    public Vector2Int TransTo(Vector3 pos)
    {
        return new Vector2Int(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y));
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

                mapItem.AddComponent<BoxCollider2D>();
                MapItem item = mapItem.AddComponent<MapItem>();
                item.Cost                       = _MapList[i][ii];
                mapItem.transform.localPosition = new Vector3(ii, i);
                mapItem.transform.localRotation = Quaternion.Euler(Vector3.zero);
                mapItem.transform.localScale    = Vector3.one;


                TextMeshPro tmp = new GameObject("Text").AddComponent<TextMeshPro>();
                tmp.transform.SetParent(mapItem.transform);
                tmp.transform.localPosition = new Vector3(0, 0, -1);
                tmp.transform.localRotation = Quaternion.Euler(Vector3.zero);
                tmp.transform.localScale    = Vector3.one;
                tmp.fontSize                = 3;
                tmp.alignment               = TextAlignmentOptions.Center;
                tmp.text                    = _MapList[i][ii].ToString();
                tmp.color                   = Color.cyan;

                mapItem.GetComponent<MapItem>()._Text = tmp;


                MapItemList[i, ii] = item;
            }
        }
    }
}