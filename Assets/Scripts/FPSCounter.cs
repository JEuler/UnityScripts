using UnityEngine;

// Credits to http://catlikecoding.com/unity/tutorials/frames-per-second/

public class FPSCounter : MonoBehaviour {

    // To calcualte average FPS not the just FPS we need a buffer to average over
    int[] fpsBuffer;
	int fpsBufferIndex;

	public int AverageFPS { get; private set; }
    public int HighestFPS { get; private set; }
	public int LowestFPS { get; private set; }
    
    public int frameRange = 60;
    
    void Update() {
       if (fpsBuffer == null || fpsBuffer.Length != frameRange) {
			InitializeBuffer();
		}
		UpdateBuffer();
		CalculateFPS();
    }
    
   void CalculateFPS () {
		int sum = 0;
		int highest = 0;
		int lowest = int.MaxValue;
		for (int i = 0; i < frameRange; i++) {
			int fps = fpsBuffer[i];
			sum += fps;
			if (fps > highest) {
				highest = fps;
			}
			if (fps < lowest) {
				lowest = fps;
			}
		}
		AverageFPS = (int)((float)sum / frameRange);
		HighestFPS = highest;
		LowestFPS = lowest;
	}
    
    void UpdateBuffer () {
		fpsBuffer[fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
	}
    
    void InitializeBuffer () {
		if (frameRange <= 0) {
			frameRange = 1;
		}
		fpsBuffer = new int[frameRange];
		fpsBufferIndex = 0;
	}
}