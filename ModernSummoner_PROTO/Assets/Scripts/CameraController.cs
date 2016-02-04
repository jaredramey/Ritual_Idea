using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]

public class CameraController : MonoBehaviour
{
    /*
    * Remaking a script that I made before
    * based off of a tutorial that you can find at:
    * https://www.youtube.com/watch?v=u67fbxe8xxY
    */


    /*
    * Just found out about SerializedFields so i'm trying
    * to get into the habbit of using them
    */
    [SerializeField]
    public Transform Player;
    [SerializeField]
    public Vector2 Margin, Smoothing;
    [SerializeField]
    public Vector3 _min, _max;
    [SerializeField]
    public BoxCollider2D Bounds;
    [SerializeField]
    public bool IsFollowing { set; get; }

    // Use this for initialization
    void Start()
    {
        _min = Bounds.bounds.min;
        _max = Bounds.bounds.max;

        IsFollowing = true;

        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        if (IsFollowing)
        {
            //If following then get the Abs pos of the camera so it knows where to be
            //If camera is outside the margine specified then smooth it so it doesn't go outside of it
            if (Mathf.Abs(x - Player.position.x) > Margin.x)
            {
                x = Mathf.Lerp(x, Player.position.x, Smoothing.x * Time.deltaTime);
            }

            //If camera is outside the margine specified then smooth it so it doesn't go outside of it
            if (Mathf.Abs(y - Player.position.y) > Margin.y)
            {
                y = Mathf.Lerp(y, Player.position.y, Smoothing.y * Time.deltaTime);
            }
        }

        //Get half the width of the camera for the x-axis
        var cameraHalfWidth = Camera.main.orthographicSize * ((float)Screen.width / Screen.height);

        //clamp camera on x-axis
        x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
        //clamp camera on y-axis
        y = Mathf.Clamp(y, _min.y + Camera.main.orthographicSize, _max.y - Camera.main.orthographicSize);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
