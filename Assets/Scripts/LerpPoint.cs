using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPoint : MonoBehaviour {
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] [Range(0.001f, 0.999f)] float towardsB = 0.5f;
    [SerializeField] bool autoUpdate;
    [SerializeField] [Range(0,1f)] float updateFrequency = 0.1f;
	

	void Start () {
        LerpPos();
        StartCoroutine(UpdatePos());
	}
	
    IEnumerator UpdatePos(){
        while (autoUpdate){
            LerpPos();
            if (updateFrequency == 0) {
                yield return null;
            } else{
                yield return new WaitForSeconds(updateFrequency);   
            }
        }
    }

    void LerpPos(){
        transform.position = Vector3.Lerp(pointA.position, pointB.position, towardsB);
    }
}
