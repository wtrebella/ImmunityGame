using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImNodeLayer : ImAbstractEntityLayer {	
	public ImNodeLayer() {		
		for (int i = 0; i < (int)(NodePlacement.MAX - 1); i++) {
			ImNode node = new ImNode((NodePlacement)(i + 1));
			Vector2 pos = ImConfig.PositionForNodePlacement(node.nodePlacement);
			node.x = pos.x;
			node.y = pos.y;
			
			node.HealthComponent().SignalHealthChanged += NodeHealthChanged;
			entities.Add(node);
			AddChild(node);
		}
	}
	
	public ImNode NodeForPlacement(NodePlacement placement) {
		foreach (ImEntity entity in entities) {
			ImNode node = entity as ImNode;
			if (node.nodePlacement == placement) return node;		
		}
		return null;
	}
	
	public void NodeHealthChanged(ImAbstractComponent ac) {
		ImNode node = (ImNode)ac.owner;
		node.SpriteComponents()[0].sprite.scale = node.HealthComponent().currentHealth / node.HealthComponent().maxHealth;
	}
}
