using UnityEngine;
using System.Collections;

public class ImPoisonPill : ImAbstractItem {
	private float poisonPower_;
	
	public ImPoisonPill(string name, float poisonPower) : base(name) {
		itemType = ItemType.PoisonPill;
		poisonPower_ = poisonPower;
	}
	
	override public void PerformActionOnEntity(ImEntity entity) {
		entity.HealthComponent().currentHealth -= poisonPower_;	
	}
	
	override public string Description() {
		return string.Format("{0}: -{1}", name, poisonPower_);	
	}
	
	override public bool CanBeUsedOnEntity(ImEntity targetEntity) {
		return targetEntity.HealthComponent() != null && targetEntity.HealthComponent().currentHealth > 0;
	}
}