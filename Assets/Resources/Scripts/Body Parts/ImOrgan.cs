using UnityEngine;
using System.Collections;

public class ImOrganComponent : ImEntity {	
	private OrganType organType_;
	
	public ImOrganComponent(string name, OrganType type) : base(name) {
		organType_ = type;
	}
	
	public OrganType organType {
		get {return organType_;}	
	}
	
	public ImNode CorrespondingNodeInNodeLayer(ImNodeLayer nodeLayer) {
		NodePlacement nodePlacement = ImConfig.NodePlacementForOrganType(organType_);
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
