using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    [SerializeField] private CursorManager.CursorType cursorType;
    bool Pressed = false;
    int cnt = 0;
    [SerializeField]
    private GameObject player;

    private float HoldCurTime;
    float HoldTime;

    private void OnMouseDown()
    {
        Pressed = true;
        HoldTime = Time.time;
        //playerPrefab.GetComponent<PlayerStats>().health += 10;
        //DestroyEgg();
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
            HoldTime += Time.deltaTime;
        }

        if (!Pressed)
        {
            if(HoldCurTime > HoldTime)
            {
                HoldCurTime = 0;
            }
                
            

        }
        
        if(HoldCurTime < HoldTime)
        {

        }

    }

    private void DestroyEgg()
    {
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Aim);
        Destroy(gameObject);
    }
}
