using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImOrganLayer : ImAbstractEntityLayer {	
	public ImOrganLayer(WTImmunity owner) : base(owner) {		
		ImOrgan heart = new ImOrgan(OrganType.Heart);
		ImOrgan brain = new ImOrgan(OrganType.Brain);
		ImOrgan liver = new ImOrgan(OrganType.Liver);
		ImOrgan lungLeft = new ImOrgan(OrganType.LungLeft);
		ImOrgan lungRight = new ImOrgan(OrganType.LungRight);
		ImOrgan stomach = new ImOrgan(OrganType.Stomach);
		ImOrgan intestines = new ImOrgan(OrganType.Intestines);
		
		entities.Add(heart);
		entities.Add(brain);
		entities.Add(liver);
		entities.Add(lungLeft);
		entities.Add(lungRight);
		entities.Add(stomach);
		entities.Add(intestines);
		
		foreach (ImEntity entity in entities) AddChild(entity);
		
		float maxWidth = 35f * 1.3f;
		float maxHeight = 302f * 1.3f;
		
		heart.ComponentsForType(ComponentType.Sprite)[0].PlaceSpriteAt(0.086f * maxWidth, 0.474f * maxHeight);
		brain.ComponentsForType(ComponentType.Sprite)[0].PlaceSpriteAt(-0.286f * maxWidth, 1.0f * maxHeight);
		liver.ComponentsForType(ComponentType.Sprite)[0].PlaceSpriteAt(-0.371f * maxWidth, 0.331f * maxHeight);
		lungLeft.ComponentsForType(ComponentType.Sprite)[0].PlaceSpriteAt(-1.0f * maxWidth, 0.503f * maxHeight);
		lungRight.ComponentsForType(ComponentType.Sprite)[0].PlaceSpriteAt(0.943f * maxWidth, 0.52f * maxHeight);
		stomach.ComponentsForType(ComponentType.Sprite)[0].PlaceSpriteAt(0.429f * maxWidth, 0.242f * maxHeight);
		intestines.ComponentsForType(ComponentType.Sprite)[0].PlaceSpriteAt(-0.2f * maxWidth, 0.04f * maxHeight);
	}
	
	public ImOrgan OrganForType(OrganType type) {
		foreach (ImEntity entity in entities) {
			ImOrgan organ = entity as ImOrgan;
			if (organ.organType == type) return organ;		
		}
		return null;
	}
}
