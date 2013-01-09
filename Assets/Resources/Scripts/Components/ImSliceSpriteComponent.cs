using UnityEngine;
using System.Collections;

public class ImSliceSpriteComponent : ImAbstractComponent {
	private FSliceSprite sprite_;
	
	public ImSliceSpriteComponent(string name, string imageName, float width, float height, float insetTop, float insetRight, float insetBottom, float insetLeft) : base(name) {
		componentType_ = ComponentType.SliceSprite;
		
		sprite_ = new FSliceSprite(imageName, width, height, insetTop, insetRight, insetBottom, insetLeft);
	}
	
	public bool SpriteContainsGlobalPoint(Vector2 globalPoint) {
		return sprite_.localRect.Contains(sprite_.GlobalToLocal(globalPoint));
	}
	
	public FSliceSprite sprite {
		get {return sprite_;}
	}
}
