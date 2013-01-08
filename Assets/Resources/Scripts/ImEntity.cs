using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ImEntity : FContainer {	
	private event Action<ImAbstractComponent> SignalComponentAdded;
	private event Action<ImAbstractComponent> SignalComponentRemoved;
	private Dictionary<string, ImAbstractComponent> components_;
	private string name_;
	
	protected bool isSelected_ = false;
	
	private ImEntity(string name) {
		name_ = name;
		components_ = new Dictionary<string, ImAbstractComponent>();
		
		this.SignalComponentAdded += HandleComponentAdded;
		this.SignalComponentRemoved += HandleComponentRemoved;
	}
	
	public void AddComponent(ImAbstractComponent component) {
		components_.Add(component.name, component);
		if (SignalComponentAdded) SignalComponentAdded(component);
	}
	
	public void HandleComponentAdded(ImAbstractComponent component) {
		component.owner = this;
		
		if (component.componentType == ComponentType.Sprite) AddChild((component as ImSpriteComponent).sprite);
	}
	
	public void HandleComponentRemoved(ImAbstractComponent component) {
		component.owner = null;
		
		if (component.componentType == ComponentType.Sprite) RemoveChild((component as ImSpriteComponent).sprite);
	}
	
	public Dictionary<string, ImAbstractComponent> ComponentsForType(ComponentType type) {
		Dictionary<string, ImAbstractComponent> dict = new Dictionary<string, ImAbstractComponent>();
		foreach (string key in components_.Keys) {
			if (components_[key].componentType == type) dict.Add(key, components_[key]);
		}
		return dict;
	}
	
	public ImAbstractComponent ComponentForName(string name) {
		if (components_.ContainsKey(name)) return components_[name];
		else {
			Debug.Log("no component with that name");
			return null;
		}
	}
	
	#region Getters/Setters
		
	public BodyPartType bodyPartType {
		get {return bodyPartType_;}	
	}
	
	public string name {
		get {return name_;}	
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
