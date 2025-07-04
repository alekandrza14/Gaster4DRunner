using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class editorsave
{
    public Hyperbolic2D pos;

}
[ExecuteAlways]
public class load : MonoBehaviour
{

}
[ExecuteAlways]
[AddComponentMenu("Hyperbolic space/Hyperbolic Player Controler")]
public class HyperbolicCamera : MonoBehaviour
{
    [HideInInspector] public Vector3 position;

    public Hyperbolic2D RealtimeTransform = new Hyperbolic2D(0, 0.01f, 0f);
    public Hyperbolic2D HyperbolicTransform = new Hyperbolic2D(0, 0.01f, 0f);
    [HideInInspector] public bool px; [HideInInspector] public bool py; [HideInInspector] public bool mx; [HideInInspector] public bool my;
    [HideInInspector] public BoxCollider c;
    [HideInInspector] public float startscale;
    [HideInInspector] public Quaternion rotation;
    [Header("=============")]
    [Header("Physics")]
    public Rigidbody rb;
    public Transform spacesheapcam;
    public string ItemGA;

    public float radiuscolider;
    [Header("=============")]
    [Header("Lighting")]
    public Light light1;

    [HideInInspector] public float x;

    private void Start()
    {
        if (!Application.isPlaying) RealtimeTransform = HyperbolicTransform.copy();
       
        InvokeRepeating("edit", 1, 0.05f);
    }
    private void OnDestroy()
    {

    }
    private void OnApplicationQuit()
    {

    }

    void OnCollisionEnter(Collision c)
    {

        if (c.collider.tag == "deadpol")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

    // Start is called before the first frame update
    static HyperbolicCamera main_cam = null;
    public static HyperbolicCamera Main()
    {
        
        if(main_cam==null) main_cam = FindFirstObjectByType<HyperbolicCamera>();
       
        return main_cam;
    }
    private void LateUpdate()
    {
        if (!Application.isPlaying) RealtimeTransform = HyperbolicTransform.copy();
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
        if (spacesheapcam == null) { 
        if (Input.GetAxis("Vertical") > 0)
        {
            Ray r = new Ray(transform.position, new Vector3(0, 0.5f, 1));

            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.distance <= radiuscolider)
                {
                    RealtimeTransform.preApplyTranslationZ(Time.deltaTime);
                }
            }
        }
        if (Input.GetAxis("Vertical") < 0)
        {


            Ray r2 = new Ray(transform.position, new Vector3(0, 0.5f, -1));

            RaycastHit hit2;
            if (Physics.Raycast(r2, out hit2))
            {
                if (hit2.distance <= radiuscolider)
                {
                    RealtimeTransform.preApplyTranslationZ(-Time.deltaTime);
                }
            }
        }



        Ray r3 = new Ray(transform.position, new Vector3(1, 0.5f, 0));


        RaycastHit hit3;
        if (Physics.Raycast(r3, out hit3))
        {
            if (hit3.distance <= radiuscolider)
            {
                RealtimeTransform.preApplyTranslationY(Time.deltaTime);
            }
        }

        Ray r4 = new Ray(transform.position, new Vector3(-1, 0.5f, 0));

        RaycastHit hit4;
        if (Physics.Raycast(r4, out hit4))
        {
            if (hit4.distance <= radiuscolider)
            {
                RealtimeTransform.preApplyTranslationY(-Time.deltaTime);
            }
        }
    }

    }

    public Hyperbolic2D HyperboilcOringe = new Hyperbolic2D();
    public void edit()
    {

        /*


        PMatrix3D copytr = new PMatrix3D();
        copytr.set(HyperboilcOringe.getMatrix());

        Vector3 v3 = new Vector3();
        //json1.getFloat("n"),json1.getFloat("s"),json1.getFloat("m")
       

            PVector nextPoint = MathHyper.polarVector(0.1f, 1.255f);
            //Apply currentTransform on nextPoint and Save the result in nextPoint 



            copytr.mult(nextPoint, nextPoint);
            if (FindObjectsByType<HyperbolicCamera>(sortmode.main).Length != 0) HyperbolicCamera.Main().RealtimeTransform.getMatrix().mult(nextPoint, nextPoint);

            nextPoint = MathHyper.projectOntoScreen(nextPoint);
           
           

                v3 = new Vector3(nextPoint.x, 0, nextPoint.y);


            light1.transform.rotation = new Quaternion(
                Quaternion.LookRotation(v3).x * light1.transform.rotation.x,
                Quaternion.LookRotation(v3).y * light1.transform.rotation.y,
                Quaternion.LookRotation(v3).z * light1.transform.rotation.z,
                Quaternion.LookRotation(v3).w * light1.transform.rotation.w);


        */






    }
    float ftho;

    // Update is called once per frame
    public void Update()
    {

       if(Main().gameObject.activeSelf) transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero + Vector3.up * transform.position.y;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();
        }

        //_Rotation
        RenderSettings.skybox.SetFloat("_Rotation",(float)RealtimeTransform.n*57.4f);
        //Vertical
       

            if (ftho > 0) ftho -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.F))
            {
                ftho += 1;
                if (ftho > 1)
                {
                    RealtimeTransform.preApplyTranslationZ(-2); ftho = 0;
                }
            }
           
                Vector3 v = Vector3.MoveTowards(Vector3.zero, new Vector3(-Input.GetAxis("Vertical") * Time.deltaTime, -Input.GetAxis("Horizontal") * Time.deltaTime), 2);

                RealtimeTransform.preApplyTranslationZ(v.x);
                RealtimeTransform.preApplyTranslationY(v.y);
        Item.cooldown -= Time.deltaTime;
      if(Item.itemObjGraped!= "")  if (Input.GetKeyDown(KeyCode.E)&& Item.cooldown < 0)
        {
            Hyperbolic2D hyperbolicPoint = RealtimeTransform.copy().inverse();
            HyperbolicPoint obj = Instantiate(Resources.Load<GameObject>(Item.itemObjGraped), Vector3.zero,Quaternion.identity).GetComponent<HyperbolicPoint>();
            obj.HyperboilcPoistion = hyperbolicPoint;
            Item.itemObjGraped = "";
            
        }
        ItemGA = Item.itemObjGraped;
                if (Input.GetKey(KeyCode.Mouse1))
                {



                    float r1 = Input.GetAxis("Mouse X") * 0.1f;
                    RealtimeTransform.preApplyRotation(r1);



                }
       
        
    }
}
