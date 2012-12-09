using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PopoverTriangleDirectionType {
	PointingRight,
	PointingLeft
}

public class ImPopoverDialogue : FContainer {
	private FSprite background_;
	private FContainer internalContainer_;
	private FSprite triangle_;
	private PopoverTriangleDirectionType triangleDirection_;
	private float borderThickness_;	
	private float width_;
	private float height_;
	private const float EXTRUDE_PADDING = 4;
	private const float ACTUAL_IMAGE_THICKNESS = 12.5f;
	private float maxContentHeight = Futile.screen.height - 10f;
	private float minContentHeight = 10f;
	
	public ImPopoverDialogue(float width, float height, float borderThickness, PopoverTriangleDirectionType triangleDirection) {
		internalContainer_ = new FContainer();
		AddChild(internalContainer_);
		
		float thicknessToActualRatio = borderThickness / ACTUAL_IMAGE_THICKNESS;
		
		width_ = width;
		height_ = height;
		borderThickness_ = borderThickness;
		triangleDirection_ = triangleDirection;
		
		background_ = WTSquareMaker.Square(width + borderThickness_, height + borderThickness_);
		background_.anchorX = background_.anchorY = 0;
		background_.x = -borderThickness_ / 2f;
		background_.y = -borderThickness_ / 2f;
		
		FSprite topSprite = new FSprite("popoverEdgeStraight.psd");
		FSprite rightSprite = new FSprite("popoverEdgeStraight.psd");
		FSprite bottomSprite = new FSprite("popoverEdgeStraight.psd");
		FSprite leftSprite = new FSprite("popoverEdgeStraight.psd");
		
		FSprite topLeftCornerSprite = new FSprite("popoverEdgeCurved.psd");
		FSprite topRightCornerSprite = new FSprite("popoverEdgeCurved.psd");
		FSprite bottomRightCornerSprite = new FSprite("popoverEdgeCurved.psd");
		FSprite bottomLeftCornerSprite = new FSprite("popoverEdgeCurved.psd");
		
		triangle_ = new FSprite("popoverTriangle.psd");
		triangle_.scale = 0.5f;
		
		triangle_.color = topSprite.color = rightSprite.color = bottomSprite.color = leftSprite.color = topLeftCornerSprite.color = topRightCornerSprite.color = bottomRightCornerSprite.color = bottomLeftCornerSprite.color = new Color(0.12f, 0.12f, 0.12f, 1.0f);
		
		topSprite.anchorX = bottomSprite.anchorX = leftSprite.anchorX = rightSprite.anchorX = 0;
		topSprite.anchorY = bottomSprite.anchorY = leftSprite.anchorY = rightSprite.anchorY = 0;
		
		triangle_.anchorY = 1;
		
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
		
		triangle_.y = height_ / 2;
		
		if (triangleDirection_ == PopoverTriangleDirectionType.PointingLeft) {
			triangle_.rotation = 90;
			triangle_.x = 1 - borderThickness_;
		}
		else if (triangleDirection_ == PopoverTriangleDirectionType.PointingRight) {
			triangle_.rotation = 270;
			triangle_.x = width_ + borderThickness_ - 1;
		}
		
		topRightCornerSprite.x = width_;
		topRightCornerSprite.y = height_;
		
		topLeftCornerSprite.x = 0;
		topLeftCornerSprite.y = height_;
		
		bottomRightCornerSprite.x = width_;
		bottomRightCornerSprite.y = 0;
		
		bottomLeftCornerSprite.x = 0;
		bottomLeftCornerSprite.y = 0;
		
		internalContainer_.AddChild(background_);
		
		internalContainer_.AddChild(topSprite);
		internalContainer_.AddChild(rightSprite);
		internalContainer_.AddChild(bottomSprite);
		internalContainer_.AddChild(leftSprite);
		
		internalContainer_.AddChild(triangle_);
		
		internalContainer_.AddChild(topLeftCornerSprite);
		internalContainer_.AddChild(topRightCornerSprite);
		internalContainer_.AddChild(bottomRightCornerSprite);
		internalContainer_.AddChild(bottomLeftCornerSprite);
		
		SetInternalContainerPosition();
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
	
	private void SetInternalContainerPosition() {
		internalContainer_.x = -triangle_.x;
		internalContainer_.y = -triangle_.y;
		
		float triangleWidth = 8f;
		
		if (triangleDirection_ == PopoverTriangleDirectionType.PointingLeft) {
			internalContainer_.x += triangleWidth;
		}
		else if (triangleDirection_ == PopoverTriangleDirectionType.PointingRight) {
			internalContainer_.x -= triangleWidth;
		}
	}
	
	public void PlaceAtPosition(float newX, float newY) {
		float deltaX = newX - this.x;
		float deltaY = newY - this.y;
		
		this.x = newX;
		this.y = newY;
		
		Vector2 localBackgroundOrigin = new Vector2(background_.x + deltaX, background_.y + deltaY);
		Vector2 globalBackgroundOrigin = internalContainer_.LocalToGlobal(localBackgroundOrigin);
		float globalMinBackgroundY = globalBackgroundOrigin.y;
		float globalMaxBackgroundY = globalMinBackgroundY + height_;
		Debug.Log("minBackground: " + globalMinBackgroundY + " maxBackground: " + globalMaxBackgroundY);
		
		if (globalMaxBackgroundY > maxContentHeight) {
			deltaY = globalMaxBackgroundY - maxContentHeight;
			internalContainer_.y -= deltaY;
			triangle_.y += deltaY;
		}
		else if (globalMinBackgroundY < minContentHeight) {
			deltaY = minContentHeight - globalMinBackgroundY;
			internalContainer_.y += deltaY;
			triangle_.y -= deltaY;
		}
	}
}
