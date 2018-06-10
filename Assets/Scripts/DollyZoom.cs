using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyZoom : MonoBehaviour {
    public enum FovOrDistance { FOV, distance };
    [SerializeField] Transform target;
    [Header("Constrain FOV or distance?")]
    [SerializeField] FovOrDistance fovOrDistance;
    [SerializeField] float value;

    Camera cam;
    float height;
    float fov;
    float distance;
	// Use this for initialization
	void Start () {
        cam = GetComponentInParent<Camera>();
        UpdateDistance();
        UpdateFov();
        height = 2 * distance * Mathf.Tan(fov * 0.5f * Mathf.Deg2Rad);
	}
	
    void ConstrainFov(){
        distance = height * 0.5f / Mathf.Tan(fov * 0.5f * Mathf.Deg2Rad);
    }
    void ConstraintDistance(){
        fov = 2 * Mathf.Atan(height * 0.5f / distance) * Mathf.Rad2Deg;
    }
    void UpdateFov(){
        fov = cam.fieldOfView;
    }
    void UpdateDistance(){
        distance = Vector3.Distance(cam.transform.position, target.position);
    }
	// Update is called once per frame
	void Update () {
		
	}

}
