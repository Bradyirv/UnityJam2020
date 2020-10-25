using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Daybrayk;
using Daybrayk.Properties;
public class ConfessionManager : MonoBehaviour
{
    public static event System.Action onConfessionStart;
    public static event System.Action onConfessionFinish;

    [SerializeField]
    IntReference secretAccumulator;

    public CharacterRoot root { get; set; }

    public GameObject aiRef { get; set; }

    private void Start()
    {
        root = FindObjectOfType<CharacterRoot>();
    }

    public void ConfessionStart(Transform sitPos, Transform enterPos)
    {
        root.input.SwitchCurrentActionMap("UI");
        onConfessionStart?.Invoke();
        StartCoroutine(EnterConfessionHelper(sitPos, enterPos));
    }

    public void ConfessionEnd(Transform pos)
    {
        StartCoroutine(ExitConfessionHelper(pos));
        secretAccumulator.Value++;
        onConfessionFinish?.Invoke();

    }

    IEnumerator EnterConfessionHelper(Transform sitPos, Transform enterPos)
    {
        while(Vector3.Distance(root.transform.position.WithY(0), sitPos.position.WithY(0)) > 0.1f)
        {
            root.movement.CinematicMove(sitPos);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        root.movement.anim.SetFloat("speed", 0);
        root.movement.anim.SetTrigger("sit");

        StartCoroutine(ConfessionHelper(enterPos));
    }

    IEnumerator ConfessionHelper(Transform enterPos)
    {
        yield return new WaitForSeconds(5);
        root.movement.anim.SetTrigger("stand");
        yield return new WaitForSeconds(2.5f);
        ConfessionEnd(enterPos);
    }

    IEnumerator ExitConfessionHelper(Transform pos)
    {
        while (Vector3.Distance(root.transform.position.WithY(0), pos.position.WithY(0)) > 0.1f)
        {
            root.movement.CinematicMove(pos);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        root.movement.anim.SetFloat("speed", 0);
        root.input.SwitchCurrentActionMap("Player");
    }
}
