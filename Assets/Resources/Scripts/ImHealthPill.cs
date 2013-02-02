using UnityEngine;
using System.Collections;

// should make generic action class?

public class ImHealthPill : ImEntity {
	private float healthRefill_;
	
	public ImHealthPill(string name, float healthRefill) : base(name) {
		healthRefill_ = healthRefill;
	}
	
	public void PerformActionOnEntity(ImEntity targetEntity) {
		targetEntity.HealthComponent().currentHealth += healthRefill_;
	}
}
