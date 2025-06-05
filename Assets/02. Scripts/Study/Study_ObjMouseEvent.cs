using UnityEngine;

// 콜라이더 컴포넌트를 가진 오브젝트를 대상으로하는 마우스 입력 함수 스크립트
public class Study_ObjMouseEvent : MonoBehaviour
{
    private void OnMouseDown() // 오브젝트 위에서 마우스 입력 버튼 눌렀을때
    {
        Debug.Log("OnMouseDown");
    }

    private void OnMouseUp() // 마우스로 오브젝트를 클릭하고 뗐을때
    {
        Debug.Log("onMouseUp");
    }

    private void OnMouseEnter() // 마우스가 오브젝트에 들어왔을때
    {
        Debug.Log("onMouseEnter");
    }

    private void OnMouseExit() // 마우스가 오브젝트에서 빠져나왔을때
    {
        Debug.Log("onMouseExit");
    }

    private void OnMouseUpAsButton() // 마우스를 오브젝트 위에서 입력 및 뗐을때
    {
        Debug.Log("OnMouseUpAsButton");
    }

    private void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
    }
    
    
}
