using UnityEngine;
using System.Collections;

public class WTPopoverDialogue : ImEntity {
	public WTScrollBar scrollBar;
	
	private float width_;
	private float height_;
	private float inset_ = 8;
	
	public WTPopoverDialogue(string name = "popover dialogue") : base(name) {
		AddComponent(new ImSliceSpriteComponent("sliceSpriteComponent", "uiPopover.psd", 100, 100, inset_, inset_, inset_, inset_));
		scrollBar = new WTScrollBar("scroll bar!");
		AddChild(scrollBar);
		
		this.width = 100f;
		this.height = 100f;
	}
	
	public float width {
		get {return width_;}
		set {
			FSliceSprite sprite = SliceSpriteComponents()[0].sprite;
			if (width_ != value) {
				width_ = value;
				sprite.width = width_;
				scrollBar.x = width_ / 2f - scrollBar.width - inset_ / 2f; // why're the insets divided by 2???
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
				scrollBar.height = height_ - inset_;
				scrollBar.y = -height_ / 2f + inset_ / 2f;
			}
		}
	}
}