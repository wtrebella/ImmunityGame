using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImAbstractBodyPartLayer : FContainer {
	public List<ImBodyPart> bodyParts;
	public WTImmunity owner;
	
	public ImAbstractBodyPartLayer(WTImmunity owner) {
		this.owner = owner;
		bodyParts = new List<ImBodyPart>();
	}
	
	public void BodyPartHealthChanged(ImAbstractBodyPartComponent bodyPartComponent) {
		ImBodyPart bodyPart = bodyPartComponent.owner;
		BodyPartType bodyPartType = bodyPart.bodyPartType;
		
		if (bodyPartType != BodyPartType.Node) return;
		
		float healthPercent = bodyPart.nodeComponent.health / bodyPart.nodeComponent.maxHealth;
		float newScale = healthPercent * bodyPart.spriteComponent.defaultSpriteScale;
		float deltaScale = Mathf.Abs(bodyPart.spriteComponent.sprite.scale - newScale);
		Go.killAllTweensWithTarget(bodyPart.spriteComponent.sprite);
		Go.to(bodyPart.spriteComponent.sprite, deltaScale, new TweenConfig()
			.floatProp("scale", newScale)
			.setEaseType(EaseType.Linear));
	}
}
