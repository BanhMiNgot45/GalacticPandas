using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

	//private GameObject center;
	private Vector3 lerpTargetPos;
	private Quaternion lerpTargetRot;
	Transform endParent;
	private float lerpTime = 1;
	private int elapsedFrames = 0;

    // Start is called before the first frame update
    void Start()
    {
        var center = GameObject.Find("CenterPivot").transform.Find("CameraStand");
		MoveToStand(center,10);

    }

    // Update is called once per frame
    void Update()
    {
        //center.transform.Rotate(0,1,0,Space.Self);


	if(lerpTime>0){

	float ratio = (float)elapsedFrames /lerpTime;
		transform.position = Vector3.Lerp(transform.position,lerpTargetPos,ratio);
		transform.rotation = Quaternion.Lerp(transform.rotation,lerpTargetRot,ratio);
		if(ratio==1){
		lerpTime=0;
		
		transform.parent = endParent;
		
		}
	}else{
		
		
	}


	elapsedFrames++;

    }

	void MoveToStand(Vector3 position,Quaternion rotation,float time,Transform parent){

		lerpTargetPos = position;	
		lerpTargetRot = rotation;	
		lerpTime = time;

		endParent=parent;
	}
	
	void MoveToStand(Transform target,float time,Transform endParent){

		MoveToStand(target.position,target.rotation,time,endParent);

	}
	
	public void MoveToStand(Transform target,float time){
		
		MoveToStand(target,time,target);
		
	}



}
