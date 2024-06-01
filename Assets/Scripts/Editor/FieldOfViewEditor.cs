using UnityEditor;
using UnityEngine;

//set class to editor so it isn't built into final project
[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{

    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        //Setting the radial view to be white for ease of viewing 
        Handles.color = Color.white;
        //Draw in radial view
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

        //Setting both sides of the angle on either side of looking straight ahead
        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.angle / 2);

        //Setting the field of view to be yellow in color
        Handles.color = Color.yellow;
        //Drawing in both sides of the field of view
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.radius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.radius);

        if (fov.canSeePlayer)
        {
            //Setting the sightline to be green
            Handles.color = Color.green;
            //Drawing the line to show that the enemy has spotted the player
            //Direct line to player character
            Handles.DrawLine(fov.transform.position, fov.playerRef.transform.position);
        }
    }

    //creating angles for the viewing angle to be used in the GUI
    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
