//#define DEBUG

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WTImmunity : FStage, FSingleTouchableInterface {
	public ImOrganLayer organLayer;
	public ImNodeLayer nodeLayer;
	public ImVeinLayer veinLayer;
	
	private List<ImAbstractItem> inventory;
	private ImEntity currentEntityWithFocus;
	private ImOrgan currentOrgan;
	private ImUILayer uiLayer;
	private FContainer gameLayer;
	private float zoomLevel_;
	private bool isZoomed_ = false;
	private float doubleClickTimer_ = 1000.0f;
	private const float DOUBLE_CLICK_MAX_WAIT = 0.4f;
	private float MAX_GAMELAYER_SCROLL = Futile.screen.height;
	private float MIN_GAMELAYER_SCROLL = 0;
	
	ImEntity testEntity = new ImEntity("testEntity");
	
	private WTPopoverDialogue pop;
	
	public WTImmunity() : base("") {	
		Futile.AddStage(this);
		
		gameLayer = new FContainer();
		gameLayer.x = Futile.screen.halfWidth;
		gameLayer.y = Futile.screen.halfHeight;
		gameLayer.scale = 0.45f;
		zoomLevel_ = gameLayer.scale;
		AddChild(gameLayer);
		
		inventory = new List<ImAbstractItem>();
		inventory.Add(new ImHealthPill("Health Pill", 15));
		inventory.Add(new ImPoisonPill("Poison Pill", 6));
		inventory.Add(new ImPoisonPill("Poison Pill", 17));
		inventory.Add(new ImHealthPill("Health Pill", 5));	
		inventory.Add(new ImPoisonPill("Poison Pill", 30));
		inventory.Add(new ImHealthPill("Health Pill", 7));
		inventory.Add(new ImHealthPill("Health Pill", 42));			
		
		FSprite sprite = new FSprite("body.png");
		gameLayer.AddChild(sprite);
		
		organLayer = new ImOrganLayer();
		organLayer.owner = this;
		gameLayer.AddChild(organLayer);
		
		veinLayer = new ImVeinLayer();
		veinLayer.owner = this;
		gameLayer.AddChild(veinLayer);
		
		nodeLayer = new ImNodeLayer();
		nodeLayer.owner = this;
		gameLayer.AddChild(nodeLayer);
				
		/*pop = new ImPopoverDialogue(100f, 100f, 4f, PopoverTriangleDirectionType.PointingRight);
		AddChild(pop);*/
		
		pop = new WTPopoverDialogue(false, "popover!");
		pop.SignalItemUsed += HandleItemUsed;
		pop.x = Futile.screen.halfWidth;
		pop.y = Futile.screen.halfHeight;
		pop.width = 200f;
		pop.isVisible = false;
		AddChild(pop);
		
		/*WTScrollBar scrollBar = new WTScrollBar("scroll bar!");
		scrollBar.x = 400f;
		scrollBar.y = Futile.screen.halfHeight - scrollBar.mainSpriteComponent.sprite.height / 2f;
		AddChild(scrollBar);*/
		
		uiLayer = new ImUILayer();
		AddChild(uiLayer);
	}

	override public void HandleAddedToStage() {
		base.HandleAddedToStage();
		Futile.touchManager.AddSingleTouchTarget(this);
		Futile.instance.SignalUpdate += HandleUpdate;
	}
	
	override public void HandleRemovedFromStage() {
		base.HandleRemovedFromStage();
		Futile.touchManager.RemoveSingleTouchTarget(this);
		Futile.instance.SignalUpdate -= HandleUpdate;
	}
	
	public void HandleItemUsed(ImAbstractItem item) {
		inventory.Remove(item);
	}
	
	public void HandleUpdate() {
		doubleClickTimer_ += Time.fixedDeltaTime;
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
		
		float newX = gameLayer.x + deltaPoint.x;
		float newY = gameLayer.y + deltaPoint.y;
		
		if (isZoomed_) {
			newX = Futile.screen.halfWidth;
			newY = Futile.screen.halfHeight;
		}
		
		if (!withAnimation) {
			gameLayer.scale = newScale;
			gameLayer.x = newX;
			gameLayer.y = newY;
		}
		else {
			Go.to(gameLayer, 0.3f, new TweenConfig()
				.floatProp("scale", newScale)
				.floatProp("x", newX)
				.floatProp("y", newY));
		}
		
		isZoomed_ = !isZoomed_;
	}
	
	public void TestLowerHealth(ImEntity entity) {
		if (entity.HealthComponent() != null) entity.HealthComponent().currentHealth -= 10f;
	}
	
	public void TestRaiseHealth(ImEntity entity) {
		if (entity.HealthComponent() != null) entity.HealthComponent().currentHealth += 10f;
	}
	
	public void TestEnlargeSprite(ImEntity entity) {
		entity.RadialWipeSpriteComponents()[0].sprite.scale *= 2f;
	}
	
	public void TestShrinkSprite(ImEntity entity) {
		entity.RadialWipeSpriteComponents()[0].sprite.scale /= 2f;
	}
		
	public bool HandleSingleTouchBegan(FTouch touch) {
		
		if (pop != null) {
			if (pop.HandleTouchBegan(touch)) {
				currentEntityWithFocus = pop;
				return true;
			}
		}
		
		foreach (ImEntity entity in nodeLayer.entities) {
			ImNode node = entity as ImNode;
			if (node.RadialWipeSpriteComponents()[0].SpriteContainsGlobalPoint(touch.position)) {
				//node.HealthComponent().currentHealth -= Random.Range(1, 50);
				pop.isVisible = true;
				
				foreach (ImAbstractItem item in inventory) pop.AddTableCell(item.Description(), "Futile_White", node, item.PerformActionOnEntity, item);
				
				return true;
			}
		}
		
		/*bool touchedOrgan = false;
		foreach (ImEntity entity in organLayer.entities) {
			ImOrgan organ = entity as ImOrgan;
			if (organ.SpriteComponents()[0].SpriteContainsGlobalPoint(touch.position)) {
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
		}*/
		
		if (doubleClickTimer_ <= DOUBLE_CLICK_MAX_WAIT) {
			doubleClickTimer_ = 1000.0f;
			
			float newZoomLevel;
			
			if (isZoomed_) newZoomLevel = zoomLevel_ * 0.5f;
			else newZoomLevel = zoomLevel_ * 2.0f;
			
			Zoom(new Vector2(Futile.screen.halfWidth, touch.position.y), newZoomLevel, true);
		}
		else doubleClickTimer_ = 0;
		
		return true;
	}
	
	public void HandleSingleTouchMoved(FTouch touch) {
		if (currentEntityWithFocus == pop) return;
		
		if (isZoomed_) {
			float newY = gameLayer.y + touch.deltaPosition.y;
			if (newY > MAX_GAMELAYER_SCROLL) newY = MAX_GAMELAYER_SCROLL;
			if (newY < MIN_GAMELAYER_SCROLL) newY = MIN_GAMELAYER_SCROLL;
			gameLayer.y = newY;
		}
	}
	
	public void HandleSingleTouchEnded(FTouch touch) {
		currentEntityWithFocus = null;
	}
	
	public void HandleSingleTouchCanceled(FTouch touch) {
		currentEntityWithFocus = null;
	}
}
