using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*public enum UIButtonType {
	ZoomIn,
	ZoomOut
}*/

public class ImUILayer : ImEntity {
	//public FButton zoomInButton;
	//public FButton zoomOutButton;
	public FLabel dollarsLabel;
	public FSprite pauseButton;
	public FSprite playButton;
	
	public ImUILayer() {
		/*zoomInButton = new FButton("whiteSquare.png", "whiteSquare.png", null);
		zoomOutButton = new FButton("whiteSquare.png", "whiteSquare.png", null);
		zoomInButton.data = UIButtonType.ZoomIn;
		zoomOutButton.data = UIButtonType.ZoomOut;
		zoomInButton.sprite.color = Color.blue;
		zoomOutButton.sprite.color = Color.red;
		zoomInButton.sprite.width = zoomOutButton.sprite.width = 40f;
		zoomInButton.sprite.height = zoomOutButton.sprite.height = 20f;
		zoomInButton.anchorX = zoomOutButton.anchorX = 1f;
		zoomInButton.anchorY = zoomOutButton.anchorY = 1f;
		float padding = 5f;
		zoomInButton.x = zoomOutButton.x = Futile.screen.width - padding;
		zoomInButton.y = Futile.screen.height - padding;
		zoomOutButton.y = zoomInButton.y - zoomInButton.sprite.height - padding;
		AddChild(zoomInButton);
		AddChild(zoomOutButton);*/
		
		float margin = 10f;
		float paddingBetweenShit = 10f;
		
		dollarsLabel = new FLabel("TwCen", string.Format("$" + ImPlayerStats.dollars));
		dollarsLabel.anchorX = 0;
		dollarsLabel.anchorY = 1;
		dollarsLabel.x = margin;
		dollarsLabel.y = Futile.screen.height - margin;
		dollarsLabel.scale = 0.25f;
		AddChild(dollarsLabel);
		
		pauseButton = new FSprite("transportPause.psd");
		playButton = new FSprite("transportPlayPressed.psd");
		
		pauseButton.color = playButton.color = new Color(0.8f, 0.8f, 1.0f, 1.0f);
		
		pauseButton.anchorX = playButton.anchorX = 0;
		pauseButton.anchorY = playButton.anchorY = 1;
		
		pauseButton.x = margin;
		playButton.x = pauseButton.x + pauseButton.width;
		playButton.y = pauseButton.y = dollarsLabel.y - dollarsLabel.textRect.height * dollarsLabel.scaleY - paddingBetweenShit;
		
		AddChild(pauseButton);
		AddChild(playButton);
		
		ImPlayerStats.SignalDollarsChanged += HandleDollarsChanged;
	}
	
	public void HandleDollarsChanged () {
		dollarsLabel.text = string.Format("$" + ImPlayerStats.dollars);
	}
	
	public void SetTransportBar(bool isPaused) {
		if (isPaused) {
			pauseButton.element = Futile.atlasManager.GetElementWithName("transportPausePressed.psd");
			playButton.element = Futile.atlasManager.GetElementWithName("transportPlay.psd");
		}
		else {
			pauseButton.element = Futile.atlasManager.GetElementWithName("transportPause.psd");
			playButton.element = Futile.atlasManager.GetElementWithName("transportPlayPressed.psd");
		}
	}
}
