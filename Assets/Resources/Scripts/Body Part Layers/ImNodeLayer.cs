using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImNodeLayer : ImAbstractEntityLayer {	
	public ImNodeLayer(WTImmunity owner) : base(owner) {		
		for (int i = 0; i < (int)(NodePlacement.MAX - 1); i++) {
			ImNode node = new ImNode((NodePlacement)(i + 1));
			Vector2 pos = ImConfig.PositionForNodePlacement(node.nodePlacement);
			node.spriteComponent.PlaceSpriteAt(pos.x, pos.y);
			
			//node.nodeComponent.SignalHealthChanged += BodyPartHealthChanged;
			entities.Add(node);
			AddChild(node);
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
