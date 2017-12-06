using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LoginService : MonoBehaviour {

	// Use this for initialization
	public Boolean loggedin;
	public void Login(){

	}
	public void Logout(){
		
	}
	void AutoLogin(){
		this.loggedin = true;
	}


	void Start () {
		AutoLogin();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
