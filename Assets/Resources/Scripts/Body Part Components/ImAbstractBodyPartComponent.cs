using UnityEngine;
using System;
using System.Collections;

public enum BodyPartComponentType {
	None,
	Sprite,
	NodePlacement,
	Health
}

public class ImAbstractBodyPartComponent {
	public float maxHealth = 100;
	public event Action<ImAbstractBodyPartComponent> SignalHealthChanged;
	
	private ImAbstractBodyPart owner_;
	private BodyPartComponentType bodyPartComponentType_;
	private string name_;	
	private float health_;
	
	public ImAbstractBodyPartComponent(ImAbstractBodyPart owner, string name, BodyPartComponentType bodyPartComponentType) {
		bodyPartComponentType_ = bodyPartComponentType;
		name_ = name;
		owner_ = owner;
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
	
	public string name {
		get {return name_;}	
	}
	
	public BodyPartComponentType bodyPartComponentType {
		get {return bodyPartComponentType_;}	
	}
	
	public ImAbstractBodyPart owner {
		get {return owner_;}	
	}
}
