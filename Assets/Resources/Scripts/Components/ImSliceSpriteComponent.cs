using UnityEngine;
using System.Collections;

public class ImSliceSpriteComponent : ImAbstractComponent {	
	private FSliceSprite sprite_;
	private TweenChain spritePulsateTween_;
	
	public ImSliceSpriteComponent(string name, string imageName) : base(name) {
		componentType_ = ComponentType.SliceSprite;
	
		sprite_ = new FSliceSprite(Futile.atlasManager.GetElementWithName(imageName).sourceSize.x, Futile.atlasManager.GetElementWithName(imageName).sourceSize.y, 0, 0, 0, 0, imageName);
	}
	
	public bool SpriteContainsGlobalPoint(Vector2 globalPoint) {
		return sprite_.localRect.Contains(sprite_.GlobalToLocal(globalPoint));
	}
	
	public FSprite sprite {
		get {return sprite_;}	
	}
}
