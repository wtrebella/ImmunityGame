using UnityEngine;
using System.Collections;

public class ImNewPopoverDialogue : ImEntity {

	public ImNewPopoverDialogue(string name = "popover dialogue") : base(name) {
		AddComponent(new ImSliceSpriteComponent("sliceSpriteComponent", "uiPopover.psd", 100, 100, 16, 16, 16, 16));
	}
}
