using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImNodeLayer : ImAbstractEntityLayer {	
	public ImNodeLayer(WTImmunity owner) : base(owner) {		
		for (int i = 0; i < (int)(NodePlacement.MAX - 1); i++) {
			ImNode node = new ImNode(0, 0.25f, new Color(0.5f, 0, 0, 1));
			// still messed up
			node.nodeComponent.nodePlacement = (NodePlacement)(i + 1);
			Vector2 pos = PositionForNodePlacement(node.nodeComponent.nodePlacement);
			node.spriteComponent.PlaceSpriteAt(pos.x, pos.y);
			
			node.nodeComponent.SignalHealthChanged += BodyPartHealthChanged;
			bodyParts.Add(node);
			AddChild(node.spriteComponent.sprite);
		}
	}
	
	public ImEntity NodeForPlacement(NodePlacement placement) {
		foreach (ImEntity entity in entities) {
			ImNode node = entity as ImNode;
			if (node.nodePlacement == placement) return node;		
		}
		return null;
	}
}
