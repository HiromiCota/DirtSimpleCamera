//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Zoom : MonoBehaviour {
    
//    [SerializeField] [Range (1f,180f)]float targetFOV = 135;
//    [SerializeField] [Range(0.01f, 10f)] float seconds = 1;
//    [SerializeField] [Range(10f, 200f)] float smoothness = 100f;
//    float startingFOV;

//    float totalChange;
//    float degreesPerSecond;
//    float tickLength;
//    bool isStarting = true;
//    bool zoomIn;
//    bool isDone;
//    private string nope = "Not implemented";


//    void Start() {
//        cam = GetComponentInParent<CameraController>().GetCamera();
//        tickLength = 1f / smoothness;

//    }

//    public void Begin(){
//        startingFOV = cam.fieldOfView;
//        totalChange = targetFOV - startingFOV;
//        degreesPerSecond = totalChange / seconds;
//        totalChange = Mathf.Abs(totalChange);
//        if (startingFOV > targetFOV) {
//            zoomIn = true;
//        } else {
//            zoomIn = false;
//        }
//        //Moving! Send event!
//        GetComponentInParent<CameraController>().OnMoveBegin();      
//        Movement(targetFOV, moveIn);

//    }
//    // Update is called once per frame
//    void Update () {
//        if (isDone) {
//            Destroy(this);
//        } 
//	}

//    void Movement(float target, Move move){
//        switch(move){
//            case Move.geometric:{
//                    Debug.Log("Geometric zoom" + nope);
//                    break;
//                }
//            case Move.linear:{
//                    StartCoroutine(Linear(target));
//                    break;
//                }
//            default:{
//                    break;
//                }
//        }
//    }

//    IEnumerator Linear(float target){
//        int ticks = (int)((smoothness) * seconds);
//        for (int i = 0; i < ticks; i++){    
//            cam.fieldOfView += degreesPerSecond / smoothness;
//            yield return new WaitForSecondsRealtime(tickLength);
//        }
//        isDone = true;
//    }
//    private void OnDestroy() {
//        // No longer moving! Send event.
//        GetComponentInParent<CameraController>().OnMoveEnd();

//    }
//}
