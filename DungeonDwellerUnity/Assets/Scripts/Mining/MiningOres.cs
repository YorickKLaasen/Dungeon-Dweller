using System.Collections;
using UnityEngine;

public class MiningOres : MonoBehaviour
{
    [SerializeField] Sprite mediumOreSprite;
    [SerializeField] Sprite smallOreSprite;
    [SerializeField] SpriteRenderer healthBarSprite;
    private SpriteRenderer spriteRenderer;
    public float blockStrength;
    public float currentBlockStrength;
    public float playerMiningSpeed;
    [SerializeField] PlayerData playerData;
    Rigidbody2D rigidBody;
    float dropAmount = 0;
    float fortune = 0;
    public float fillAmount = 1.25f;
    [SerializeField] GameObject healthBar1;
    [SerializeField] GameObject healthBar2;
    void Start()
    {
        playerMiningSpeed = playerData.miningSpeed;
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentBlockStrength = blockStrength;
    }

    private void Update()
    {
        if (currentBlockStrength != blockStrength)
        {
            healthBar1.SetActive(true);
            healthBar2.SetActive(true);
        }
        fillAmount = currentBlockStrength / blockStrength;
        healthBarSprite.transform.localScale = new Vector3(fillAmount, 0.376375f, 1f);
        if (gameObject.tag == "Ore")
        {
            fortune = playerData.miningFortune + playerData.oreFortune;
        }
        else if (gameObject.tag == "Gemstone")
        {
            fortune = playerData.miningFortune + playerData.gemstoneFortune;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pickaxe"))
        {
            currentBlockStrength -= playerData.miningSpeed;
            BlockHealthUpdate();
        }
    }

    void BlockHealthUpdate()
    {
        if (currentBlockStrength <= blockStrength * 0.50f)
        {
            spriteRenderer.sprite = mediumOreSprite;
        }
        if (currentBlockStrength <= blockStrength * 0.25f)
        {
            spriteRenderer.sprite = smallOreSprite;
        }
        if (currentBlockStrength <= 0)
        {
            if (fortune == 0)
            {
                dropAmount = rigidBody.mass;
            }
            else
            {
                dropAmount = rigidBody.mass * fortune;
            }
            print(dropAmount);
            Destroy(gameObject);
        }
    }
}
