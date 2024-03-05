using Lean.Touch;
using TEngine;
using UnityEngine;
using UnityEngine.UIElements;

public class StickManager : MonoBehaviour
{
    public GameObject _Stick;
    public GameObject _Center;

    public Vector3 _BeginPos;
    public Vector3 _CenterPos;

    public void OnBeginDrag()
    {
        Debug.Log("OnBeginDrag");
        _Stick.SetActive(true);
        _BeginPos = _Stick.transform.position = Input.mousePosition;
    }
    public void OnDrag()
    {
        Debug.Log("OnDrag");
        if ((Input.mousePosition - _BeginPos).magnitude > 95)
        {
            _CenterPos = (Input.mousePosition - _BeginPos).normalized * 95;
            _Center.transform.position = _BeginPos + _CenterPos;
        }
        else
        {
            _Center.transform.position = Input.mousePosition;
        }
        
    }
    public void OnEndDrag()
    {
        Debug.Log("OnEndDrag");
        _Stick.SetActive(false);
    }
}
