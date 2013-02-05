//#define DEBUG

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class WTImmunity : FStage, FSingleTouchableInterface {
	public static WTImmunity instance;
	
	public ImOrganLayer organLayer;
	public ImNodeLayer nodeLayer;
	public ImVeinLayer veinLayer;
	public event Action<bool> SignalPauseStateChanged;
	
	private bool isPaused = false;
	private List<ImAbstractItem> inventory;
	private ImEntity currentEntityWithFocus;
	private ImOrgan currentOrgan;
	private ImUILayer uiLayer;
	private FContainer gameLayer;
	private float zoomLevel_;
	private float doubleClickTimer_ = 1000.0f;
	private const float DOUBLE_CLICK_MAX_WAIT = 0.4f;
	private float MAX_GAMELAYER_SCROLL_X = Futile.screen.width;
	private float MIN_GAMELAYER_SCROLL_X = 0;
	private float MAX_GAMELAYER_SCROLL_Y = Futile.screen.height;
	private float MIN_GAMELAYER_SCROLL_Y = 0;
		
	private WTPopoverDialogue pop;
	
	public ImVirus testVirus = new ImVirus("testVirus");
	
	public WTImmunity() : base("") {	
		instance = this;
		
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
		pop.SignalNeedsInventoryRefresh += HandlePopoverNeedsInventoryRefresh;
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
		SignalPauseStateChanged += uiLayer.SetTransportBar;
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
	
	public void HandlePopoverNeedsInventoryRefresh(WTPopoverDialogue popover) {
		ImNode node = (ImNode)popover.correspondingEntity;
		bool hasTitle = false;
		bool hasDone = false;
		foreach (ImTableCell cell in popover.tableCells) {
			if (cell.tableCellType == TableCellType.Done) hasDone = true;
			if (cell.tableCellType == TableCellType.Title) hasTitle = true;
		}
		
		if (!hasTitle) popover.AddTableCell(ImConfig.NameForNodePlacement(node.nodePlacement), TableCellType.Title);
		
		foreach (ImAbstractItem item in inventory) {
			ImTableCell cellWithItem = null;
			foreach (ImTableCell itemCell in popover.tableCells) {
				if (itemCell.item == item) cellWithItem = itemCell;
			}
			if (cellWithItem == null && item.CanBeUsedOnEntity(popover.correspondingEntity)) popover.AddTableCell(item.Description(), "Futile_White", item, TableCellType.Item);
			if (cellWithItem != null && !item.CanBeUsedOnEntity(popover.correspondingEntity)) popover.RemoveTableCell(cellWithItem);
		}
		
		if (!hasDone) popover.AddTableCell("Done", TableCellType.Done);
	}
	
	public void HandleItemUsed(ImAbstractItem item) {
		inventory.Remove(item);
	}
	
	static float zoomLev = 2f;
	
	public void HandleUpdate() {		
		/*float newZoom = zoomLevel_;
		newZoom += Input.GetAxis("Mouse ScrollWheel");
		newZoom = Math.Min(ImConfig.MAX_ZOOM, newZoom);
		newZoom = Math.Max(ImConfig.MIN_ZOOM, newZoom);
		if (newZoom != zoomLevel_) {
			Zoom(Input.mousePosition, newZoom, false);	
		}*/
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			isPaused = !isPaused;
			if (SignalPauseStateChanged != null) SignalPauseStateChanged(isPaused);
		}
		
		if (!isPaused) {
			foreach (ImNode node in nodeLayer.entities) node.HandleUpdate();
			foreach (ImOrgan organ in organLayer.entities) organ.HandleUpdate();
			foreach (ImVein vein in veinLayer.entities) vein.HandleUpdate();
		}
	}
	
	public void Zoom(Vector2 globalFocalPoint, float zoomLevel) {								
		zoomLevel_ = zoomLevel;
		
		float min = -3000;
		float max = 3000;
		float width = max - min;
		float height = max - min;
		
		float oldScale = gameLayer.scale;
		float newScale = zoomLevel_;
		
		Vector2 localLayerOriginBeforeScale = new Vector2(min * oldScale, min * oldScale);
		Vector2 localLayerOriginAfterScale = new Vector2(min * newScale, min * newScale);
		
		Vector2 globalLayerOriginBeforeScale = gameLayer.LocalToGlobal(localLayerOriginBeforeScale);
		Vector2 globalLayerOriginAfterScale = gameLayer.LocalToGlobal(localLayerOriginAfterScale);
		
		Vector2 ratioOfFocusToOrigin = new Vector2((globalFocalPoint.x - globalLayerOriginBeforeScale.x) / (width * oldScale), (globalFocalPoint.y - globalLayerOriginBeforeScale.y) / (height * oldScale));		
		
		Vector2 globalFocusAfterScale = new Vector2(globalLayerOriginAfterScale.x + ratioOfFocusToOrigin.x * width * newScale, globalLayerOriginAfterScale.y + ratioOfFocusToOrigin.y * height * newScale);		
		
		Vector2 deltaPoint = new Vector2(globalFocusAfterScale.x - globalFocalPoint.x, globalFocusAfterScale.y - globalFocalPoint.y);
		
		gameLayer.scale = newScale;
		float newX = gameLayer.x + deltaPoint.x;
		float newY = gameLayer.y + deltaPoint.y;
		
		gameLayer.x = newX;
		gameLayer.y = newY;
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
		if (Input.GetMouseButtonDown(0)) Zoom(Input.mousePosition, zoomLev);
		
		if (zoomLev == 2f) zoomLev = 0.5f;
		else if (zoomLev == 0.5f) zoomLev = 2f;
		
		ImNode touchedNode = null;
		
		foreach (ImEntity entity in nodeLayer.entities) {
			ImNode node = entity as ImNode;
			
			if (node.ContainsGlobalPoint(touch.position)) {
				touchedNode = node;
			}
		}
		
		if (touchedNode != null) {
			touchedNode.AddComponent(new ImInfectionComponent("infectionComponent", testVirus));
			touchedNode.InfectionComponent().StartInfecting();
		}
		
		/*foreach (ImEntity entity in nodeLayer.entities) {
			ImNode node = entity as ImNode;
			
			if (node.ContainsGlobalPoint(touch.position)) {
				touchedNode = node;
			}
		}
		
		if (touchedNode != null && !pop.isShowing) pop.Show(inventory, touchedNode);
		
		if (pop != null) {
			if (pop.HandleTouchBegan(touch)) {
				currentEntityWithFocus = pop;
			}
		}*/
		
		return true;
	}
	
	public void HandleSingleTouchMoved(FTouch touch) {
		if (currentEntityWithFocus == pop) return;
		
		float newX = gameLayer.x + touch.deltaPosition.x;
		if (newX > MAX_GAMELAYER_SCROLL_X) newX = MAX_GAMELAYER_SCROLL_X;
		if (newX < MIN_GAMELAYER_SCROLL_X) newX = MIN_GAMELAYER_SCROLL_X;
		gameLayer.x = newX;
		
		float newY = gameLayer.y + touch.deltaPosition.y;
		if (newY > MAX_GAMELAYER_SCROLL_Y) newY = MAX_GAMELAYER_SCROLL_Y;
		if (newY < MIN_GAMELAYER_SCROLL_Y) newY = MIN_GAMELAYER_SCROLL_Y;
		gameLayer.y = newY;
	}
	
	public void HandleSingleTouchEnded(FTouch touch) {
		currentEntityWithFocus = null;
	}
	
	public void HandleSingleTouchCanceled(FTouch touch) {
		currentEntityWithFocus = null;
	}
}
