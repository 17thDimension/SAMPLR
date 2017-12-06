using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;
using Klak.UI;
public class UIReactor : MonoBehaviour {

	public UnityEvent FireRender;
	public Dropdown audioinputdropdown;
	public AudioService audioservice;
	public Klak.UI.Toggle RecordToggle;
	public Klak.UI.Toggle LoginToggle;
	public Klak.UI.Button TransmitButton;
	public UnityEngine.UI.Text status;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Arm () {
		audioservice.ArmedInput=audioinputdropdown.options[audioinputdropdown.value].text; 	
		audioservice.Arm();
	}


	public void Render(){
		audioinputdropdown.ClearOptions();
		audioinputdropdown.AddOptions(audioservice.Devices);		
		status.text = audioservice.State;
		if (audioservice.State=="Stopped"){
			RecordToggle.isOn = false;
		}
	}
}
