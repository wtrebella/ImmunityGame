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
	
	public void RemoveComponent(ImAbstractComponent component) {
		components_.Remove(component.name);
		if (SignalComponentRemoved != null) SignalComponentRemoved(component);
	}
	
	public void HandleComponentAdded(ImAbstractComponent component) {
		component.owner = this;
		
		if (component.componentType == ComponentType.Sprite) AddChild((component as ImSpriteComponent).sprite);
		if (component.componentType == ComponentType.RadialWipeSprite) AddChild((component as ImRadialWipeSpriteComponent).sprite);
		if (component.componentType == ComponentType.SliceSprite) AddChild((component as ImSliceSpriteComponent).sprite);
		if (component.componentType == ComponentType.ScrollContainer) AddChild((component as ImScrollContainerComponent).scrollContainer);
		if (component.componentType == ComponentType.ScrollBar) AddChild((component as ImScrollBarComponent).scrollBar);
		if (component.componentType == ComponentType.Label) AddChild((component as ImLabelComponent).label);
	}
	
	public void HandleComponentRemoved(ImAbstractComponent component) {
		component.owner = null;
		
		if (component.componentType == ComponentType.Sprite) RemoveChild((component as ImSpriteComponent).sprite);
		if (component.componentType == ComponentType.RadialWipeSprite) RemoveChild((component as ImRadialWipeSpriteComponent).sprite);
		if (component.componentType == ComponentType.SliceSprite) RemoveChild((component as ImSliceSpriteComponent).sprite);
		if (component.componentType == ComponentType.ScrollContainer) RemoveChild((component as ImScrollContainerComponent).scrollContainer);
		if (component.componentType == ComponentType.ScrollBar) RemoveChild((component as ImScrollBarComponent).scrollBar);
		if (component.componentType == ComponentType.Label) RemoveChild((component as ImLabelComponent).label);
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
		if (ComponentsForType(ComponentType.Sprite).Count == 0) return null;
		
		List<ImSpriteComponent> scs = new List<ImSpriteComponent>();
		foreach (ImAbstractComponent comp in ComponentsForType(ComponentType.Sprite)) scs.Add((ImSpriteComponent)comp);
		return scs;
	}
	
	public List<ImLabelComponent> LabelComponents() {
		if (ComponentsForType(ComponentType.Label).Count == 0) return null;
		
		List<ImLabelComponent> sls = new List<ImLabelComponent>();
		foreach (ImAbstractComponent comp in ComponentsForType(ComponentType.Label)) sls.Add((ImLabelComponent)comp);
		return sls;
	}
	
	public List<ImRadialWipeSpriteComponent> RadialWipeSpriteComponents() {
		if (ComponentsForType(ComponentType.RadialWipeSprite).Count == 0) return null;
		
		List<ImRadialWipeSpriteComponent> rwscs = new List<ImRadialWipeSpriteComponent>();
		foreach (ImAbstractComponent comp in ComponentsForType(ComponentType.RadialWipeSprite)) rwscs.Add((ImRadialWipeSpriteComponent)comp);
		return rwscs;
	}
	
	public List<ImSliceSpriteComponent> SliceSpriteComponents() {
		if (ComponentsForType(ComponentType.SliceSprite).Count == 0) return null;
		
		List<ImSliceSpriteComponent> sscs = new List<ImSliceSpriteComponent>();
		foreach (ImAbstractComponent comp in ComponentsForType(ComponentType.SliceSprite)) sscs.Add((ImSliceSpriteComponent)comp);
		return sscs;
	}
	
	public ImHealthComponent HealthComponent() {
		if (ComponentsForType(ComponentType.Health).Count == 0) return null;
		
		if (ComponentsForType(ComponentType.Health).Count > 1) Debug.Log("there's more than one health component attached to this object; should there be?");
		return (ImHealthComponent)ComponentsForType(ComponentType.Health)[0];	
	}
	
	public ImScrollContainerComponent ScrollContainerComponent() {
		if (ComponentsForType(ComponentType.ScrollContainer).Count == 0) return null;
		
		if (ComponentsForType(ComponentType.ScrollContainer).Count > 1) Debug.Log("there's more than one scroll component attached to this object; should there be?");
		return (ImScrollContainerComponent)ComponentsForType(ComponentType.ScrollContainer)[0];	
	}
	
	public ImScrollBarComponent ScrollBarComponent() {
		if (ComponentsForType(ComponentType.ScrollBar).Count == 0) return null;
		
		if (ComponentsForType(ComponentType.ScrollBar).Count > 1) Debug.Log("there's more than one scroll bar component attached to this object; should there be?");
		return (ImScrollBarComponent)ComponentsForType(ComponentType.ScrollBar)[0];	
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
