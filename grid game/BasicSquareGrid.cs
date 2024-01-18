using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Narf
{

[ExecuteAlways]
public class BasicSquareGrid : MonoBehaviour
{

    public GameObject cloneTile;
    public GameObject gameboard;

    public List<GameObject> tiles = new List<GameObject>();

    public float padding = 0.1f;
    float m_padding = 0.1f;


    [Range(0,20)]
    public int rows = 2;
    int m_rows = 2;

    [Range(0,20)]
    public int columns = 2;
    int m_columns = 2;

    void Start(){}

    void Update(){

        if( m_columns != columns ||
            m_rows != rows ||
            m_padding != padding
        ){

            RebuildGrid();
            m_columns = columns;
            m_rows = rows;
            m_padding = padding;

        }

    }

    public void RebuildGrid(){
        ClearGrid();
        SetupTile();

        for (var ii = 0; ii < rows; ii++)
        {
            for (var pp = 0; pp < columns; pp++)
            {
                GameObject gg = SetupTile();
                gg.transform.position = new Vector3(pp * padding, 0, ii * padding );
            }
        }

    }

    public GameObject SetupTile(){
        GameObject gg = Instantiate(cloneTile, new Vector3(0, 0, 0), Quaternion.identity);
        gg.transform.parent = gameboard.transform;
        gg.SetActive(true);
        tiles.Add(gg);
        return gg;
    }


     public void ClearGrid(){

        for (var i = 0; i < tiles.Count; i++)
        {
            
            #if UNITY_EDITOR
                DestroyImmediate(tiles[i]);
            #else
                Destroy(tiles[i]);
            #endif      
        }

        tiles.Clear();

    }

    
    public void ForceClearGrid(){
        
        // eh its recomended in a while!?
        while (gameboard.transform.childCount > 0) 
        {
            DestroyImmediate(gameboard.transform.GetChild(0).gameObject);
        }
        tiles.Clear();
        RebuildGrid();
    }


}



// android errors and does not compile if this is not wrapping the editor
#if UNITY_EDITOR

[CustomEditor(typeof(BasicSquareGrid))]
public class BasicSquareGridEditor : Editor
{
	public override void OnInspectorGUI()
	{
        DrawDefaultInspector();
        
		BasicSquareGrid pick = (BasicSquareGrid)target;

		if (GUILayout.Button("ForceClearGrid", GUILayout.Height(40))) {
            pick.ForceClearGrid();
        }
		
	}

}


#endif

}
