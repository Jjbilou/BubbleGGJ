using System;
using System.Collections;
using UnityEngine;

public class ChangeSeason : MonoBehaviour
{
    [SerializeField]
    Sprite[] tileSprites;

    [SerializeField]
    float seasonDuration = 30.0f;

    SpriteRenderer[] spriteRenderers;
    int nbTilesBySeason;

    void Start()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        nbTilesBySeason = tileSprites.Length / 4;

        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(seasonDuration);

            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                int index = Array.IndexOf(tileSprites, spriteRenderers[i].sprite);

                spriteRenderers[i].sprite = tileSprites[
                    (index + nbTilesBySeason) % tileSprites.Length
                ];

                if (i % 10 == 0)
                {
                    yield return null;
                }
            }

            GameData.score++;
        }
    }
}
