using UnityEngine;
using System.Collections;

public class ImAbstractItem : ImEntity {
	public ItemType itemType = ItemType.Abstract;
	
	public ImAbstractItem(string name) : base(name) {
		
	}
	
	virtual public void PerformActionOnEntity(ImEntity targetEntity) {
		
	}
	
	virtual public bool CanBeUsedOnEntity(ImEntity targetEntity) {
		return true;
	}
	
	virtual public string Description() {
		return "Abstract description";
	}
}
