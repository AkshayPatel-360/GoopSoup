using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Bug Fix:
(15%)The potion always works regardless of what color interacts with what color. 
It used to work up until some recent dev push, investigate what happened and fix it properly while maintaining any feature that broke it.
public static readonly bool DEBUG_Ingredients_Always_Similar = false; //This bool if on will make it so explosions always kill enemies, used for testing explosions without worrying about color, turn off for final release
    



(10%) When potions are on the floor, they act like a landmine when monsters touch them, they explode, however it seems to be broken, fix that.
if(collision.transform.CompareTag("Monster") )
            PotionExplodes();

Research:
(5%)Where in the code does an enemy detect that it sees a player?
 //Determine if we can see the player
 sees the target determine the heights and then attack
 monsterAi.cs
        float distance = Vector2.Distance(pPos, mPos);
        if(distance < aiInfo.aggroRange)
        {
            seePlayer = true; //We see the player, but is there any obstacles between the two whose height is greater than 0?
            RaycastHit2D[] rayHits = Physics2D.RaycastAll(mPos, pPos - mPos, distance, 1 << LayerMask.NameToLayer("TerrainElement")); // Testing if we hit any terrain elements
            foreach(RaycastHit2D rh in rayHits)
            {
                TerrainElement te = rh.transform.GetComponent<TerrainElement>();
                //if (te.height > 0)
                    seePlayer = false;
            }
        }

    chasestate 21 line
          monster.MoveTowards(PlayerManager.Instance.player.transform.position);
        base.StayState(dt);

Feature :
Feature 1 (60%))
Add one new type of Monster, and in the Test.txt file, write the procedure for future devs to create new monsters.
(ex, Step 1, Download art, Step 2, Change art in editor to 4D hybercube mode, ...)
Step 1 : follow the structure Resource ----> prefabs ----> monsters // our all monsters are at this location except dog ; 
         to create a new dog(as monster) , duplicate the existing prefab which have monster script attached to it ;
         like duck, goat . 
         now drag your dog sprite from sprites (Sprite by default is in singal mode , cut it in pieces by changing to multiple and slice it by slice editor);
         (ref : load all prefabs   
         public void InitializeFactory()
    {
        //Loads all prefabs into the factory
        monsterPrefabDict = new Dictionary<string, GameObject>();
        GameObject[] allPrefabs = Resources.LoadAll<GameObject>(monsterPrefabPath);
        foreach (GameObject prefab in allPrefabs)
        {
            //Safety checks, did they create the monster properly?  
            Monster newMonster = prefab.GetComponent<Monster>();
            )
step 2 : change the anim info to dog whatever your name is in sprite folder because it  handeled by another class called animation factory (loop trough the all the sprites and then play the animation)
                                    (ref   :  public void SetupAnimationForMonster(Monster monster)
                                        {
                                            string animName = monster.animInfo.spriteName;
                                            if(string.IsNullOrEmpty(animName))
                                            {
                                                Debug.LogError("Sprite name for monster: " + monster.name + " is empty, no animations created");
                                                return;
                                            })
Feature 2 (10%))
Add another monster AI state called "Enraged". A monster from Any State can enter into Enraged.A monster
beomes enranged if its spawner dies

    added the state enraged and add method for moster to movetowardsenraged and also 

    add bool variable called isMonolith dead , changed its value from explosion script and now have to trigger the anim.settrigger enraged but how
    can be figureout that only his parent monolith is dead :) i did it till the last step but i don't know how to trigger on that monolith dies;

*/
