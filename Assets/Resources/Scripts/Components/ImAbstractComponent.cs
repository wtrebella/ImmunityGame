using UnityEngine;
using System;
using System.Collections;

public class ImAbstractComponent {
	public ImEntity owner;
	
	protected ComponentType componentType_;
	
	private string name_;
		
	public ImAbstractComponent(string name) {
		name_ = name;
	}
	
	public string name {
		get {return name_;}	
	}
	
	public ComponentType componentType {
		get {return componentType_;}	
	}
}
