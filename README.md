# Pang
 Pang - Communix Home Assignment
 
 Welcome to my version of Pang!
 
 How to play:
        - Use the arrow keys to move the player
        - Press 'Spacebar' to shoot
        
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
        - Add a 2 player support for PC - adding another player would mean I would have to change the current implementation of the PlayerController
