using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImNode : ImEntity {
	public NodePlacement nodePlacement = NodePlacement.None;
	
	public ImNode(NodePlacement nodePlacement, string name = "a node") : base(name) {		
		name = string.Format("node: a node at " + ImConfig.NameForNodePlacement(nodePlacement));
		
		this.nodePlacement = nodePlacement;
		ImRadialWipeSpriteComponent ssc = new ImRadialWipeSpriteComponent("circleRadialWipeComponent", "circle.psd");
		ssc.sprite.scale = 0.25f;
		ssc.sprite.color = Color.red;
		AddComponent(ssc);
		
		AddComponent(new ImHealthComponent("healthComponent", 100));
	}
	
	public ImOrgan CorrespondingOrganInOrganLayer(ImOrganLayer organLayer) {
		OrganType organType = ImConfig.OrganTypeForNodePlacement(nodePlacement);
		return organLayer.OrganForType(organType);
	}
	
	public List<ImVein> CorrespondingVeinsInVeinLayer(ImVeinLayer veinLayer) {
		return veinLayer.VeinsForNodePlacement(nodePlacement);
	}
}
