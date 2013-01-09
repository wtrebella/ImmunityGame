using UnityEngine;
using System.Collections;

public class WTMain : MonoBehaviour {

	public static FStage currentScene;
	public static WTMain instance;
	
	public enum SceneType {
		None,
		Immunity
	}
	
	void Start () {
		if (instance == null) instance = this;
		
		FutileParams fp = new FutileParams(true, true, false, false);
		fp.AddResolutionLevel(480f, 1.0f, 1.0f, "-res1");
		fp.AddResolutionLevel(1136f, 2.0f, 2.0f, "-res2");
		fp.AddResolutionLevel(2048f, 4.0f, 4.0f, "-res4");
		fp.backgroundColor = new Color(0.3f, 0.3f, 0.3f, 1.0f);
		fp.origin = Vector2.zero;
		
		Futile.instance.Init(fp);
		
		Futile.atlasManager.LoadAtlas("Atlases/ExtrudersSheet");
		Futile.atlasManager.LoadAtlas("Atlases/ImmunitySheet");
		Futile.atlasManager.LoadFont("TwCen", "twCen.png", "Atlases/twCen", 0, 0);
		
		Go.defaultEaseType = EaseType.SineInOut;
		
		SwitchToScene(SceneType.Immunity);
	}
	
	public void SwitchToScene(SceneType sceneType) {
		if (currentScene != null) Futile.RemoveStage(currentScene);
		
		if (sceneType == SceneType.Immunity) currentScene = new WTImmunity();
		if (sceneType == SceneType.None) currentScene = null;
		
		if (currentScene != null) Futile.AddStage(currentScene);
	}
}
