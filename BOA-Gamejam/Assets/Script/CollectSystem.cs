using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSystem : MonoBehaviour
{
    bool Pressed = false;
    int cnt = 0;
    [SerializeField]
    private GameObject player;

    private void OnMouseDown()
    {
        Pressed = true;
        Destroy(gameObject);
        print("PRessed" + cnt);
        cnt++;
    }

    private void OnMouseUp()
    {
        Pressed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
