using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSystem : MonoBehaviour
{
    [SerializeField] private CursorManager.CursorType cursorType;
    bool Pressed = false;
    int cnt = 0;
    [SerializeField]
    private GameObject player;

    private float HoldStartTime;
    float HoldTime;

    private void OnMouseDown()
    {
        Pressed = true;
       HoldStartTime = Time.time;

        print("PRessed" + cnt);
        cnt++;
    }

    private void OnMouseUp()
    {
        Pressed = false;
    }

    private void OnMouseEnter()
    {
        CursorManager.Instance.SetActiveCursorType(cursorType);
    }

    private void OnMouseExit()
    {
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Aim);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed)
        {
            HoldStartTime = Time.time;
        }
    }

    private void DestroyEgg()
    {
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Aim);
        Destroy(gameObject);
    }
}
