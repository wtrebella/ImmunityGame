using UnityEngine;
using System.Collections;

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
	Intestines
}

public class ImNodeComponent : ImAbstractBodyPartComponent {
	public ImBodyPart correspondingOrgan;
	public NodePlacement nodePlacement = NodePlacement.None;

	private NodeType nodeType_ = NodeType.None;
	
	public ImNodeComponent(ImBodyPart owner, NodeType nodeType) : base(owner) {		
		nodeType_ = nodeType;
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
	
	public NodeType nodeType {
		get {return nodeType_;}	
	}
}
