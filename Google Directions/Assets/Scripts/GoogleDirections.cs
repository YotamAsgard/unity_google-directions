[System.Serializable]
public class TextValue
{
    public string text;
    public string value;
}

[System.Serializable]
public class LatLng
{
    public float lat;
    public float lng;
}

[System.Serializable]
public class PolyLine
{
    public string points;
}


[System.Serializable]
public class Steps
{
    public TextValue distance;
    public TextValue duration;
    public LatLng end_location;
    public LatLng start_locaiton;
    public PolyLine polyline;
    public string travel_mode;
}

[System.Serializable]
public class Legs
{
    public TextValue distance;
    public TextValue duration;
    public LatLng end_location;
    public LatLng start_location;

    // each leg has steps
    public Steps[] steps;
}

[System.Serializable]
public class Routes
{
    // each route has an array of legs
    public Legs[] legs;
}

[System.Serializable]
public class GoogleDirections
{
    // each return has an array of routes
    public Routes[] routes;
}
