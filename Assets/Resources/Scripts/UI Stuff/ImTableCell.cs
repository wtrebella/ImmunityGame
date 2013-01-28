using UnityEngine;
using System.Collections;

public class ImTableCell : ImEntity {
	float horizontalPadding_ = 0;
	float width_;
	float height_;
	
	public ImLabelComponent leftLabelComponent;
	public ImSpriteComponent rightSpriteComponent;
	
	public ImTableCell(string name, float horizontalPadding, float width, float height, Color backgroundColor) : base(name) {
		horizontalPadding_ = horizontalPadding;
		width_ = width;
		height_ = height;
		
		if (backgroundColor.a > 0) {
			ImSpriteComponent sc = new ImSpriteComponent("backgroundSpriteComponent", "Futile_White");
			sc.sprite.color = backgroundColor;
			sc.sprite.width = width_;
			sc.sprite.height = height_;
			sc.sprite.anchorX = 0;
			sc.sprite.anchorY = 0;
			AddComponent(sc);
		}
	}
	
	public void AddLeftLabel(string fontName, string labelString, Color labelColor, float labelScale) {
		ImLabelComponent lc = new ImLabelComponent("leftLabelComponent", fontName, labelString, labelColor, labelScale);
		lc.label.anchorX = 0;
		lc.label.x = horizontalPadding_;
		lc.label.y = height_ / 2f;
		leftLabelComponent = lc;
		AddComponent(lc);
	}
	
	public void AddRightSprite(string imageName, float spriteScale) {
		ImSpriteComponent sc = new ImSpriteComponent("rightSpriteComponent", imageName);
		sc.sprite.scale = spriteScale;
		sc.sprite.x = width_ - sc.sprite.width / 2f - horizontalPadding_;
		sc.sprite.y = height_ / 2f;
		rightSpriteComponent = sc;
		AddComponent(sc);
	}
	
	public float width {
		get {return width_;}
	}
	
	public float height {
		get {return height_;}
	}
	
	public float horizontalPadding {
		get {return horizontalPadding_;}
	}
}
