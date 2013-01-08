using UnityEngine;
using System;
using System.Collections;

public class ImAbstractComponent {
	//public float maxHealth = 100;
	//public event Action<ImAbstractComponent> SignalHealthChanged;
	
	public ImEntity owner;
	
	protected ComponentType componentType_;
	
	private string name_;
	
	//private float health_;
	
	public ImAbstractComponent(string name) {
		name_ = name;
		//health_ = maxHealth;
	}
	
	/*public float health {
		get {return health_;}
		set {
			health_ = value;
			if (health_ < 0) health_ = 0;
			if (SignalHealthChanged != null) SignalHealthChanged(this);	
		}
	}*/
	
	public string name {
		get {return name_;}	
	}
	
	public ComponentType componentType {
		get {return componentType_;}	
	}
}
