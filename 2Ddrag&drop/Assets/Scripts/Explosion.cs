using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private PointEffector2D ExplosionEffector;
    [SerializeField] private Sprite ExplosionSprite;
    [SerializeField] private float ExplosionForce;
    [SerializeField] private float ExplosionRaius;
    [SerializeField] private LayerMask ExplosionImpactLayers;
    [SerializeField] private float ExplosionTime;

    private Camera cam;

    private SpriteRenderer ExplosionRenderer;
    private CircleCollider2D ExplosionCollider;
    private float ExplosionTimeCounter;
    private bool Explode;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        ExplosionRenderer = ExplosionEffector.gameObject.GetComponent<SpriteRenderer>();
        ExplosionCollider = ExplosionEffector.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ExplosionTimeCounter -= Time.deltaTime;
        Explode = ExplosionTimeCounter >= 0;


        if (Input.GetButtonUp("Fire1"))
        {
            Vector2 explosionCenter = cam.ScreenToWorldPoint(Input.mousePosition);

            ExplosionEffector.transform.position = explosionCenter;
            ExplosionEffector.forceMagnitude = ExplosionForce;
            ExplosionCollider.radius = ExplosionRaius;

            ExplosionEffector.colliderMask = ExplosionImpactLayers;

            if (ExplosionSprite != null)
            {
                ExplosionRenderer.sprite = ExplosionSprite;
            }

            ExplosionTimeCounter = ExplosionTime;
        }


        ExplosionEffector.gameObject.SetActive(Explode);
    }
}
