using UnityEngine;
using System.Collections;

public class TextBubble : MonoBehaviour
{
    TextBubble bubble;

    protected string bubbleString = "Set Me";
    //this game object's transform  
    private Transform goTransform;  
    //the game object's position on the screen, in pixels  
    private Vector3 goScreenPos;  
    //the game objects position on the screen  
    private Vector3 goViewportPos;  
  
    //the width of the speech bubble  
    public int bubbleWidth = 200;  
    //the height of the speech bubble  
    public int bubbleHeight = 100;  
  
    //an offset, to better position the bubble  
    public float offsetX = 0;  
    public float offsetY = 150;  
  
    //an offset to center the bubble  
    private int centerOffsetX;  
    private int centerOffsetY;  
  
    //a material to render the triangular part of the speech balloon  
    public Material mat;  
    //a guiSkin, to render the round part of the speech balloon  
    public GUISkin guiSkin;  
  
    public IEnumerator UseTextBubble(string _string, float _duration, int _width, int _height)
    {
        SetSize(_width, _height);
        SetString(_string);
        yield return new WaitForSeconds(_duration);
        bubble.enabled = false;
    }

    public void SetString(string _string)
    {
        bubbleString = _string;
    }

    public void SetSize(int _width, int _height)
    {
        bubbleWidth = _width;
        bubbleHeight = _width;
    }

    //use this for early initialization  
    void Awake ()  
    {  
        //get this game object's transform  
        goTransform = this.GetComponent<Transform>();  
    }  
  
    //use this for initialization  
    void Start()  
    {
        bubble = GetComponent<TextBubble>();
        //Calculate the X and Y offsets to center the speech balloon exactly on the center of the game object  
        centerOffsetX = bubbleWidth/2;  
        centerOffsetY = bubbleHeight/2;  
    }  
  
    //Called once per frame, after the update  
    void LateUpdate()  
    {  
        //find out the position on the screen of this game object  
        goScreenPos = Camera.main.WorldToScreenPoint(goTransform.position);   
  
        //Could have used the following line, instead of lines 70 and 71  
        //goViewportPos = Camera.main.WorldToViewportPoint(goTransform.position);  
        goViewportPos.x = goScreenPos.x/(float)Screen.width;  
        goViewportPos.y = goScreenPos.y/(float)Screen.height;  
    }  
  
    //Draw GUIs  
    void OnGUI()  
    {  
        //Begin the GUI group centering the speech bubble at the same position of this game object. After that, apply the offset  
        GUI.BeginGroup(new Rect(goScreenPos.x-centerOffsetX-offsetX,Screen.height-goScreenPos.y-centerOffsetY-offsetY,bubbleWidth,bubbleHeight));  
  
            //Render the round part of the bubble  
            GUI.Label(new Rect(0,0,bubbleWidth,bubbleHeight),"",guiSkin.customStyles[0]);  
  
            //Render the text  
            GUI.Label(new Rect(10,25,bubbleWidth - 10,bubbleHeight - 30), bubbleString, guiSkin.label);  
    
        GUI.EndGroup();  
    }  
  
    //Called after camera has finished rendering the scene  
    void OnRenderObject()  
    {  
        //push current matrix into the matrix stack  
        GL.PushMatrix();  
        //set material pass  
        mat.SetPass(0);  
        //load orthogonal projection matrix  
        GL.LoadOrtho();  
        //a triangle primitive is going to be rendered  
        GL.Begin(GL.TRIANGLES);  
  
            //set the color  
            GL.Color(Color.white);  
  
            //Define the triangle vetices  
            GL.Vertex3(goViewportPos.x, goViewportPos.y+(offsetY/2)/Screen.height, 0.1f);  
            GL.Vertex3(goViewportPos.x - (bubbleWidth/3)/(float)Screen.width, goViewportPos.y+offsetY/Screen.height, 0.1f);  
            GL.Vertex3(goViewportPos.x - (bubbleWidth/8)/(float)Screen.width, goViewportPos.y+offsetY/Screen.height, 0.1f);  
  
        GL.End();  
        //pop the orthogonal matrix from the stack  
        GL.PopMatrix();  
    }
}
