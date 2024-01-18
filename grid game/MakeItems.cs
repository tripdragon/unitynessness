using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Narf
{

public class MakeItems : MonoBehaviour
{
    public GameObject[] cloneSources;

    public GameObject spawnLocation;

    public float startOffsetY = 0.1f;
    [Range(0,1f)]
    public float speedIn = 0.4f;

    public bool isKeyDown = false;

    public bool useSpaceKey = false;

    void Start(){}

    void Update(){

        if(useSpaceKey) {
            if (Input.GetKeyDown("space"))
            {
                isKeyDown = true;
                CreateItem();
                //print("space key was pressed");
            }
            if (Input.GetKeyUp("space")){
                isKeyDown = false;
            }
        }
        
    }

    public void CreateItem(){


      GameObject gg = Instantiate(cloneSources[0], Vector3.zero, cloneSources[0].transform.rotation );

      gg.transform.position = spawnLocation.transform.position;
      Rigidbody _r = gg.GetComponent<Rigidbody>();
      if(_r){
          _r.isKinematic = false;
          _r.useGravity = true;
      }

      gg.SetActive(true);

    }


}



// android errors and does not compile if this is not wrapping the editor
#if UNITY_EDITOR

[CustomEditor(typeof(MakeItems))]
public class MakeItemsEditor : Editor
{
	public override void OnInspectorGUI()
	{
        DrawDefaultInspector();
        
		MakeItems pick = (MakeItems)target;

		if (GUILayout.Button("CreateItem")) {
      pick.CreateItem();
    }

	}

}


#endif

}
