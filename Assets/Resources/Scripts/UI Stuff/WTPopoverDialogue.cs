using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// i think i should make it so the anchor is the bottom left

public class WTPopoverDialogue : ImEntity {
	public WTScrollBar scrollBar;
	public List<ImTableCell> tableCells;
	
	private float width_;
	private float height_;
	private float inset_ = 7.5f;
	private ImSpriteComponent triangleSpriteComponent;
	
	public WTPopoverDialogue(bool withScrollBar, string name = "popover dialogue") : base(name) {
		tableCells = new List<ImTableCell>();
		
		AddComponent(new ImSliceSpriteComponent("sliceSpriteComponent", "uiPopover.psd", 10, 10, inset_, inset_, inset_, inset_));
		
		//triangleSpriteComponent = new ImSpriteComponent("triangleSpriteComponent", "popoverTriangle.psd");
		//AddComponent(triangleSpriteComponent);
		
		if (withScrollBar) {
			AddComponent(new ImScrollBarComponent("scrollBarComponent"));
		}
	}
	
	public void AddTableCell(string leftLabelString, string rightSpriteImageName, ImEntity correspondingEntity, ActionOnEntity ActionForEntity) {	
		ImTableCell tableCell = new ImTableCell("tableCell", 8f, 3f, width_ - inset_, Color.white);
		tableCells.Add(tableCell);
		tableCell.correspondingEntity = correspondingEntity;
		tableCell.ActionToPerformOnCorrespondingEntity = ActionForEntity;
		tableCell.x = inset_ / 2f - width_ / 2f;
		tableCell.AddLeftLabel("TwCen", leftLabelString, Color.black, 0.2f);
		tableCell.AddRightSprite(rightSpriteImageName, 1f);
		tableCell.rightSpriteComponent.sprite.color = Color.blue;
		AddChild(tableCell);
		
		float totalHeight = inset_;
		
		foreach (ImTableCell cell in tableCells) totalHeight += cell.height;
		
		this.height = totalHeight;
		
		RearrangeCells();
	}
	
	private void RearrangeCells() {		
		float yPositionSoFar = height_ / 2f - inset_ / 2f;
		
		foreach (ImTableCell tableCell in tableCells) {
			yPositionSoFar -= tableCell.height;
			tableCell.y = yPositionSoFar;
		}
	}
	
	public float width {
		get {return width_;}
		set {
			FSliceSprite sprite = SliceSpriteComponents()[0].sprite;
			if (width_ != value) {
				width_ = value;
				sprite.width = width_;
				if (ScrollBarComponent() != null) ScrollBarComponent().scrollBar.x = width_ / 2f - ScrollBarComponent().scrollBar.width - inset_ / 2f; // why're the insets divided by 2???
			}
		}
	}
	
	public float height {
		get {return height_;}
		set {
			FSliceSprite sprite = SliceSpriteComponents()[0].sprite;
			if (height_ != value) {
				height_ = value;
				sprite.height = height_;
				if (ScrollBarComponent() != null) {
					ScrollBarComponent().scrollBar.height = height_ - inset_;
					ScrollBarComponent().scrollBar.y = -height_ / 2f + inset_ / 2f;
				}
			}
		}
	}
	
	public bool HandleTouchBegan(FTouch touch) {
		FSliceSprite sprite = SliceSpriteComponents()[0].sprite;
		Vector2 localPos = GlobalToLocal(touch.position);
		if (sprite.localRect.Contains(localPos)) {
			foreach (ImTableCell cell in tableCells) {
				if (cell.LocalRectContainsTouch(touch)) {
					cell.RunAction();
				}
			}
			return true;
		}
		return false;
	}
	
	public float inset {
		get {return inset_;}	
	}
	
	/*public bool HandleTouchMoved(FTouch touch) {
		FSliceSprite sprite = SliceSpriteComponents()[0].sprite;
		Vector2 localPos = GlobalToLocal(touch.position);
		if (sprite.localRect.Contains(localPos)) {
			Debug.Log("touched popover");
			return true;
		}
		return false;
	}
	
	public bool HandleTouchEnded(FTouch touch) {
		FSliceSprite sprite = SliceSpriteComponents()[0].sprite;
		Vector2 localPos = GlobalToLocal(touch.position);
		if (sprite.localRect.Contains(localPos)) {
			Debug.Log("touched popover");
			return true;
		}
		return false;
	}
	
	public bool HandleTouchCanceled(FTouch touch) {
		FSliceSprite sprite = SliceSpriteComponents()[0].sprite;
		Vector2 localPos = GlobalToLocal(touch.position);
		if (sprite.localRect.Contains(localPos)) {
			Debug.Log("touched popover");
			return true;
		}
		return false;
	}*/
}