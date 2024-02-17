using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D[] cursorTextureArray;
    [SerializeField] private int frameCount;
    [SerializeField] private float frameRate;

    [SerializeField] private List<CursorAnimation> cursorAnimList;

    private int currentFrame;
    private float frameTimer;

    public enum CursorType
    {
        Aim,
        Grab
    }
    
    private void Start()
    {
        Cursor.SetCursor(cursorTextureArray[0], new Vector2(48, 48), CursorMode.ForceSoftware);
    }

    private void Update()
    {
        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0f)
        {
            frameTimer += frameRate;
            currentFrame = (currentFrame + 1) % frameCount;
            Cursor.SetCursor(cursorTextureArray[currentFrame], new Vector2(48, 48), CursorMode.ForceSoftware);
        }
    }

    [System.Serializable]
    public class CursorAnimation
    {
        public CursorType cursorType;
        public Texture2D[] textureArray;
        public float frameRate;
        public Vector2 offset;
    }
}
