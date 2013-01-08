using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImNode : ImEntity {
	public NodePlacement nodePlacement = NodePlacement.None;

	//private NodeType nodeType_ = NodeType.None;
	
	public ImNode(string name) : base(name) {		
		//nodeType_ = nodeType;
	}
	
	override public string Description() {
		string description = "";
		
		/*switch (nodeType_) {
		case NodeType.NormalNode:
			description = "Normal node";
			break;
		}*/
		
		return description;
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
