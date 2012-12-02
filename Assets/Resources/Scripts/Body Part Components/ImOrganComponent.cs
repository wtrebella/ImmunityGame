using UnityEngine;
using System.Collections;

public enum OrganType {
	None,
	Heart,
	Brain,
	Intestines,
	LungLeft,
	LungRight,
	Liver,
	Stomach
}

public class ImOrganComponent : ImAbstractBodyPartComponent {	
	private OrganType organType_;
	
	public ImOrganComponent(ImBodyPart owner, OrganType organType) : base(owner) {
		organType_ = organType;
	}
	
	public OrganType organType {
		get {return organType_;}	
	}
	
	public static OrganType OrganTypeForNodePlacement(NodePlacement nodePlacement) {
		OrganType organType;
		
		switch (nodePlacement) {
		case NodePlacement.Brain:
			organType = OrganType.Brain;
			break;
		case NodePlacement.Heart:
			organType = OrganType.Heart;
			break;
		case NodePlacement.Intestines:
			organType = OrganType.Intestines;
			break;
		case NodePlacement.Liver:
			organType = OrganType.Liver;
			break;
		case NodePlacement.LungLeft:
			organType = OrganType.LungLeft;
			break;
		case NodePlacement.LungRight:
			organType = OrganType.LungRight;
			break;
		case NodePlacement.Stomach:
			organType = OrganType.Stomach;
			break;
		default:
			organType = OrganType.None;
			break;
		}
		
		return organType;
	}
	
	public ImBodyPart CorrespondingNodeInNodeLayer(ImNodeLayer nodeLayer) {
		NodePlacement nodePlacement = ImNodeComponent.NodePlacementForOrganType(organType_);
		return nodeLayer.NodeForPlacement(nodePlacement);
	}
	
	override public string Description() {
		string description = "";
		
		switch (organType_) {
		case OrganType.Brain:
			description = "Brain";
			break;
		case OrganType.Heart:
			description = "Heart";
			break;
		case OrganType.Intestines:
			description = "Intestines";
			break;
		case OrganType.Liver:
			description = "Liver";
			break;
		case OrganType.LungLeft:
			description = "LungLeft";
			break;
		case OrganType.LungRight:
			description = "LungRight";
			break;
		case OrganType.None:
			description = "None";
			break;
		case OrganType.Stomach:
			description = "Stomach";
			break;
		}
		
		return description;
	}
}
