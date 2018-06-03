# Project TOH
This is a *digital toy project* that demonstrates use of Unity physics to implement a Tower of Hanoi-like experience. 

## Major Challenges

The first challenge was how to implement a fun and physical control mechanic. I decided to take advantage of Unity's 2D physics to achieve this, and after some research/playing around ended up using a `SpringJoint2D` component to make a wacky sort of feeling to the controls. 

The next challenge was how to properly simulate the physical interaction between a ring and a pin, since Unity didn't have a primitive object that represented even a simple cylindrical collider. To do this, I used the `CompositeCollider2D` component to combine two separate `BoxCollider2D` components situated on the leftmost and rightmost areas of each Ring prefab. The bounds of the BoxCollider2Ds are adjusted give an illusion of a hole in the middle.

The most fun I had, and probably where a majority of my time was spent, was on implementing the one rule regarding limiting of rings to be dropped on pins (where a ring can only be dropped onto a pin with either a smaller ring on top of the stack or no ring at all). I was choosing between implementing position/screen space checks and using Unity's physics again, but thought that the former was a brute force way of solving this challenge. I again ended up taking advantage of Unity's physics functionality, and used a RayCast to check for the topmost ring on a pin.


## Coding Thoughts

I wanted to give emphasis on how I believed we should use techniques that promote decoupling in code. I used two concepts that helped me achieve this: 

- GameSystem locator object which uses the service locator pattern to mainly store interface to-object mappings (i.e. `IAudioHandler`) thereby partly achieving Dependency injection. In this case, the GameSystem object does not employ strict rules (i.e. generic constraints) to what objects could register to it so it also holds strong references to some objects (i.e. `RingRegistry`).
- Event-based UI system (via the EventBroadcaster object) I've had my fair share of UI nightmares in the form of strong references to scene objects existing within UI-only components. You move/update/delete that scene object, the UI fails. With an event-based system to handle and serve UI functionality, I can freely update my UI without having to think of objects going null in UI logic (and vice-versa). It also has the potential to lessen time coding repetitive stuff. Both the `UINotification` and `UIToggleButton` components both show how I implemented this.
	
Again, the purpose of this project was not so much on code quality (although this is upheld in parts where it is downright absurd not to be), but to show how I think we can implement game mechanics without re-inventing too much, and, instead using what we already have within Unity itself.
