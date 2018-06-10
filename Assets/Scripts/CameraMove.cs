using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public enum Move { linear, geometric, off };

    [Header("Zoom")]
    [SerializeField] Move zoomType;
    [SerializeField] [Range(10, 180)] float targetFOV = 60;
    [SerializeField] [Range(0.1f, 10)] float zoomTime = 1;

    [Header("Movement")]
    [SerializeField] Move moveType;
    [SerializeField] Vector3 destination;
    [SerializeField] Transform destinationObject;
    [SerializeField] [Range(0.1f, 10)] float moveTime = 1;

    [Header("Tracking")]
    [SerializeField] bool trackObject;
    [SerializeField] GameObject target;

    [Header("Panning")]

    protected Camera cam;
    float totalDegrees;
    float degreesPerSecond;
    Vector3 towards;
    Vector3 start;
    bool moveComplete;
    bool zoomComplete;
    bool panComplete;

    protected virtual void Start() {
        cam = GetComponentInParent<CameraController>().GetCamera();
        if (destinationObject != null){
            destination = destinationObject.transform.position;
        }

    }

    protected virtual void OnBegin(){
        GetComponentInParent<CameraController>().OnMoveBegin();
        //Announce start
    }
    protected virtual void OnComplete(){
        //Announce completion
        GetComponentInParent<CameraController>().OnMoveEnd();
        Destroy(this);
    }
    public virtual void Begin(){
        totalDegrees = targetFOV - cam.fieldOfView;
        degreesPerSecond = totalDegrees / zoomTime;
        totalDegrees = Mathf.Abs(totalDegrees);
        start = cam.transform.position;
        //towards = Vector3.Lerp(cam.transform.position, destination, moveTime);
        OnBegin();
        Debug.Log(this + " beginning.");
        StartCoroutine(LinearZoom());
        StartCoroutine(LinearMove());
    }

    void Update(){
        if (zoomComplete && moveComplete){
            OnComplete();
        }
        if (destinationObject != null) {
            destination = destinationObject.transform.position;
        }
    }

    IEnumerator LinearMove(){
        float tickTock = 0f;
        while (tickTock <= moveTime){
            towards = Vector3.Lerp(start, destination, (tickTock / moveTime));
            cam.transform.position = towards;// * (tickTock / moveTime);// * Time.deltaTime;
            tickTock += Time.deltaTime;
            if (trackObject){
                cam.transform.LookAt(target.transform);
            }
            yield return null;
        }
        cam.transform.position = destination;
        moveComplete = true;
    }

    IEnumerator LinearZoom(){
        float tickTock = 0f;
        while (tickTock <= zoomTime){
            cam.fieldOfView += degreesPerSecond * Time.deltaTime;
            tickTock += Time.deltaTime;
            yield return null;
        }
        cam.fieldOfView = targetFOV;
        zoomComplete = true;
    }

    IEnumerator GeometricMove(){
        float tickTock = 0f;
        while (tickTock <= moveTime){

            yield return null;
        }
    }
}
