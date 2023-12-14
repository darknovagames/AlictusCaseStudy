#A quick explanation of the code

##GameManager.cs
This script holds coins, kill count and game state information.
Also is responsible for handling events and persistent data.
Persistent data is done using PlayerPrefs, which I know, is not a very efficient and useful way to keep persisdent game data. But for this occasion, I think it worked well.

##Player.cs
Handles collisions and holds health and death status info. PlayerMovement.cs, PlayerAnimation.cs, PlayerAttack.cs depend on it.

##PlayerAttack.cs
This handles attacking. Constantly checks for nearby enemies in Update, using GetClosestTargetableInRadius() function. The attack range depends on the scale of the "AttackRange" object.
Which also changes the attack range indicator's size.

###GetClosestTargetableInRadius() 
This uses Physics.OverlapSphere to see if there's a gameObject with ITargetable attached to it. If there is, it returns the closest one.

###Attack()
This simply instantiates a projectile object with IPlayerProjectile attached to it. 
IPlayerProjectile is an interface that has SetTarget(ITargetable). As I figured that we might want to add different projectiles that could go with a different pattern, deal more damage etc.

##InputHandler.cs
This is the base input handler class. If we ever want to change the input method, we just need to write a script that derives from this.
Like JoystickInputHandler.cs, which simply gets the input from the JoystickPack and sets it's Direction value to its.

##Enemy.cs
This is the script that handles everything for the Skeleton enemy. There was supposed to be a SkeletonEnemy.cs class that derives from this one but I was out of time before I could do that.
This uses Unity Navigation for the skeleton movement. When it's closer to the player than a certain distance it's speed is set to zero and start throwing fireballs.

##EnemyProjectile.cs
This is a placeholder script that handles enemy projectile. It -Unfortunately- gets the player reference on the Start() method with a GameObject.FindWithTag("Player") function.
Which is probably the worst way to do it, but it atleast works. I would have add a SetTarget function and pass the player reference from the Enemy script if I had the time.

##SpawnEnemies.cs
This script randomly spawns enemies just outside the camera view.
  
    Plane[] CameraFrustumPlanes = GeometryUtility.CalculateFrustumPlanes(_camera);
    
I used CameraFrustumPlanes for this. GeometryUtility.CalculateFrustumPlanes() function gets the FrustumPlanes and returns them in an Array with the size of 6.
The first 4 of them are LeftPlane, RightPlane, UpPlane and DownPlane which are the ones we need. 

    Ray ray = new Ray(_player.transform.position, Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) * Vector3.right);

Then I had Raycasts that goes at a random 360 around the player. Then I check the point where it collides with the frustum planes. 
Rays can hit multiple planes, but we only need the closest one so we find it, add some additional offset with "_enemyRadius" to make up for the enemy model's size. 

#Summary

Overall, I did my best to finish all the given necessities. I am well aware that I sacrificied some code readability and modularity for writing speed. And I am very well aware that
many scripts could be a lot better.

Some of the parts that could be improved:
-Object pools could be used for Enemies and all projectiles.
-Player's interactions with other objects could be written in a better way that complies with SOLID. Currently it is basically hard coded.


Thanks for your time. 

Cheers
