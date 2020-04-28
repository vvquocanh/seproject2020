# White box testing coverage report

#
Group 17

1.
## **SCRIPTS**

1. Camera:

1. Follow:

| Method | Test cases | Expected | Results |
| --- | --- | --- | --- |
| void Start(){Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);transform.position = playerPosition;} | Different player locations on the map. | Set the camera location to focus on the players before the first frame starts | Pass |
| void Update(){Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);transform.position = playerPosition;} | Different player locations on the map. | Set the camera location to focus on the players once per frame | Pass |

1. Ghost:

1. Fireball

| Method | Test cases | Expected | Results |
| --- | --- | --- | --- |
| privatevoid Start(){player = GameObject.FindGameObjectWithTag(&quot;Player&quot;).transform;
target = new Vector2(player.position.x, player.position.y);} | Different player locations on the map. | Set up the variables for further uses. | Pass |
| privatevoid Update(){transform.position = Vector2.MoveTowards(transform.position, target, speed \* Time.deltaTime);if(transform.position.x == target.x &amp;&amp; transform.position.y == target.y){DestroyProjectile();}} | Different player locations on the map. | Move the fireball to the last location of the character and destroy the projectile when arrive | Pass |
| privatevoid OnTriggerEnter2D(Collider2D other){if (other.CompareTag(&quot;Player&quot;)){DestroyProjectile();}} | Different angles of players | Destroy the projectile if it hits the player | Pass |

1. GhostAttack:

| Method | Test cases | Expected | Results |
| --- | --- | --- | --- |
| privatevoid OnTriggerEnter2D(Collider2D other){if (other.tag == &quot;Player&quot;){attack = true;}} | Player comes from different angles | Set the ghost attack commands to true when player comes in range | Pass |
| privatevoid OnTriggerExit2D(Collider2D other){if (other.tag == &quot;Player&quot;){attack = false;}} | Player leaves from different angles | Set the ghost attack commands to false when player comes out of range | Pass |

1. GhostMovement:

| Method | Test cases | Expected | Results |
| --- | --- | --- | --- |
| void Start(){player = GameObject.Find(&quot;Player&quot;);direction = Random.Range(1, 5);animator.SetInteger(&quot;Direction&quot;, direction);} | The ghost can starts the game with all 4 directions | Set the ghost direction at the start of the game | Pass |
| privatevoid Attack(){animator.SetBool(&quot;Attack&quot;, true);Vector2 targetPosition = player.transform.position;distanceX = Mathf.Abs(targetPosition.x - transform.position.x);distanceY = Mathf.Abs(targetPosition.y - transform.position.y);if (transform.position.x \&lt; targetPosition.x){if (transform.position.y \&lt; targetPosition.y){if (distanceX \&lt; distanceY){animator.SetFloat(&quot;Horizontal&quot;, 0);animator.SetFloat(&quot;Vertical&quot;, 1);animator.SetInteger(&quot;Direction&quot;, 1);}elseif (distanceX \&gt; distanceY){animator.SetFloat(&quot;Vertical&quot;, 0);animator.SetFloat(&quot;Horizontal&quot;, 1);animator.SetInteger(&quot;Direction&quot;, 2);}}elseif (transform.position.y \&gt; targetPosition.y){if (distanceX \&lt; distanceY){animator.SetFloat(&quot;Horizontal&quot;, 0);animator.SetFloat(&quot;Vertical&quot;, -1);animator.SetInteger(&quot;Direction&quot;, 3);}elseif (distanceX \&gt; distanceY){animator.SetFloat(&quot;Vertical&quot;, 0);animator.SetFloat(&quot;Horizontal&quot;, 1);animator.SetInteger(&quot;Direction&quot;, 2);}}}elseif (transform.position.x \&gt; targetPosition.x){if (transform.position.y \&lt; targetPosition.y){if (distanceX \&lt; distanceY){animator.SetFloat(&quot;Horizontal&quot;, 0);animator.SetFloat(&quot;Vertical&quot;, 1);animator.SetInteger(&quot;Direction&quot;, 1);}elseif (distanceX \&gt; distanceY){animator.SetFloat(&quot;Vertical&quot;, 0);animator.SetFloat(&quot;Horizontal&quot;, -1);animator.SetInteger(&quot;Direction&quot;, 4);}}elseif (transform.position.y \&gt; targetPosition.y){if (distanceX \&lt; distanceY){animator.SetFloat(&quot;Horizontal&quot;, 0);animator.SetFloat(&quot;Vertical&quot;, -1);animator.SetInteger(&quot;Direction&quot;, 3);}elseif (distanceX \&gt; distanceY){animator.SetFloat(&quot;Vertical&quot;, 0);animator.SetFloat(&quot;Horizontal&quot;, -1);animator.SetInteger(&quot;Direction&quot;, 4);}}} | The ghost face towards player when player move around in 4 directions | Set the direction of the ghost according to attacking direction (towards player) | Pass |
| privatevoid Shoot(){Instantiate(projectile, transform.position, Quaternion.identity);} | Shoot in many directions | Shoot the fireball | Pass |
| void Update(){if (ghost.attack == true){Attack();} elseif (ghost.attack == false){animator.SetBool(&quot;Attack&quot;, false);}} |
 | Check if the ghost was able to attack | Pass |

1. GhostStats:

| Method | Test cases | Expected | Results |
| --- | --- | --- | --- |
| privatevoid Initalize(){health += 6f \* (level - 1);currentHealth = health;damage += 1.5f \* (level - 1);armor += 0 \* (level - 1);exp += 2 \* (level - 1);} | Run with different values. | Initiate the base stats for the ghost | Pass |
| publicvoid TakeDamage(float damageTake){currentHealth -= (100f / (100f + armor)) \* damageTake;if (currentHealth \&lt;= 0){Destroy(gameObject);}} | Run with different values | Correct health loss calculation | Pass |

1. SpawnGhost:

| Method | Test cases | Expected | Results |
| --- | --- | --- | --- |
| privatevoid Start(){checkGhost = Instantiate(ghost, transform.position, Quaternion.identity);currentTime = waitTime;}
 | Spawn at different locations on the map. | Spawn an initial ghost | Pass |
| privatevoid Update(){if (checkGhost == null){if (currentTime \&gt; 0){currentTime -= Time.deltaTime;}elseif (currentTime \&lt;= 0){checkGhost = Instantiate(ghost, transform.position, Quaternion.identity);currentTime = waitTime;}}} | Spawn then kill it with different locations and waitTime | If there is no ghost in the area in waitTime seconds, spawn another ghost. | Pass |

1. Goblin:

1. Atacked:

| Method | Test cases | Expected | Results |
| --- | --- | --- | --- |
| privatevoid OnTriggerEnter2D(Collider2D other){if (other.tag == &quot;Player&quot;){attack = true;}} | Player comes from different angles | Set the goblin attack commands to true when player comes in range | Pass |
| privatevoid OnTriggerExit2D(Collider2D other) {if (other.tag == &quot;Player&quot;){attack = false;}} | Player exits from different angles | Set the goblin attack commands to false when player comes out of range | Pass |

1. GoblinMovement

| Method | Test cases | Expected | Results |
| --- | --- | --- | --- |
| private IEnumerator Start(){player = GameObject.Find(&quot;Player&quot;);stopTimeStop = stopTime;moveTimeStop = moveTime;direction = Random.Range(1, 5);yieldreturnnew WaitForSeconds(4);busy = false;} | Set up with different values | Set the correct values to the valuables for further uses | Pass |
| privatevoid resetAnimation(){animator.SetFloat(&quot;Horizontal&quot;, 0);animator.SetFloat(&quot;Vertical&quot;, 0);animator.SetFloat(&quot;Speed&quot;, 0);} | Goblin stops moving and Goblin stops attacking | Reset the goblin moving animations to attack | Pass |
| privatevoid setNextDirection(){if (direction == 1){direction = 3;}elseif (direction == 2){direction = 4;} elseif (direction == 3){direction = 1;} elseif (direction == 4){direction = 2;}}
 | Different locations in the map | Set the goblin to face the opposite direction while roaming | Pass |
| privatevoid Update(){if (thePlayer.attack == false){animator.SetBool(&quot;Attack&quot;, false);if (enemy.recognized == false){if (busy == false){moveIdleState();}}elseif (enemy.recognized == true){chasePlayer();}}elseif (thePlayer.attack == true){resetAnimation();Attack();}} | Player comes from different angles, run away in every direction. | Set the goblin to chase the player if in range, or stay idle if not. | Pass |
|
privatevoid moveIdleState(){if (moveTimeStop \&gt; 0){moveIdle();moveTimeStop -= Time.deltaTime;}elseif (moveTimeStop \&lt;= 0){resetAnimation();if (stopTimeStop \&gt; 0){stopTimeStop -= Time.deltaTime;}elseif (stopTimeStop \&lt;= 0){moveTimeStop = moveTime;stopTimeStop = stopTime;setNextDirection();}}} | Different locations on the map | Set the goblin to roam around the area if there is no player around | Pass |
| privatevoid chasePlayer(){Vector2 targetPosition = player.transform.position;transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed \* Time.deltaTime);distanceX = Mathf.Abs(targetPosition.x - transform.position.x);distanceY = Mathf.Abs(targetPosition.y - transform.position.y);if (transform.position.x \&lt; targetPosition.x){if (transform.position.y \&lt; targetPosition.y){if (distanceX \&lt; distanceY){animator.SetFloat(&quot;Horizontal&quot;, 0);animator.SetFloat(&quot;Vertical&quot;, 1);animator.SetFloat(&quot;Speed&quot;, 1);animator.SetInteger(&quot;Direction&quot;, 1);}elseif (distanceX \&gt; distanceY){animator.SetFloat(&quot;Vertical&quot;, 0);animator.SetFloat(&quot;Horizontal&quot;, 1);animator.SetFloat(&quot;Speed&quot;, 1);animator.SetInteger(&quot;Direction&quot;, 2);}}elseif (transform.position.y \&gt; targetPosition.y){if (distanceX \&lt; distanceY){animator.SetFloat(&quot;Horizontal&quot;, 0);animator.SetFloat(&quot;Vertical&quot;, -1);animator.SetFloat(&quot;Speed&quot;, 1);animator.SetInteger(&quot;Direction&quot;, 3);}elseif (distanceX \&gt; distanceY){animator.SetFloat(&quot;Vertical&quot;, 0);animator.SetFloat(&quot;Horizontal&quot;, 1);animator.SetFloat(&quot;Speed&quot;, 1);animator.SetInteger(&quot;Direction&quot;, 2);}}}elseif (transform.position.x \&gt; targetPosition.x){if (transform.position.y \&lt; targetPosition.y){if (distanceX \&lt; distanceY){animator.SetFloat(&quot;Horizontal&quot;, 0);animator.SetFloat(&quot;Vertical&quot;, 1);animator.SetFloat(&quot;Speed&quot;, 1);animator.SetInteger(&quot;Direction&quot;, 1);}elseif (distanceX \&gt; distanceY){animator.SetFloat(&quot;Vertical&quot;, 0);animator.SetFloat(&quot;Horizontal&quot;, -1);animator.SetFloat(&quot;Speed&quot;, 1);animator.SetInteger(&quot;Direction&quot;, 4);}}elseif (transform.position.y \&gt; targetPosition.y){if (distanceX \&lt; distanceY){animator.SetFloat(&quot;Horizontal&quot;, 0);animator.SetFloat(&quot;Vertical&quot;, -1);animator.SetFloat(&quot;Speed&quot;, 1);animator.SetInteger(&quot;Direction&quot;, 3);}elseif (distanceX \&gt; distanceY){animator.SetFloat(&quot;Vertical&quot;, 0);animator.SetFloat(&quot;Horizontal&quot;, -1);animator.SetFloat(&quot;Speed&quot;, 1);animator.SetInteger(&quot;Direction&quot;, 4);}}}} | Player runs away in every direction | Set the goblin to chase the player and turning the right direction towards the player | Pass |

1. GoblinStats:

| Method | Test cases | Expected | Results |
| --- | --- | --- | --- |
| privatevoid Initalize(){health += 20f \* (level - 1);currentHealth = health;damage += 0.7f \* (level - 1);armor += 0.2f \* (level - 1);exp += 5 \* (level - 1);} | Set up with different values | Initiate the base stats for the goblin | Pass |
| publicvoid TakeDamage(float damageTake){currentHealth -= (100f / (100f + armor)) \* damageTake;if (currentHealth \&lt;= 0){Destroy(gameObject);}} | Set up with different values | Correct health loss calculation | Pass |

1. SpawnGoblin:

| Method | Test cases | Expected | Results |
| --- | --- | --- | --- |
| privatevoid Start(){checkGoblin = Instantiate(goblin, transform.position, Quaternion.identity);currentTime = waitTime;} | Different locations on the map | Spawn an initial goblin | Pass |
| privatevoid Update(){if (checkGoblin == null){if (currentTime \&gt; 0){currentTime -= Time.deltaTime;}elseif (currentTime \&lt;= 0){checkGoblin = Instantiate(goblin, transform.position, Quaternion.identity);currentTime = waitTime;}}} | Spawn then kill it with different locations and waitTime | If there is no ghost in the area in waitTime seconds, spawn another goblin. | Pass |

1. Player:

1. PlayerMovement:

| Method | Test cases | Expected | Results |
| --- | --- | --- | --- |
| privatevoid Attack(){if (Input.GetKeyDown(&quot;space&quot;)){attacking = true;animator.SetBool(&quot;Attack&quot;, true);}} | Holding, pressing spacebar in different speed | Set the player to attack when space bar is pressed. | Pass |
| privatevoid Hit(){Collider2D[] hitGoblins = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, goblinLayers);for (int i = 0; i \&lt; hitGoblins.Length; i++){hitGoblins[i].GetComponent\&lt;GoblinStats\&gt;().TakeDamage(stats.damage);}Collider2D[] hitGhosts = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, ghostLayers);for (int i = 0; i \&lt; hitGhosts.Length; i++){hitGhosts[i].GetComponent\&lt;GhostStats\&gt;().TakeDamage(stats.damage);}} | Set up with different values | Inflict correct amount of damage to monsters hit | Pass |
| privatevoid BackToMove(){attacking = false;animator.SetBool(&quot;Attack&quot;, false);} | Stop attacking in all 8 directions | Reset the animations if not attacking | Pass |
| privateint setDirection(Vector2 movement){int direct = direction;if (movement.y == 1){direct = 1;}elseif (movement.x == 1){direct = 2;}elseif (movement.y == -1){direct = 3;}elseif (movement.x == -1){direct = 4;}return direct;} | Set to all 8 directions | Set the directions for player movement | Pass |
| privatevoid Move(){rigid.MovePosition(rigid.position + movement \* movementSpeed \* Time.deltaTime);} | Move the character to different locations on the map | Move the actual player model around the map | Pass |

1. PlayerStats

| Method | Test cases | Expected | Results |
| --- | --- | --- | --- |
| privatevoid updateNumberOfPotion(){healthPotionText.text = healthPotion.ToString();maxHPPotionText.text = maxHPPotion.ToString();speedPotionText.text = speedPotion.ToString();attackPotionText.text = attackPotion.ToString();defensePotionText.text = defensePotion.ToString();} | Set up with different values | Update the number of potions | Pass |
| privatevoid initializeStats(){level = 1;maxExp = 280f;currentExp = 0;maxHealth = 523f;currentHealth = maxHealth;damage = 60f;defense = 30f;} | Set up with different values | Initiate player base stats | Pass |

1. Potions:

| Methods | Test cases | Expected | Results |
| --- | --- | --- | --- |
| privatevoid OnTriggerEnter2D(Collider2D other){if (other.tag == &quot;Player&quot;){FindObjectOfType\&lt;PlayerStats\&gt;().addAttackPotion();Destroy(gameObject);}} | Player picks up at different angles | The potions disappear after pick up and add 1 potions to players inventory | Pass |

1.
## **SUMARRY**

- The code so far has no big mistakes that can cause a crash.

- Every minor bugs have been fixed immediately.

- All tests above were tested on built-in playtest in Unity.