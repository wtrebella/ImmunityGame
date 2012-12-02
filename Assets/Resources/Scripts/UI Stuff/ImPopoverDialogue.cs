using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImPopoverDialogue : FContainer {
	private float borderThickness_;	
	private float width_;
	private float height_;
	private const float EXTRUDE_PADDING = 4;
	private const float ACTUAL_IMAGE_THICKNESS = 12.5f;
	
	public ImPopoverDialogue(float width, float height, float borderThickness) {
		float thicknessToActualRatio = borderThickness / ACTUAL_IMAGE_THICKNESS;
		
		width_ = width;
		height_ = height;
		borderThickness_ = borderThickness;
		
		FSprite background = WTSquareMaker.Square(width, height);
		background.anchorX = background.anchorY = 0;
		
		FSprite topSprite = new FSprite("popoverEdgeStraight.psd");
		FSprite rightSprite = new FSprite("popoverEdgeStraight.psd");
		FSprite bottomSprite = new FSprite("popoverEdgeStraight.psd");
		FSprite leftSprite = new FSprite("popoverEdgeStraight.psd");
		
		FSprite topLeftCornerSprite = new FSprite("popoverEdgeCurved.psd");
		FSprite topRightCornerSprite = new FSprite("popoverEdgeCurved.psd");
		FSprite bottomRightCornerSprite = new FSprite("popoverEdgeCurved.psd");
		FSprite bottomLeftCornerSprite = new FSprite("popoverEdgeCurved.psd");
		
		topSprite.anchorX = bottomSprite.anchorX = leftSprite.anchorX = rightSprite.anchorX = 0;
		topSprite.anchorY = bottomSprite.anchorY = leftSprite.anchorY = rightSprite.anchorY = 0;
		
		topLeftCornerSprite.anchorX = topRightCornerSprite.anchorX = bottomRightCornerSprite.anchorX = bottomLeftCornerSprite.anchorX = 0;
		topLeftCornerSprite.anchorY = topRightCornerSprite.anchorY = bottomRightCornerSprite.anchorY = bottomLeftCornerSprite.anchorY = 0;
		
		topSprite.width = bottomSprite.width = width_;
		topSprite.height = bottomSprite.height = borderThickness_ - EXTRUDE_PADDING / 4f * thicknessToActualRatio;
		rightSprite.width = leftSprite.width = height_;
		rightSprite.height = leftSprite.height = borderThickness_ - EXTRUDE_PADDING / 4f * thicknessToActualRatio;
		
		topLeftCornerSprite.width = topRightCornerSprite.width = bottomRightCornerSprite.width = bottomLeftCornerSprite.width = borderThickness_;
		topLeftCornerSprite.height = topRightCornerSprite.height = bottomRightCornerSprite.height = bottomLeftCornerSprite.height = borderThickness_;
		
		bottomSprite.rotation = 180;
		rightSprite.rotation = 90;
		leftSprite.rotation = 270;
		
		topLeftCornerSprite.rotation = 270;
		bottomRightCornerSprite.rotation = 90;
		bottomLeftCornerSprite.rotation = 180;
		
		bottomSprite.x = width_;
		bottomSprite.y = 0;
		
		rightSprite.x = width_;
		rightSprite.y = height_;
		
		topSprite.x = 0;
		topSprite.y = height_;
		
		leftSprite.x = 0;
		leftSprite.y = 0;
		
		topRightCornerSprite.x = width_;
		topRightCornerSprite.y = height_;
		
		topLeftCornerSprite.x = 0;
		topLeftCornerSprite.y = height_;
		
		bottomRightCornerSprite.x = width_;
		bottomRightCornerSprite.y = 0;
		
		bottomLeftCornerSprite.x = 0;
		bottomLeftCornerSprite.y = 0;
		
		AddChild(background);
		
		AddChild(topSprite);
		AddChild(rightSprite);
		AddChild(bottomSprite);
		AddChild(leftSprite);
		
		AddChild(topLeftCornerSprite);
		AddChild(topRightCornerSprite);
		AddChild(bottomRightCornerSprite);
		AddChild(bottomLeftCornerSprite);
	}

	public float width {
		get {return width_;}	
	}
	
	public float height {
		get {return height_;}	
	}
	
	public float borderThickness {
		get {return borderThickness_;}	
	}
}
