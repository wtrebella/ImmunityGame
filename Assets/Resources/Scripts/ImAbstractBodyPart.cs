using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

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

public class ImAbstractBodyPart {
	protected bool isSelected_ = false;
	
	private event Action<ImAbstractBodyPartComponent> SignalComponentAdded;
	private event Action<ImAbstractBodyPartComponent> SignalComponentRemoved;
	private Dictionary<string, ImAbstractBodyPartComponent> components_;
	private BodyPartType bodyPartType_;
	private ImSpriteComponent spriteComponent_;
	private ImOrganComponent organComponent_;
	private ImNodeComponent nodeComponent_;
	private ImVeinComponent veinComponent_;

	private ImAbstractBodyPart(OrganType organType, NodeType nodeType, VeinEndpoints veinEndpoints, float spriteRotation, float spriteScale, Color spriteColor) {
		components_ = new Dictionary<string, ImAbstractBodyPartComponent>();
		
		this.SignalComponentAdded += HandleComponentAdded;
		this.SignalComponentRemoved += HandleComponentRemoved;
		
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
	
	public void AddComponent(ImAbstractBodyPartComponent component) {
		components_.Add(component.name, component);
		if (SignalComponentAdded) SignalComponentAdded(component);
	}
	
	public void HandleComponentAdded(ImAbstractBodyPartComponent component) {
		
	}
	
	public void HandleComponentRemoved(ImAbstractBodyPartComponent component) {
		
	}
	
	public List<ImAbstractBodyPartComponent> ComponentsForType() {
		// should this return a dictionary?
	}

	// add a ComponentForName thingy
	
	public ImAbstractBodyPartComponent BodyPartComponent() {
		ImAbstractBodyPartComponent component = null;
		
		if (bodyPartType_ == BodyPartType.Organ) component = organComponent_;
		else if (bodyPartType_ == BodyPartType.Node) component = nodeComponent_;
		else if (bodyPartType_ == BodyPartType.Vein) component = veinComponent_;
		
		return component;
	}
	
	#region Getters/Setters
	
	// fix/delete all these babies
	
	public BodyPartType bodyPartType {
		get {return bodyPartType_;}	
	}
	
	public ImOrganComponent OrganComponent() {
		return organComponent_;	
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
