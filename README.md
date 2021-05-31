# Pang
 Pang - Communix Home Assignment
 
 Welcome to my version of Pang!
 
 How to play: <br/>
        - Use the arrow keys to move the player <br/>
        - Press 'Spacebar' to shoot
        
 Mobile: <br/>
        - Use the arrow buttons to move the player (bottom left of the screen) <br/>
        - Press the 'Target' button to shoot (bottom right of the screen)
        
        Game Objective:
        Shoot all the balls on the screen without being hit by any of the balls
        
        Implemented Extra Credit:
        - Architectural Design - MVC using dependency injection. As all the existing objects interact with one another using only abstract methods of the abstract base class there is a strong decoupling in the code providing the needed restrictions for a strong architecture
        - Three levels with an ascending difficulty 
        - Custom shader - player dissolve on level end. Implemented with both a shader and an animation with a StateMachineBehaviour
        - Custom sounds - popping sounds for each ball size, as well as a shooting projectile sound
        
        Things to consider (or things I would change if I took my time):
        - It is possible that the current implementation might cause some lag when there is a large number of balls on the screen - creating balls and destroying them should be implemented using an object pool instead. We are able to count the maximum number of each type of ball that could appear on the screen at a certain time. Maybe consider producing a list (or possibly several lists) to be used as an object pool.
        - Add background music - it's a little dull at the moment.
        - The game is built for a 1280X720 Display and doesn't respond well to wider screen resolutions - the side walls do not perfectly align with the camera bounds. Didn't want to dive deeply into fixing that as I feared I may "break" something else and lose points on account of the game not performing as expected. It is still playable on wider screens, but you may encounter "invisible wall" effects on the left and right side of the screen
        - Add a 2 player support for PC - adding another player would mean I would have to change the current implementation of the PlayerController
        - Change the walls to edge colliders and make them "stick" to the camera borders
        - Add powerups for multiple bullets and different types of projectiles
