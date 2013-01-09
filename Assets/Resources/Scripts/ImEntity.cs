using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ImEntity : FContainer {	
	public string name;
	
	private event Action<ImAbstractComponent> SignalComponentAdded;
	private event Action<ImAbstractComponent> SignalComponentRemoved;
	private Dictionary<string, ImAbstractComponent> components_;
	
	protected bool isSelected_ = false;
	
	public ImEntity(string name = "an entity") {
		this.name = name;
		components_ = new Dictionary<string, ImAbstractComponent>();
		
		this.SignalComponentAdded += HandleComponentAdded;
		this.SignalComponentRemoved += HandleComponentRemoved;
	}
	
	public void AddComponent(ImAbstractComponent component) {
		components_.Add(component.name, component);
		if (SignalComponentAdded != null) SignalComponentAdded(component);
	}
	
	public void HandleComponentAdded(ImAbstractComponent component) {
		component.owner = this;
		
		if (component.componentType == ComponentType.Sprite) AddChild((component as ImSpriteComponent).sprite);
		if (component.componentType == ComponentType.RadialWipe) AddChild((component as ImRadialWipeSpriteComponent).sprite);
	}
	
	public void HandleComponentRemoved(ImAbstractComponent component) {
		component.owner = null;
		
		if (component.componentType == ComponentType.Sprite) RemoveChild((component as ImSpriteComponent).sprite);
		if (component.componentType == ComponentType.RadialWipe) RemoveChild((component as ImRadialWipeSpriteComponent).sprite);
	}
	
	public List<ImAbstractComponent> ComponentsForType(ComponentType type) {
		List<ImAbstractComponent> comps = new List<ImAbstractComponent>();
		foreach (string key in components_.Keys) {
			if (components_[key].componentType == type) comps.Add(components_[key]);
		}
		return comps;
	}
	
	public ImAbstractComponent ComponentForName(string name) {
		if (components_.ContainsKey(name)) return components_[name];
		else {
			Debug.Log("no component with that name");
			return null;
		}
	}
	
	public List<ImSpriteComponent> SpriteComponents() {
		List<ImSpriteComponent> scs = new List<ImSpriteComponent>();
		foreach (ImAbstractComponent comp in ComponentsForType(ComponentType.Sprite)) scs.Add((ImSpriteComponent)comp);
		return scs;
	}
	
	public List<ImRadialWipeSpriteComponent> RadialWipeSpriteComponents() {
		List<ImRadialWipeSpriteComponent> rwscs = new List<ImRadialWipeSpriteComponent>();
		foreach (ImAbstractComponent comp in ComponentsForType(ComponentType.RadialWipe)) rwscs.Add((ImRadialWipeSpriteComponent)comp);
		return rwscs;
	}
	
	public ImHealthComponent HealthComponent() {
		return (ImHealthComponent)ComponentsForType(ComponentType.Health)[0];	
	}
	
	#region Getters/Setters
		
	public bool isSelected {
		get {
			return isSelected_;
		}
		set {
			isSelected_ = value;
			if (isSelected_) {
				SpriteComponents()[0].StartPulsatingSprite();
			}
			else {
				SpriteComponents()[0].StopPulsatingSprite();
			}
		}
	}
	
	#endregion
}
