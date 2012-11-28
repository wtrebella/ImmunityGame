using UnityEngine;
using System;
using System.Collections;

public class ImAbstractBodyPartComponent {
	public ImBodyPart owner;
	public float maxHealth = 100;
	public event Action<ImAbstractBodyPartComponent> SignalHealthChanged;
	
	private float health_;
	
	public ImAbstractBodyPartComponent(ImBodyPart owner) {
		this.owner = owner;
		health_ = maxHealth;
	}
	
	virtual public string Description() {
		return "I'm an abstract body part!";
	}
	
	public float health {
		get {return health_;}
		set {
			health_ = value;
			if (health_ < 0) health_ = 0;
			if (SignalHealthChanged != null) SignalHealthChanged(this);	
		}
	}
}
