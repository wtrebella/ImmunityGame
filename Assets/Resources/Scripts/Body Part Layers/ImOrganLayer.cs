using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImOrganLayer : ImAbstractBodyPartLayer {	
	public ImOrganLayer(WTImmunity owner) : base(owner) {		
		ImBodyPart heart = new ImBodyPart(OrganType.Heart, -20f, 1.0f, Color.red);
		ImBodyPart brain = new ImBodyPart(OrganType.Brain, 0f, 1.0f, Color.magenta);
		ImBodyPart liver = new ImBodyPart(OrganType.Liver, -20f, 1.0f, Color.cyan);
		ImBodyPart lungLeft = new ImBodyPart(OrganType.LungLeft, 20f, 1.0f, Color.blue);
		ImBodyPart lungRight = new ImBodyPart(OrganType.LungRight, -20f, 1.0f, Color.blue);
		ImBodyPart stomach = new ImBodyPart(OrganType.Stomach, -30f, 1.0f, Color.yellow);
		ImBodyPart intestines = new ImBodyPart(OrganType.Intestines, 0f, 1.0f, Color.green);
		
		bodyParts.Add(heart);
		bodyParts.Add(brain);
		bodyParts.Add(liver);
		bodyParts.Add(lungLeft);
		bodyParts.Add(lungRight);
		bodyParts.Add(stomach);
		bodyParts.Add(intestines);
		
		float maxWidth = 35f * 1.3f;
		float maxHeight = 302f * 1.3f;
		
		heart.spriteComponent.PlaceSpriteAt(0.086f * maxWidth, 0.474f * maxHeight);
		brain.spriteComponent.PlaceSpriteAt(-0.286f * maxWidth, 1.0f * maxHeight);
		liver.spriteComponent.PlaceSpriteAt(-0.371f * maxWidth, 0.331f * maxHeight);
		lungLeft.spriteComponent.PlaceSpriteAt(-1.0f * maxWidth, 0.503f * maxHeight);
		lungRight.spriteComponent.PlaceSpriteAt(0.943f * maxWidth, 0.52f * maxHeight);
		stomach.spriteComponent.PlaceSpriteAt(0.429f * maxWidth, 0.242f * maxHeight);
		intestines.spriteComponent.PlaceSpriteAt(-0.2f * maxWidth, 0.04f * maxHeight);

		foreach (ImBodyPart organ in bodyParts) {
			AddChild(organ.spriteComponent.sprite);
		}
	}
	
	public ImBodyPart OrganForType(OrganType type) {
		foreach (ImBodyPart organ in bodyParts) {
			if (organ.organComponent.organType == type) return organ;		
		}
		return null;
	}
}
