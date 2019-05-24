using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsToDo : MonoBehaviour {

	//Placing things here I am not sure where I intend to handle or maintain them

	//CODING PROBLEMS/THINGS
	//Need UI for currentMP during battle
	
	//SOLVED-BANDAID FIX
		//Need to manage destroying enemies after combat since it doesnt seem to be working
		//Attempted to assign GameProgress.killedEnemy on Collision Contact in (PlayerEnemyCollisionController Script) since the outcome of the battle is technically irrelevant
		//Whether you win or lose you should not encounter that enemy again until you restart the game
	//Balancing tweaks to enemy health/damage
	//Persistent sound across scene loads without it being too resource-taxing-SOLVED
	//Parallaxing background so I dont need 100 copies of my background(Would be nice)-Parallax the different depths at different speeds
	//Expanded enemy spawn system so it incorporates the difficulty measurement adjusting stats
	//Potion on running game implementation-Ability to collect potions while playing
	//Item use implementation
		//Made it just a potion item-It heals but I have not written a potion manager yet for how many you have in your inventory-SOLVED
		//Need implementation for different item types
	//Fix sounds on button click so they activate
	//Fix enemyHealthText display problem-SOLVED it strictly displays a value
	//Create a better level that is more fun
	
	//ART PROBLEMS/THINGS
	//Need separate artwork for ground and flying enemies
	//Need to better animate
	//Need to animate the player character in combat sequence
	//Give some flair to the combat UI
		//Added new fonts to the game-Which helped
		//Better button animations, maybe screen shake on attack
	//Animate a slide instead of compressing the character
	//Add Sounds on Jump and Slide
	//Add a Background to Combat Sequence


	
}
