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
	public ImBodyPart correspondingNode;
	
	private OrganType organType_;
	
	public ImOrganComponent(ImBodyPart owner, OrganType organType) : base(owner) {
		organType_ = organType;
	}
	
	public OrganType organType {
		get {return organType_;}	
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
