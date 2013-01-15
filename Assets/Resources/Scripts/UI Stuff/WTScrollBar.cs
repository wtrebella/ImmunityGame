using UnityEngine;
using System.Collections;

public class WTScrollBar : ImEntity {
	public ImSliceSpriteComponent mainSpriteComponent;
	
	public WTScrollBar(string name = "scroll bar!") : base(name) {
		mainSpriteComponent = new ImSliceSpriteComponent("mainSliceSpriteComponent", "scrollBar.psd", 50f/4f, 150f/4f, 52f/4f, 0, 52f/4f, 0);
		mainSpriteComponent.sprite.anchorX = 0;
		mainSpriteComponent.sprite.anchorY = 0;
		mainSpriteComponent.sprite.height = 400f;
		AddComponent(mainSpriteComponent);
	}
}
