using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BodyPartType {
	None,
	Node,
	Bone,
	Vein,
	Artery,
	Muscle,
	Organ,
	Limb
}

public class ImBodyPart {
	protected bool isSelected_ = false;
	
	private BodyPartType bodyPartType_;
	
	private ImSpriteComponent spriteComponent_;
	private ImOrganComponent organComponent_;
	private ImNodeComponent nodeComponent_;
	private ImVeinComponent veinComponent_;
	
	private ImBodyPart(OrganType organType, NodeType nodeType, VeinEndpoints veinEndpoints, float spriteRotation, float spriteScale, Color spriteColor) {
		bodyPartType_ = BodyPartType.None;
				
		if (organType != OrganType.None) {
			bodyPartType_ = BodyPartType.Organ;
			organComponent_ = new ImOrganComponent(this, organType);
		}
		
		if (nodeType != NodeType.None) {
			bodyPartType_ = BodyPartType.Node;
			nodeComponent_ = new ImNodeComponent(this, nodeType);
		}
		
		if (!(veinEndpoints.fromNodePlacement == NodePlacement.None && veinEndpoints.toNodePlacement == NodePlacement.None)) {
			bodyPartType_ = BodyPartType.Vein;
			veinComponent_ = new ImVeinComponent(this, veinEndpoints);
		}
		
		spriteComponent_ = new ImSpriteComponent(this, spriteRotation, spriteScale, spriteColor);
		spriteComponent_.InitSprite(BodyPartComponent());
	}
	
	public ImBodyPart(OrganType organType, float spriteRotation, float spriteScale, Color spriteColor) : this(organType, NodeType.None, new VeinEndpoints(NodePlacement.None, NodePlacement.None), spriteRotation, spriteScale, spriteColor) {
		
	}
	
	public ImBodyPart(NodeType nodeType, float spriteRotation, float spriteScale, Color spriteColor) : this(OrganType.None, nodeType, new VeinEndpoints(NodePlacement.None, NodePlacement.None), spriteRotation, spriteScale, spriteColor) {
		
	}
	
	public ImBodyPart(VeinEndpoints veinEndpoints, Color spriteColor) : this(OrganType.None, NodeType.None, veinEndpoints, 0f, 1f, spriteColor) {
		
	}
	
	public ImAbstractBodyPartComponent BodyPartComponent() {
		ImAbstractBodyPartComponent component = null;
		
		if (bodyPartType_ == BodyPartType.Organ) component = organComponent_;
		else if (bodyPartType_ == BodyPartType.Node) component = nodeComponent_;
		else if (bodyPartType_ == BodyPartType.Vein) component = veinComponent_;
		
		return component;
	}
	
	#region Getters/Setters
	
	public BodyPartType bodyPartType {
		get {return bodyPartType_;}	
	}
	
	public ImOrganComponent organComponent {
		get {return organComponent_;}	
	}
	
	public ImNodeComponent nodeComponent {
		get {return nodeComponent_;}
	}
	
	public ImSpriteComponent spriteComponent {
		get {return spriteComponent_;}	
	}
	
	public ImVeinComponent veinComponent {
		get {return veinComponent_;}	
	}
		
	public bool isSelected {
		get {
			return isSelected_;
		}
		set {
			isSelected_ = value;
			if (isSelected_) {
				spriteComponent_.StartPulsatingSprite();
			}
			else {
				spriteComponent_.StopPulsatingSprite();
			}
		}
	}
	
	#endregion
}
