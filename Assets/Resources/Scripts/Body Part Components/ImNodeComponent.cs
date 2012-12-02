using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum NodeType {
	None,
	NormalNode
}

public enum NodePlacement {
	None,
	HandLeft,
	HandRight,
	FootLeft,
	FootRight,
	KneeLeft,
	KneeRight,
	ShoulderLeft,
	ShoulderRight,
	ElbowLeft,
	ElbowRight,
	HipLeft,
	HipRight,
	Neck,
	Stomach,
	Liver,
	Heart,
	LungLeft,
	LungRight,
	Brain,
	Intestines,
	MAX
}

public class ImNodeComponent : ImAbstractBodyPartComponent {
	public NodePlacement nodePlacement = NodePlacement.None;

	private NodeType nodeType_ = NodeType.None;
	
	public ImNodeComponent(ImBodyPart owner, NodeType nodeType) : base(owner) {		
		nodeType_ = nodeType;
	}
	
	public static NodePlacement NodePlacementForOrganType(OrganType organType) {
		NodePlacement nodePlacement;
		
		switch (organType) {
		case OrganType.Brain:
			nodePlacement = NodePlacement.Brain;
			break;
		case OrganType.Heart:
			nodePlacement = NodePlacement.Heart;
			break;
		case OrganType.Intestines:
			nodePlacement = NodePlacement.Intestines;
			break;
		case OrganType.Liver:
			nodePlacement = NodePlacement.Liver;
			break;
		case OrganType.LungLeft:
			nodePlacement = NodePlacement.LungLeft;
			break;
		case OrganType.LungRight:
			nodePlacement = NodePlacement.LungRight;
			break;
		case OrganType.Stomach:
			nodePlacement = NodePlacement.Stomach;
			break;
		default:
			nodePlacement = NodePlacement.None;
			break;
		}
		
		return nodePlacement;
	}
	
	override public string Description() {
		string description = "";
		
		switch (nodeType_) {
		case NodeType.NormalNode:
			description = "Normal node";
			break;
		}
		
		return description;
	}
	
	public ImBodyPart CorrespondingOrganInOrganLayer(ImOrganLayer organLayer) {
		OrganType organType = ImOrganComponent.OrganTypeForNodePlacement(nodePlacement);
		return organLayer.OrganForType(organType);
	}
	
	public List<ImBodyPart> CorrespondingVeinsInVeinLayer(ImVeinLayer veinLayer) {
		return veinLayer.VeinsForNodePlacement(nodePlacement);
	}
	
	public NodeType nodeType {
		get {return nodeType_;}	
	}
}
