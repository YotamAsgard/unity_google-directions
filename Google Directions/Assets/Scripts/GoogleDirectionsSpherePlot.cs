using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleDirectionsSpherePlot : MonoBehaviour
{

    public Material pointMaterial;

    SphereCollider sphereCollider;

    Vector3 convert(float lat, float lng, float radius)
    {

        // convert lat/long to radians
        lat = Mathf.PI * lat / 180;
        lng = Mathf.PI * lng / 180;

        // adjust position by radians	
        lat -= 1.570795765134f; // subtract 90 degrees (in radians)

        // and switch z and y (since z is forward)
        float xPos = (radius) * Mathf.Sin(lat) * Mathf.Cos(lng);
        float zPos = (radius) * Mathf.Sin(lat) * Mathf.Sin(lng);
        float yPos = (radius) * Mathf.Cos(lat);

        return new Vector3(xPos, yPos, zPos);

    }

    public void addPoint(GoogleDirections directions)
    {
        
        // loop over steps
        Steps[] steps = directions.routes[0].legs[0].steps;

        for (int stepsIndex = 0; steps.Length > stepsIndex; stepsIndex++)
        {
            print(steps[stepsIndex].end_location.lat);
            createSphere(
            steps[stepsIndex].end_location.lat,
            steps[stepsIndex].end_location.lng,
            sphereCollider.radius,
            this.transform
            );
        }

        // add start
        createSphere(
            directions.routes[0].legs[0].start_location.lat,
            directions.routes[0].legs[0].start_location.lng,
            sphereCollider.radius,
            this.transform
            );

        // add end
        createSphere(
            directions.routes[0].legs[0].end_location.lat,
            directions.routes[0].legs[0].end_location.lng,
            sphereCollider.radius,
            this.transform
            );

    }

    void createSphere(float lat, float lng, float radius, Transform parentTransform)
    {
        // create a sphere to represent the point
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        // convert the lat/lng to a Vector3 and use that to set the position of the sphere
        sphere.transform.position = convert(lat, lng, radius * parentTransform.localScale.x);

        // make the sphere tiny
        sphere.transform.localScale -= new Vector3(0.99F, 0.99F, 0.99F);

        // set the parent of the sphere to allow it to be affected by tranform changes of the parent
        sphere.transform.parent = parentTransform;

        // give the sphere a material
        Renderer rend = sphere.GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material = pointMaterial;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        // save reference to collider - used to base calculation on
        sphereCollider = GetComponent<SphereCollider>();
    }

}
