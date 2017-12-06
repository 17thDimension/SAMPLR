using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class UploadService : MonoBehaviour {

	public UnityEvent OnUploadStart;
	public UnityEvent OnUploadFinish;
	public UnityEvent OnUploadError;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Upload () {
		OnUploadStart.Invoke();
	}
	public void UploadComplete () {
		if (true){
			OnUploadFinish.Invoke();
		}else{
			OnUploadError.Invoke();
		}
	

	}

}
