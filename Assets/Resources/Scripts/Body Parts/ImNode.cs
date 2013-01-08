using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImNode : ImEntity {
	public NodePlacement nodePlacement = NodePlacement.None;

	//private NodeType nodeType_ = NodeType.None;
	
	public ImNode(NodePlacement nodePlacement, string name = "a node") : base(name) {		
		//nodeType_ = nodeType;
		name = string.Format("node: a node at " + ImConfig.NameForNodePlacement(nodePlacement));
		
		this.nodePlacement = nodePlacement;
		
		AddComponent(new ImSpriteComponent("circleSpriteComponent", "circle.psd", 0f, 0.25f, new Color(0.5f, 0, 0, 1)));
	}
	
	public ImOrgan CorrespondingOrganInOrganLayer(ImOrganLayer organLayer) {
		OrganType organType = ImConfig.OrganTypeForNodePlacement(nodePlacement);
		return organLayer.OrganForType(organType);
	}
	
	public List<ImVein> CorrespondingVeinsInVeinLayer(ImVeinLayer veinLayer) {
		return veinLayer.VeinsForNodePlacement(nodePlacement);
	}
	
	/*public NodeType nodeType {
		get {return nodeType_;}	
	}*/
}
