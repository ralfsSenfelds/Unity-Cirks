using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScripts : MonoBehaviour
{

    public Texture2D[] cursors;
    // Start is called before the first frame update
    void Start()
    {
        DefaultCursor();
    }
    
    public void DefaultCursor()
    {
        Cursor.SetCursor(cursors[0], Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnButton()
    {
        Cursor.SetCursor(cursors[1], Vector2.zero, CursorMode.ForceSoftware);   
    }

    public void ClickedButton()
    {
        Cursor.SetCursor(cursors[2], Vector2.zero, CursorMode.ForceSoftware);
    }
}
