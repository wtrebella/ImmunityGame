//#define DEBUG

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WTImmunity : FStage, FSingleTouchableInterface {
	public ImOrganLayer organLayer;
	public ImNodeLayer nodeLayer;
	public ImVeinLayer veinLayer;
	
	private ImBodyPart currentOrgan;
	private ImUILayer uiLayer;
	private FContainer gameLayer;
	private float zoomLevel_ = 1.0f;

	public WTImmunity() : base("") {	
		gameLayer = new FContainer();
		AddChild(gameLayer);
		
		FSprite sprite = new FSprite("body.png");
		sprite.scale = 0.6f;
		sprite.x = Futile.screen.halfWidth;
		sprite.y = Futile.screen.halfHeight;
		gameLayer.AddChild(sprite);
		
		organLayer = new ImOrganLayer(this);
		organLayer.x = Futile.screen.halfWidth;
		organLayer.y = Futile.screen.halfHeight;
		gameLayer.AddChild(organLayer);
		
		veinLayer = new ImVeinLayer(this);
		veinLayer.x = Futile.screen.halfWidth;
		veinLayer.y = Futile.screen.halfHeight;
		gameLayer.AddChild(veinLayer);
		
		nodeLayer = new ImNodeLayer(this);
		nodeLayer.x = Futile.screen.halfWidth;
		nodeLayer.y = Futile.screen.halfHeight;
		gameLayer.AddChild(nodeLayer);
				
		uiLayer = new ImUILayer();
		uiLayer.zoomInButton.SignalPress += OnPressedUIButton;
		uiLayer.zoomOutButton.SignalPress += OnPressedUIButton;
		AddChild(uiLayer);
	}

	override public void HandleAddedToStage() {
		base.HandleAddedToStage();
		Futile.touchManager.AddSingleTouchTarget(this);
	}
	
	override public void HandleRemovedFromStage() {
		base.HandleRemovedFromStage();
		Futile.touchManager.RemoveSingleTouchTarget(this);
	}
	
	public void Zoom(Vector2 globalFocalPoint, float zoomLevel, bool withAnimation) {						
		zoomLevel_ = zoomLevel;
		
		float oldScale = gameLayer.scale;
		float newScale = zoomLevel;
		
		Vector2 unscaledLocalPos = gameLayer.GlobalToLocal(globalFocalPoint);
		Vector2 scaledLocalPos = new Vector2(unscaledLocalPos.x * gameLayer.scale, unscaledLocalPos.y * gameLayer.scale);
		// have to do this because the GlobalToLocal method doesn't take scale into account
		
		Vector2 transformedFocalPoint = new Vector2(newScale / oldScale * scaledLocalPos.x, newScale / oldScale * scaledLocalPos.y);
		Vector2 deltaPoint = new Vector2(scaledLocalPos.x - transformedFocalPoint.x, scaledLocalPos.y - transformedFocalPoint.y);
		
		if (!withAnimation) {
			gameLayer.scale = newScale;
			gameLayer.x += deltaPoint.x;
			gameLayer.y += deltaPoint.y;
		}
		else {
			Go.to(gameLayer, 0.3f, new TweenConfig()
				.floatProp("scale", newScale)
				.floatProp("x", gameLayer.x + deltaPoint.x)
				.floatProp("y", gameLayer.y + deltaPoint.y));
		}
	}
	
	public void OnPressedUIButton(FButton button) {
		UIButtonType buttonType = (UIButtonType)button.data;
		
		if (buttonType == UIButtonType.ZoomIn) Zoom(new Vector2(Futile.screen.halfWidth, Futile.screen.halfHeight), zoomLevel_ * 2.0f, true);
		if (buttonType == UIButtonType.ZoomOut) Zoom(new Vector2(Futile.screen.halfWidth, Futile.screen.halfHeight), zoomLevel_ * 0.5f, true);
	}
	
	public bool HandleSingleTouchBegan(FTouch touch) {		
		foreach (ImBodyPart node in nodeLayer.bodyParts) {
			if (node.spriteComponent.SpriteContainsGlobalPoint(touch.position)) {
				node.nodeComponent.health -= Random.Range(1, 50);
				return true;
			}
		}
		
		bool touchedOrgan = false;
		foreach (ImBodyPart organ in organLayer.bodyParts) {
			if (organ.spriteComponent.SpriteContainsGlobalPoint(touch.position)) {
				touchedOrgan = true;
				if (currentOrgan != null) {
					if (currentOrgan == organ) break;
					currentOrgan.isSelected = false;
					currentOrgan = null;
				}
				currentOrgan = organ;
				currentOrgan.isSelected = true;
				return true;
			}
		}
		if (!touchedOrgan && currentOrgan != null) {
			currentOrgan.isSelected = false;
			currentOrgan = null;
		}
		
		return true;
	}
	
	public void HandleSingleTouchMoved(FTouch touch) {
		gameLayer.x += touch.deltaPosition.x;
		gameLayer.y += touch.deltaPosition.y;
	}
	
	public void HandleSingleTouchEnded(FTouch touch) {

	}
	
	public void HandleSingleTouchCanceled(FTouch touch) {
		
	}
}
