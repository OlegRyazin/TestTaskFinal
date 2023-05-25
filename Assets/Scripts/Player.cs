using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool isGameRun = false;
    public static bool isPlayerGrounded = true;

    private int torchPower = 2;

    [SerializeField]
    private UI scriptUI;

    [SerializeField]
    private MapGenerator scriptMapGenerator;

    [SerializeField]
    private GameObject torchLight;

    private float[] torchLightPowers = new float[6] {0.5f, 1f, 2f, 4f, 6f, 10f};
    private float[] torchLightRange = new float[6] {2f, 5f, 10f, 15f, 25f, 50f};
    private Vector3 playerStartPos = new Vector3(0f, 0.2f, 0f);

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void Start()
    {
        TorchLightPowersChange(2);
    }
    public void TorchUp(GameObject fireSphere)
    {
        if (torchPower != 6) torchPower++;
        TorchLightPowersChange(torchPower);
        scriptUI.FireUIChange(torchPower);
        StartCoroutine(FireSphereReborn(fireSphere));
    }

    private IEnumerator FireSphereReborn(GameObject fireSphere)
    {
        fireSphere.SetActive(false);
        yield return new WaitForSeconds(5f);
        fireSphere.SetActive(true);
    }

    public void TorchDown()
    {
        torchPower--;
        if (torchPower == 0) GameOver();
        else
        {
            TorchLightPowersChange(torchPower);
            scriptUI.FireUIChange(torchPower);
        }       
    }

    private void TorchLightPowersChange(int power)
    {
        torchLight.GetComponent<Light>().intensity = torchLightPowers[power - 1];
        torchLight.GetComponent<Light>().range = torchLightRange[power - 1];
    }

    private void GameOver()
    {
        transform.position = playerStartPos;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.SetActive(false);
        isGameRun = false;
        torchPower = 2;
        TorchLightPowersChange(torchPower);
        scriptUI.FireUIChange(torchPower);
        scriptUI.GameFinish();
        scriptMapGenerator.SpawnStartRoad();       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water") TorchDown();
        if (other.gameObject.tag == "FireSphere")
        {
            TorchUp(other.gameObject);
            scriptUI.ScoreUpAndChange();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isPlayerGrounded = true;
    }
}
