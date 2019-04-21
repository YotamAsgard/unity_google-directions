# unity_google-directions

Demo code for reading from and plotting information returned by the Google Directions API

 - [CMFreelookRightMouse](https://github.com/PhillipRC/unity_google-directions/blob/master/Google%20Directions/Assets/Scripts/CMFreelookRightMouse.cs) - Positions a camera around a sphere with a earth material
	 - Uses Cinemachine Freelook modified to use a right-click interaction
 - [GoogleDirectionsApi](https://github.com/PhillipRC/unity_google-directions/blob/master/Google%20Directions/Assets/Scripts/GoogleDirectionsApi.cs) : Loads data from the Google Directions API
	 - [UnityWebRequest](https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequest.html) to handle the request
	 - [JsonUtility](https://docs.unity3d.com/ScriptReference/JsonUtility.html) to convert the JSON data into objects using classes defined in [GoogleDirections.cs](https://github.com/PhillipRC/unity_google-directions/blob/master/Google%20Directions/Assets/Scripts/GoogleDirections.cs)
	 - Uses a [UnityEvent](https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html) to communicate the data to game objects once it is loaded
 - [GoogleDirectionsSpherePlot](https://github.com/PhillipRC/unity_google-directions/blob/master/Google%20Directions/Assets/Scripts/GoogleDirectionsSpherePlot.cs) - Plots markers at the direction steps on a sphere
 
## Running
 - Obtain a API Key for the [Google Directions API](https://developers.google.com/maps/documentation/directions)
 - Download repository
 - Load project into Unity (created in 2018.3)
 - Run
 - The "Google Directions API" game object parameters can be modified to plot different directions

![Game and Properties](https://raw.githubusercontent.com/PhillipRC/unity_google-directions/master/screenshots/game.jpg?token=ABHI76K2YPVQOUZA5TXEGNK4YW4BQ)
