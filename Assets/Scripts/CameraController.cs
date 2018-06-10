using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] Camera cam;
    [SerializeField] List<CameraMove> cameraMoves;

    private bool isMoving;

    public bool IsMoving{
        get { return isMoving; }
    }
	// Use this for initialization
	void Start () {
        //StartCoroutine(FOV());
		
	}
    public Camera GetCamera(){
        return cam;
    }

    public void OnMoveBegin(){
        //Turns this into a real listener
        isMoving = true;
    }
    public void OnMoveEnd(){
        
        isMoving = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isMoving && cameraMoves.Count > 0){
            cameraMoves[0].Begin();
            cameraMoves.RemoveAt(0);
        }
	}

    IEnumerator FOV(){
        while (true) {
            Debug.Log("FOV: " + cam.fieldOfView);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
