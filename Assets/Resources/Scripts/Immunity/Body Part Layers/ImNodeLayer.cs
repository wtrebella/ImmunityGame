using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImNodeLayer : ImAbstractBodyPartLayer {	
	public ImNodeLayer(WTImmunity owner) : base(owner) {		
		if (owner.organLayer == null) {
			throw new System.ArgumentException("WTImmunity organLayer MUST be created before nodeLayer");
		}
		
		for (int i = 0; i < 20; i++) {
			ImBodyPart node = new ImBodyPart(NodeType.NormalNode, 0, 0.2f, Color.red);
			node.nodeComponent.SignalHealthChanged += BodyPartHealthChanged;
			bodyParts.Add(node);
			AddChild(node.spriteComponent.sprite);
		}
		
		// non-organ nodes
		bodyParts[0].spriteComponent.PlaceSpriteAt(-63, -25);
		bodyParts[0].nodeComponent.nodePlacement = NodePlacement.HandLeft;
		
		bodyParts[1].spriteComponent.PlaceSpriteAt(62, -22);
		bodyParts[1].nodeComponent.nodePlacement = NodePlacement.HandRight;
		
		bodyParts[2].spriteComponent.PlaceSpriteAt(50, -183);
		bodyParts[2].nodeComponent.nodePlacement = NodePlacement.FootRight;
		
		bodyParts[3].spriteComponent.PlaceSpriteAt(-35, -189);
		bodyParts[3].nodeComponent.nodePlacement = NodePlacement.FootLeft;
		
		bodyParts[4].spriteComponent.PlaceSpriteAt(-26, -91);
		bodyParts[4].nodeComponent.nodePlacement = NodePlacement.KneeLeft;
		
		bodyParts[5].spriteComponent.PlaceSpriteAt(33, -89);
		bodyParts[5].nodeComponent.nodePlacement = NodePlacement.KneeRight;
		
		bodyParts[6].spriteComponent.PlaceSpriteAt(-43, 108);
		bodyParts[6].nodeComponent.nodePlacement = NodePlacement.ShoulderLeft;
		
		bodyParts[7].spriteComponent.PlaceSpriteAt(35, 115);
		bodyParts[7].nodeComponent.nodePlacement = NodePlacement.ShoulderRight;
		
		bodyParts[8].spriteComponent.PlaceSpriteAt(-50, 43);
		bodyParts[8].nodeComponent.nodePlacement = NodePlacement.ElbowLeft;
		
		bodyParts[9].spriteComponent.PlaceSpriteAt(44, 48);
		bodyParts[9].nodeComponent.nodePlacement = NodePlacement.ElbowRight;
		
		bodyParts[10].spriteComponent.PlaceSpriteAt(-24, -27);
		bodyParts[10].nodeComponent.nodePlacement = NodePlacement.HipLeft;
		
		bodyParts[11].spriteComponent.PlaceSpriteAt(22, -23);
		bodyParts[11].nodeComponent.nodePlacement = NodePlacement.HipRight;
		
		bodyParts[12].spriteComponent.PlaceSpriteAt(-5, 136);
		bodyParts[12].nodeComponent.nodePlacement = NodePlacement.Neck;
		
		// organ nodes
		bodyParts[13].spriteComponent.PlaceSpriteAt(14, 47);
		bodyParts[13].nodeComponent.nodePlacement = NodePlacement.Stomach;
		
		bodyParts[14].spriteComponent.PlaceSpriteAt(-7, 62);
		bodyParts[14].nodeComponent.nodePlacement = NodePlacement.Liver;

		bodyParts[15].spriteComponent.PlaceSpriteAt(2, 87);
		bodyParts[15].nodeComponent.nodePlacement = NodePlacement.Heart;
		
		bodyParts[16].spriteComponent.PlaceSpriteAt(-21, 93);		
		bodyParts[16].nodeComponent.nodePlacement = NodePlacement.LungLeft;
		
		bodyParts[17].spriteComponent.PlaceSpriteAt(22, 95);
		bodyParts[17].nodeComponent.nodePlacement = NodePlacement.LungRight;
		
		bodyParts[18].spriteComponent.PlaceSpriteAt(-5, 181);
		bodyParts[18].nodeComponent.nodePlacement = NodePlacement.Brain;
		
		bodyParts[19].spriteComponent.PlaceSpriteAt(-2, 6);
		bodyParts[19].nodeComponent.nodePlacement = NodePlacement.Intestines;
	}
	
	public ImBodyPart NodeForPlacement(NodePlacement placement) {
		foreach (ImBodyPart node in bodyParts) {
			if (node.nodeComponent.nodePlacement == placement) return node;		
		}
		return null;
	}
}
