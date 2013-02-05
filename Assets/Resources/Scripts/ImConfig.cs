using UnityEngine;
using System.Collections;

public static class ImConfig {
	public const float MAX_ZOOM = 3f;
	public const float MIN_ZOOM = 0.5f;
	
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
	
	public static string NameForNodePlacement(NodePlacement placement) {
		switch (placement) {
		case NodePlacement.Brain:
			return "node placement: brain";
		case NodePlacement.ElbowLeft:
			return "node placement: elbow left";
		case NodePlacement.ElbowRight:
			return "node placement: elbow right";
		case NodePlacement.FootLeft:
			return "node placement: foot left";
		case NodePlacement.FootRight:
			return "node placement: foot right";
		case NodePlacement.HandLeft:
			return "node placement: hand left";
		case NodePlacement.HandRight:
			return "node placement: hand right";
		case NodePlacement.Heart:
			return "node placement: heart";
		case NodePlacement.HipLeft:
			return "node placement: hip left";
		case NodePlacement.HipRight:
			return "node placement: hip right";
		case NodePlacement.Intestines:
			return "node placement: intestines";
		case NodePlacement.KneeLeft:
			return "node placement: knee left";
		case NodePlacement.KneeRight:
			return "node placement: knee right";
		case NodePlacement.Liver:
			return "node placement: liver";
		case NodePlacement.LungLeft:
			return "node placement: lung left";
		case NodePlacement.LungRight:
			return "node placement: lung right";
		case NodePlacement.Neck:
			return "node placement: neck";
		case NodePlacement.ShoulderLeft:
			return "node placement: shoulder left";
		case NodePlacement.ShoulderRight:
			return "node placement: shoulder right";
		case NodePlacement.Stomach:
			return "node placement: stomach";
		default:
			Debug.Log("Bad nodePlacement");
			return "";
		}
	}
	
	public static Vector2 PositionForNodePlacement(NodePlacement placement) {
		float maxWidth = 105 * 1.3f;
		float maxHeight = 305 * 1.3f;
		
		switch (placement) {
		case NodePlacement.Brain:
			return new Vector2(-0.076f * maxWidth, 0.99f * maxHeight);
		case NodePlacement.ElbowLeft:
			return new Vector2(-0.79f * maxWidth, 0.267f * maxHeight);
		case NodePlacement.ElbowRight:
			return new Vector2(0.695f * maxWidth, 0.262f * maxHeight);
		case NodePlacement.FootLeft:
			return new Vector2(-0.457f * maxWidth, -0.983f * maxHeight);
		case NodePlacement.FootRight:
			return new Vector2(0.79f * maxWidth, -1.0f * maxHeight);
		case NodePlacement.HandLeft:
			return new Vector2(-1.0f * maxWidth, -0.141f * maxHeight);
		case NodePlacement.HandRight:
			return new Vector2(0.981f * maxWidth, -0.121f * maxHeight);
		case NodePlacement.Heart:
			return new Vector2(0.029f * maxWidth, 0.475f * maxHeight);
		case NodePlacement.HipLeft:
			return new Vector2(-0.381f * maxWidth, -0.148f * maxHeight);
		case NodePlacement.HipRight:
			return new Vector2(0.352f * maxWidth, -0.125f * maxHeight);
		case NodePlacement.Intestines:
			return new Vector2(-0.029f * maxWidth, 0.033f * maxHeight);
		case NodePlacement.KneeLeft:
			return new Vector2(-0.41f * maxWidth, -0.498f * maxHeight);
		case NodePlacement.KneeRight:
			return new Vector2(0.524f * maxWidth, -0.485f * maxHeight);
		case NodePlacement.Liver:
			return new Vector2(-0.114f * maxWidth, 0.338f * maxHeight);
		case NodePlacement.LungLeft:
			return new Vector2(-0.333f * maxWidth, 0.508f * maxHeight);
		case NodePlacement.LungRight:
			return new Vector2(0.352f * maxWidth, 0.518f * maxHeight);
		case NodePlacement.Neck:
			return new Vector2(-0.076f * maxWidth, 0.744f * maxHeight);
		case NodePlacement.ShoulderLeft:
			return new Vector2(-0.686f * maxWidth, 0.59f * maxHeight);
		case NodePlacement.ShoulderRight:
			return new Vector2(0.552f * maxWidth, 0.63f * maxHeight);
		case NodePlacement.Stomach:
			return new Vector2(0.219f * maxWidth, 0.256f * maxHeight);
		default:
			Debug.Log("Bad nodePlacement");
			return new Vector2(0, 0);
		}
	}
}
