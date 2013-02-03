using UnityEngine;
using System.Collections;

public class ImHealthPill : ImAbstractItem {
	private float healthRefill_ = 0;
	
	public ImHealthPill(string name, float healthRefill) : base(name) {
		itemType = ItemType.HealthPill;
		healthRefill_ = healthRefill;
	}
	
	override public void PerformActionOnEntity(ImEntity entity) {
		entity.HealthComponent().currentHealth += healthRefill_;	
	}
	
	override public string Description() {
		return string.Format("{0}: +{1}", name, healthRefill_);	
	}
}