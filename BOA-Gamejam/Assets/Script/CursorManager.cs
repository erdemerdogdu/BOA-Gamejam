using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance { get; private set; }

    [SerializeField] private List<CursorAnimation> cursorAnimList;

    private CursorAnimation cursorAnimation;

    private int currentFrame;
    private float frameTimer;
    private int frameCount;

    public enum CursorType
    {
        Aim,
        Grab
    }

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetActiveCursorType(CursorType.Aim);
    }

    private void Update()
    {
        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0f)
        {
            frameTimer += cursorAnimation.frameRate;
            currentFrame = (currentFrame + 1) % frameCount;
            Cursor.SetCursor(cursorAnimation.textureArray[currentFrame], cursorAnimation.offset, CursorMode.Auto);
        }
    }

    public void SetActiveCursorType(CursorType cursorType)
    {
        SetActiveCursorAnim(GetCursorAnimation(cursorType));
    }

    private CursorAnimation GetCursorAnimation(CursorType cursorType)
    {
        foreach(CursorAnimation cursorAnimation in cursorAnimList)
        {
            if (cursorAnimation.cursorType == cursorType) return cursorAnimation;
        }

        return null;
    }

    private void SetActiveCursorAnim(CursorAnimation animation)
    {
        this.cursorAnimation = animation;
        currentFrame = 0;
        frameTimer = animation.frameRate;
        frameCount = animation.textureArray.Length;
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
