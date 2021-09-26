using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{   

    //config para
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    
    [SerializeField] Sprite[] hitSprite;
    //cached ref

    Level level;


    //state var
    [SerializeField] int timesHit;
    private void Start()
    {
        
        CountBreakableBlocks();
    }
    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
         if (tag == "Breakable")
         {
         level.countBlocks();
         }
    }

 private  void OnCollisionEnter2D(Collision2D collision)
 {
     if (tag == "Breakable")
     {
        HandleHit();
        
     }
 }

private void HandleHit()
{
     timesHit++;
     int maxHits = hitSprite.Length +1;
         if (timesHit >= maxHits)
         {
             DestroyBlock();
         }
         else
         {
             ShowNextHitSprite();

         }
}

private void ShowNextHitSprite()
{
    int spriteIndex = timesHit - 1;
    if(hitSprite[spriteIndex]!=null){
    GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
    }
    else{Debug.Log("Block sprite is missing" + gameObject.name);}
}
 private void DestroyBlock()
 {
     PlayBlockDestroySFX();
     Destroy(gameObject);
     level.BlockDestroyed();
     TriggerParticleVFX();
 }

  private void PlayBlockDestroySFX()
 {
    FindObjectOfType<GameStatus>().AddToScore();
    AudioSource.PlayClipAtPoint(breakSound , Camera.main.transform.position);
 }

 private void TriggerParticleVFX()
 {
     GameObject sparkle = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
     Destroy(sparkle, 1f);
 }
 
}
