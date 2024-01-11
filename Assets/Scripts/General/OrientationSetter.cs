using UnityEngine;

public class OrientationSetter : MonoBehaviour
{


    public enum Orientation
    {
        Any,
        Portrait,
        PortraitFixed,
        Landscape,
        LandscapeFixed
    }

    public Orientation ScreenOrientation;

    private void Start()
    {
        switch (ScreenOrientation)
        {
            case Orientation.Any:
                Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

                Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                break;

            case Orientation.Portrait:
                Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
                Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

                Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = false;
                break;

            case Orientation.PortraitFixed:
                Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
                break;

            case Orientation.Landscape: 
                Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
                Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

                Screen.autorotateToPortrait = Screen.autorotateToPortrait = false;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                break;

            case Orientation.LandscapeFixed:
                Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
                break;
        }
    }
}