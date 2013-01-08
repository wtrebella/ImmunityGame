using UnityEngine;
using System.Collections;

public static class ImConfig {
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
}
