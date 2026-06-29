using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    [SerializeField] private float meleeRadius = 1f;
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private GameObject meleeCanvasObject;
    [SerializeField] private AudioClip meleeSound;
    [SerializeField] private Sprite meleeTexture;
    private RaycastHit2D meleeCast;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meleeCast = Physics2D.CircleCast(transform.position, meleeRadius, transform.right, 0.0f, enemyLayerMask);

        //Debug.Log("Melee Cast: " + meleeCast.collider.name);
        if (meleeCast.collider == null)
        {
            meleeCanvasObject.SetActive(false);
            return;
        }
        
        if (meleeCast.collider.name.Contains("Piggy"))
        {
            meleeCanvasObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SoundFXManager.instance.PlaySoundFX(meleeSound, transform, 1.0f);
                meleeCast.collider.GetComponent<SpriteRenderer>().sprite = meleeTexture;
                meleeCast.collider.GetComponent<HealthManager>().MeleeKill();
                //Destroy(meleeCast.collider.gameObject, .5f);
                meleeCanvasObject.SetActive(false);
            }
        }
    }
}
