using UnityEngine;
using System.Collections;

public abstract class Itens : MonoBehaviour {
	public Status status; 
	// Use this for initialization
	void Start () {
		status.ataque = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
