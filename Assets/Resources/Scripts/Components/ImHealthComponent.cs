using UnityEngine;
using System.Collections;
using System;

public class ImHealthComponent : ImAbstractComponent {
	public event Action<ImAbstractComponent> SignalHealthChanged;
	
	private float currentHealth_;
	private float maxHealth_;
	
	public ImHealthComponent(string name, float maxHealth) : base(name) {
		componentType_ = ComponentType.Health;
		
		maxHealth_ = maxHealth;
		currentHealth = maxHealth;
	}
	
	public float currentHealth {
		get {return currentHealth_;}
		set {
			float prevHealth = currentHealth_;
			currentHealth_ = value;
			if (currentHealth_ < 0) currentHealth_ = 0;
			if (currentHealth_ != prevHealth) {
				if (SignalHealthChanged != null) SignalHealthChanged(this);
			}
		}
	}
	
	public float maxHealth {
		get {return maxHealth_;}	
	}
}
