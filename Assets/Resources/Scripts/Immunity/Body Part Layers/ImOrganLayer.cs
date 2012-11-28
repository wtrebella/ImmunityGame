using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImOrganLayer : ImAbstractBodyPartLayer {	
	public ImOrganLayer(WTImmunity owner) : base(owner) {		
		ImBodyPart heart = new ImBodyPart(OrganType.Heart, -20f, 0.6f, Color.red);
		ImBodyPart brain = new ImBodyPart(OrganType.Brain, 0f, 0.6f, Color.magenta);
		ImBodyPart liver = new ImBodyPart(OrganType.Liver, -20f, 0.6f, Color.cyan);
		ImBodyPart lungLeft = new ImBodyPart(OrganType.LungLeft, 20f, 0.6f, Color.blue);
		ImBodyPart lungRight = new ImBodyPart(OrganType.LungRight, -20f, 0.6f, Color.blue);
		ImBodyPart stomach = new ImBodyPart(OrganType.Stomach, -30f, 0.6f, Color.yellow);
		ImBodyPart intestines = new ImBodyPart(OrganType.Intestines, 0f, 0.6f, Color.green);
		
		bodyParts.Add(heart);
		bodyParts.Add(brain);
		bodyParts.Add(liver);
		bodyParts.Add(lungLeft);
		bodyParts.Add(lungRight);
		bodyParts.Add(stomach);
		bodyParts.Add(intestines);
		
		heart.spriteComponent.PlaceSpriteAt(2f, 86f);
		brain.spriteComponent.PlaceSpriteAt(-6f, 181f);
		liver.spriteComponent.PlaceSpriteAt(-8f, 60f);
		lungLeft.spriteComponent.PlaceSpriteAt(-21f, 91f);
		lungRight.spriteComponent.PlaceSpriteAt(20f, 94f);
		stomach.spriteComponent.PlaceSpriteAt(9f, 44f);
		intestines.spriteComponent.PlaceSpriteAt(-4f, 7f);

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
