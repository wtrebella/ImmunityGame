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
	
	private ImBodyPart(OrganType organType, NodeType nodeType, float spriteRotation, float spriteScale, Color spriteColor) {
		bodyPartType_ = BodyPartType.None;
				
		if (organType != OrganType.None) {
			bodyPartType_ = BodyPartType.Organ;
			organComponent_ = new ImOrganComponent(this, organType);
		}
		
		if (nodeType != NodeType.None) {
			bodyPartType_ = BodyPartType.Node;
			nodeComponent_ = new ImNodeComponent(this, nodeType);
		}
		
		spriteComponent_ = new ImSpriteComponent(this, spriteRotation, spriteScale, spriteColor);
		spriteComponent_.SetImageNameWithBodyPartComponent(BodyPartComponent());
		spriteComponent_.InitSprite();
	}
	
	public ImBodyPart(OrganType organType, float spriteRotation, float spriteScale, Color spriteColor) : this(organType, NodeType.None, spriteRotation, spriteScale, spriteColor) {
		
	}
	
	public ImBodyPart(NodeType nodeType, float spriteRotation, float spriteScale, Color spriteColor) : this(OrganType.None, nodeType, spriteRotation, spriteScale, spriteColor) {
		
	}
	
	public ImAbstractBodyPartComponent BodyPartComponent() {
		ImAbstractBodyPartComponent component = null;
		
		if (bodyPartType_ == BodyPartType.Organ) component = organComponent_;
		else if (bodyPartType_ == BodyPartType.Node) component = nodeComponent_;
		
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
