using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;

public class AudioService : MonoBehaviour {

	public AudioClip Sample;
	public AudioSource IO;
	public String RecordingInput;
	public String ArmedInput;
	public String ArmedOutput;
	public List<String> Devices = new List<String>();
	public UnityEvent OnStateChange;
	public String State;
	public bool Authorized;
	public bool Recording;
	public bool Armed;

	public void SetState(String state){
		State=state;
		Debug.Log(state);
		OnStateChange.Invoke();
	}
	public void Play(){
		if (Recording){
			Stop();
		}
		IO.clip = Sample;
		IO.Play();
		SetState("Playing");
	}

	public void Arm(){
		Armed=true;
		Devices.Clear();
		foreach (string device in Microphone.devices) {
			if (String.IsNullOrEmpty(ArmedInput)){
				ArmedInput = device;
			}
			Devices.Add(device);
        }
		SetState("Armed");
		Debug.Log(ArmedInput);
	}

	public void ArmInput(int index){
		//Dangerops protect this
		ArmedInput =Devices[index];
		Arm();
	}

	public void Record(){
        Sample = Microphone.Start(ArmedInput, true, 10, 44100);		
		RecordingInput = ArmedInput;
		Recording=true;
		SetState("Recording...");
		Debug.Log("VIA "+RecordingInput);
	}
	public void Stop(){
		SetState("Stopped");
		Recording=false;
		if (Microphone.IsRecording(RecordingInput)){
	        Microphone.End(RecordingInput);
		}
	}
	public void Erase(){
		SetState("Erased");
	}


	public void RequestPermission(){
		Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);
    	if (Application.HasUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone)) {
			this.Authorized = true;
			Arm();

    	} else {
			Console.WriteLine("Permission Denied");
			this.Authorized = false;    	
    	}
	}
	void Initialize(){
		AudioSettings.GetConfiguration();
		Debug.Log(AudioSettings.speakerMode.ToString());
	}

	// Use this for initialization
	void Start () {
  	 	RequestPermission();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
