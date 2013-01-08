using UnityEngine;
using System.Collections;

public class ImOrgan : ImEntity {	
	private OrganType organType_;
	
	public ImOrgan(OrganType type, string name = "an organ") : base(name) {
		organType_ = type;
		
		InitSpriteComponent();
	}
	
	public OrganType organType {
		get {return organType_;}	
	}
	
	public void InitSpriteComponent() {
		string imageName = "";
		float defaultRotation = 0;
		float defaultScale = 0;
		Color color = Color.white;
		
		switch (organType_) {
		case OrganType.Brain:
			imageName = "brain.png";
			name = "organ: brain";
			defaultRotation = 0f;
			defaultScale = 1.0f;
			color = Color.magenta;
			break;
		case OrganType.Heart:
			imageName = "heart.png";
			name = "organ: heart";
			defaultRotation = -20f;
			defaultScale = 1.0f;
			color = Color.red;
			break;
		case OrganType.Intestines:
			imageName = "intestines.png";
			name = "organ: intestines";
			defaultRotation = 0f;
			defaultScale = 1.0f;
			color = Color.green;
			break;
		case OrganType.Liver:
			imageName = "liver.png";
			name = "organ: liver";
			defaultRotation = -20f;
			defaultScale = 1.0f;
			color = Color.cyan;
			break;
		case OrganType.LungLeft:
			imageName = "lungLeft.png";
			name = "organ: lung left";
			defaultRotation = 20f;
			defaultScale = 1.0f;
			color = Color.blue;
			break;
		case OrganType.LungRight:
			imageName = "lungRight.png";
			name = "organ: lung right";
			defaultRotation = -20f;
			defaultScale = 1.0f;
			color = Color.blue;
			break;
		case OrganType.Stomach:
			imageName = "stomach.png";
			name = "organ: stomach";
			defaultRotation = -30f;
			defaultScale = 1.0f;
			color = Color.yellow;
			break;
		default:
			break;
		}
		
		AddComponent(new ImSpriteComponent(imageName, defaultRotation, defaultScale, color));
	}
	
	public ImNode CorrespondingNodeInNodeLayer(ImNodeLayer nodeLayer) {
		NodePlacement nodePlacement = ImConfig.NodePlacementForOrganType(organType_);
		return nodeLayer.NodeForPlacement(nodePlacement);
	}
}
