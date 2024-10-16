using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HenryController : MonoBehaviour
{

  [SerializeField] Transform path;
  [SerializeField] float movement_speed = 5f;
  [SerializeField] float rotation_speed = 90f;


  [SerializeField] float waypoint_size = .4f;
  [SerializeField] float waypoint_wait_time = 2f;
  [SerializeField] float distance;
  [SerializeField] GameObject player;
  [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;

  public Button restart_button;
  public Button quit_button;
  public TMP_Text lose_text;
  public Material MainColor, FreezeColor;
  public float duration;
  public bool allow;
  public AudioSource splash;
  [SerializeField] private HideOnCollide collision_occur;

  private void Start()
  {
    collision_occur.onRaccoonFirstTimeOnTrash += collisionOccur_onRaccoonFirstTimeOnTrash;
    allow = true;
  }


  private void collisionOccur_onRaccoonFirstTimeOnTrash(object sender, System.EventArgs e)
  {
    transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    StartCoroutine(patrol(getWaypointArray()));
  }

  private void Update()
  {
    distance = Vector3.Distance(transform.position, player.transform.position);
    // if (distance <= 4&& allow)
    // {
    //     lose_text.text = "You were Caught! You Lose!";
    //     lose_text.gameObject.SetActive(true);
    //     restart_button.gameObject.SetActive(true);
    //     quit_button.gameObject.SetActive(true);
    // }
  }

  public void Freeze()
  {
    skinnedMeshRenderer.material = FreezeColor;
    movement_speed = 0;
    allow = false;
    splash.Play();
    StartCoroutine(delay());
  }

  IEnumerator delay()
  {
    yield return new WaitForSeconds(duration);
    movement_speed = 5;
    skinnedMeshRenderer.material = MainColor;
    allow = true;


  }

  IEnumerator patrol(Vector3[] waypoints)
  {
    int waypoint_index = 0;
    Vector3 waypoint_target = waypoints[waypoint_index];

    while (true)
    {
      transform.position = Vector3.MoveTowards(transform.position, waypoint_target, movement_speed * Time.deltaTime);
      transform.LookAt(waypoint_target);

      if (transform.position == waypoint_target)
      {
        waypoint_index = (waypoint_index + 1) % waypoints.Length;
        waypoint_target = waypoints[waypoint_index];
        yield return new WaitForSeconds(waypoint_wait_time);
        yield return StartCoroutine(turnTowardsPosition(waypoint_target));
      }
      yield return null;
    }

  }

  IEnumerator turnTowardsPosition(Vector3 rotation_target)
  {
    Vector3 direction = (rotation_target - transform.position).normalized;
    float target_angle = 90 - Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

    while (Mathf.DeltaAngle(transform.eulerAngles.y, target_angle) > Mathf.Abs(0.05f))
    {
      float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, target_angle, rotation_speed * Time.deltaTime);
      transform.eulerAngles = Vector3.up * angle;
      yield return null;
    }
  }

  private Vector3[] getWaypointArray()
  {
    Vector3[] waypoint_array = new Vector3[path.childCount];
    for (int i = 0; i < waypoint_array.Length; i++)
    {
      waypoint_array[i] = path.GetChild(i).position;
    }

    return waypoint_array;
  }


  private void OnDrawGizmos()
  {
    Vector3 start_waypoint_position = path.GetChild(0).position;
    Vector3 previous_waypoint_position = start_waypoint_position;

    foreach (Transform waypoint in path)
    {
      Gizmos.color = new Color(238f / 255, 130f / 255, 238f / 255, 255f / 255);
      Gizmos.DrawSphere(waypoint.position, waypoint_size);

      Gizmos.color = Color.white;
      Gizmos.DrawLine(previous_waypoint_position, waypoint.position);

      previous_waypoint_position = waypoint.position;
    }
    Gizmos.DrawLine(previous_waypoint_position, start_waypoint_position);
  }
}

