using UnityEngine;
using UnityEngine.UI;
public class FlowersController : MonoBehaviour
{
    public bool active;
    public bool viva;
    public Vector3 sol;
    public Vector3 agua;
    public Vector3 fertilizante;
    public float velocidad;
    public float velocidadRecurso;
    public GameObject flor;
    public GameObject mataPlantada;
    public GameObject mata;

    public Slider slFert;
    public Slider slSol;
    public Slider slAgua;

    public Image imFert;
    public Image imSol;
    public Image imAgua;

    public Gradient colores;
    public GameObject cnvBarras;
    void Start()
    {
        cnvBarras.SetActive(false);
    }

    void Update()
    {
        if (!active || !viva)
        {
            return;
        }
        sol.z -= velocidad * Time.deltaTime;
        agua.z -= velocidad * Time.deltaTime;
        fertilizante.z -= velocidad * Time.deltaTime;

        //Actualizar UI
        slAgua.value = agua.Porcentaje();
        slSol.value = sol.Porcentaje();
        slFert.value = fertilizante.Porcentaje();

        imAgua.color = colores.Evaluate(agua.Porcentaje());
        imFert.color = colores.Evaluate(fertilizante.Porcentaje());
        imSol.color = colores.Evaluate(sol.Porcentaje());

        viva = sol.Viva() && agua.Viva() && fertilizante.Viva();
        active = viva;
        if (!viva)
        {
            cnvBarras.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "sunshine")
        {
            sol.z += velocidadRecurso * Time.deltaTime;
        }
        if (other.transform.tag == "fertilizer")
        {
            fertilizante.z += velocidadRecurso * Time.deltaTime;
        }
        if (other.transform.tag == "wateringCan")
        {
            agua.z += velocidadRecurso * Time.deltaTime;
        }
    }
    public void Restart()
    {
        sol = sol.Reiniciar();
        agua = agua.Reiniciar();
        fertilizante = fertilizante.Reiniciar();
        viva = true;
        cnvBarras.SetActive(true);
    }
    public  void Sembrar(GameObject other)
    {
        if (mataPlantada != null)
        {
            Destroy(mataPlantada);
        }
        flor = other;
        mataPlantada = Instantiate(mata, transform.position, transform.rotation, transform);
        mata.GetComponent<Planta>().fc = this;
        Restart();
        active = true;
    }
} 

public static class Extensiones
{
    public static Vector3 Reiniciar(this Vector3 vec) => new Vector3(vec.x,vec.y, Mathf.Lerp(vec.x, vec.y, 0.5f));
    public static bool Viva(this Vector3 vec) => (vec.z > vec.x && vec.z < vec.y);

    public static float Porcentaje(this Vector3 vec) => (vec.z - vec.x) / (vec.y - vec.x);
}