using UnityEngine;
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
    void Start()
    {
        
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
        viva = sol.Viva() && agua.Viva() && fertilizante.Viva();
        active = viva;
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
    }
    public  void Sembrar(GameObject other)
    {
        if (flor != null)
        {
            Destroy(flor);
        }
        flor = Instantiate(other, transform.position, transform.rotation);
        Restart();
        active = true;
    }
} 

public static class Extensiones
{
    public static Vector3 Reiniciar(this Vector3 vec) => new Vector3(vec.x,vec.y, Mathf.Lerp(vec.x, vec.y, 0.5f));
    public static bool Viva(this Vector3 vec) => (vec.z > vec.x && vec.z < vec.y);
}