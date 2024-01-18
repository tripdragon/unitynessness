using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
//using UnityEditorInternal;
#endif
// using UnityEngine.Events;

namespace Narf
{

//[System.Serializable]
//public class Eventy : UnityEvent<GameObject>{};
// _Eventy.Invoke(gg);

public class Tile : MonoBehaviour
{
    //    public Eventy _Eventy;
    public Color swapColor = Color.yellow;

    Color originalColor;

    MeshRenderer m_Renderer;


    void Start(){

        m_Renderer = GetComponent<MeshRenderer>();
        originalColor = m_Renderer.material.color;

    }


    public void SetSelectedState(bool val){
        if(val == true){
            m_Renderer.material.color = swapColor;
        }
        else {
            m_Renderer.material.color = originalColor;
        }
    }
    
    //void OnMouseOver()
    // public void HoverOn()
    // {
    //     m_Renderer.material.color = swapColor;
    //     // _Eventy.Invoke(transform.gameObject);
    //     //GridItem selected = new GridItem(0, transform);
    //     //_HoverSelectedEventEnter.Invoke(selected);
    // }

    // //void OnMouseExit()
    // public void HoverOff()
    // {
    //     m_Renderer.material.color = originalColor;
    //     // _Eventy.Invoke(transform.gameObject);
    // }

    void Update(){}

    public void Rebuild(){}


}



// android errors and does not compile if this is not wrapping the editor
#if UNITY_EDITOR

[CustomEditor(typeof(Tile))]
public class TileEditor : Editor
{
	public override void OnInspectorGUI()
	{
        DrawDefaultInspector();
        
		Tile pick = (Tile)target;

		// if (GUILayout.Button("Rebuild")) {
        //    pick.Rebuild();
        // }
				
		// if (GUILayout.Button("button2222", GUILayout.Height(40))) {
        //     pick.button2222();
        // }
		
	}

}


#endif

}