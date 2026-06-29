using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    [SerializeField] private float meleeRadius = 2.5f;
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private GameObject meleeCanvasObject;
    [SerializeField] private AudioClip meleeSound;
    private RaycastHit2D meleeCast;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meleeCast = Physics2D.CircleCast(transform.position, meleeRadius, transform.right, 0.0f, enemyLayerMask);
        
        if (meleeCast.collider.name.Contains("Piggy"))
        {
            meleeCanvasObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SoundFXManager.instance.PlaySoundFX(meleeSound, transform, 1.0f);
                Destroy(meleeCast.collider.gameObject);
                meleeCanvasObject.SetActive(false);
            }
        }
        else
        {
            meleeCanvasObject.SetActive(false);
        }
    }
}
