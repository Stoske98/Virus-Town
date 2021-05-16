using UnityEngine;
using System.Collections.Generic;
[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    public Material dan;
    public Material noc;
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField, Range(0, 192)] private float TimeOfDay;
   // public List<GameObject> myList = new List<GameObject>();

   // private GameObject[] rasveta;

    private void Start()
    {
        /*if (rasveta == null)
        {
            rasveta = GameObject.FindGameObjectsWithTag("Svetlo");
           
        }*/
       
    }
    private void Update()
    {

        if(TimeOfDay /8  >= 5 && TimeOfDay / 8  <= 20)
        {
           /* foreach (GameObject go in rasveta)
            {
                if (go.name == "Svetlo")
                {
                    Light light = go.GetComponent<Light>();
                    light.enabled = false;
                }
            }*/
            RenderSettings.skybox = dan;
        }
        else
        {
           /* foreach (GameObject go in rasveta)
            {
                if (go.name == "Svetlo")
                {
                    Light light = go.GetComponent<Light>();
                    light.enabled = true;
                }
            }*/
            RenderSettings.skybox = noc;
        }
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 192; //Modulus to ensure always between 0-24
            UpdateLighting(TimeOfDay / 192f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 192f);
        }
    }


    private void UpdateLighting(float timePercent)
    {

        //RenderSettings.skybox = dan;
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}