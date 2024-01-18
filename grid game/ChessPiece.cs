using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Collections;


namespace Narf {

[RequireComponent(typeof(Battlehub.RTCommon.ExposeToEditor))]
[RequireComponent(typeof(BoxCollider))]
public class ChessPiece : MonoBehaviour
{

    public BasicSquareGrid _BasicSquareGrid;

    public Rigidbody _r;

    // [ReadOnly]
    public bool canUseGrid = true;

    public bool isDown = false;
    
    public bool isPlaced = false;

    Tile m_Tile;


    void Start()
    {
        _r = GetComponent<Rigidbody>();
    }

    void OnMouseDown() {
        // isDown = true;    
    }

    void OnMouseUp() {
        // isDown = false;
        // CheckGrid();
        // WaitCheck();
        // StartCoroutine(WaitCheck());
    }




    private IEnumerator WaitCheck()
    {
        float duration = 0.05f; // 3 seconds you can change this to whatever you like
        float normalizedTime = 0;
        while(normalizedTime <= 1f)
        {
            //countdownImage.fillAmount = normalizedTime;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        CheckGrid();
    }

    public void CheckGrid(){

        if(canUseGrid == false ){
            return;
        }

        GameObject pick = null;
        float m_dis = 90000;
        for (var i = 0; i < _BasicSquareGrid.tiles.Count; i++)
        {

            GameObject gg = _BasicSquareGrid.tiles[i];

            float dis = Vector3.Distance(gg.transform.position, transform.position);
            if (dis < m_dis){
                pick = gg;
                m_dis = dis;
            }
            
        }
        if (pick != null){
            transform.position = pick.transform.position;
            if(m_Tile != null){
                m_Tile.SetSelectedState(false);
            }
            Tile cc = pick.GetComponent<Tile>();
            if(cc){
                cc.SetSelectedState(true);
                m_Tile = cc;  
            }
        }
    

    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0)){
            isDown = true;
            
        }
        else if (Input.GetMouseButtonUp(0)){
            isDown = false;
            CheckGrid();
        }

        if(isDown){
            CheckGrid();
        }
            
        if(isPlaced == false){
            if(_r != null){
                float speed = _r.velocity.magnitude;
                if(speed <= 0.000001f){
                    _r.isKinematic = true;
                    _r.useGravity = false;
                }
            }
        }


        
    }
}
}
