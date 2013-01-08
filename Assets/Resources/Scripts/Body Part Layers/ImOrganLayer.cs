using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImOrganLayer : ImAbstractEntityLayer {	
	public ImOrganLayer() {		
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
		
		heart.x = 0.086f * maxWidth;
		heart.y = 0.474f * maxHeight;
		
		brain.x = -0.286f * maxWidth;
		brain.y = 1.0f * maxHeight;
		
		liver.x = -0.371f * maxWidth;
		liver.y = 0.331f * maxHeight;
		
		lungLeft.x = -1.0f * maxWidth;
		lungLeft.y = 0.503f * maxHeight;
		
		lungRight.x = 0.943f * maxWidth;
		lungRight.y = 0.52f * maxHeight;
		
		stomach.x = 0.429f * maxWidth;
		stomach.y = 0.242f * maxHeight;
		
		intestines.x = -0.2f * maxWidth;
		intestines.y = 0.04f * maxHeight;
	}
	
	public ImOrgan OrganForType(OrganType type) {
		foreach (ImEntity entity in entities) {
			ImOrgan organ = entity as ImOrgan;
			if (organ.organType == type) return organ;		
		}
		return null;
	}
}
