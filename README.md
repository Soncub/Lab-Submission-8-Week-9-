## Object Pool.
The PlayerShooter script has an ObjectPool attached to it, the ObjectPool takes a prefab object and creates multiple copies of it.
Then, once Pump() is called, the ObjectPool goes through its list of objects and checks if any are deactivated. If one is, it returns and activates said Object.

## Builder
The TargetManager creates 3 TargetBuilders and feeds it data via "Add" methods to create the desired Target Configurations.
Then the TargetBuilders Build several in-game clones of the Target and return them to the TargetManager, which feeds the collections into 3 TargetLines.
The TargetLines handle the Targets' movement.

## Observer
The Game Manager subscribes to a global Action on the Target class to recieve a points addition whenever a target is hit.
It also subscribes to the end event of a custom timer.


### ISaveable
ISaveable is a simple generic class with Save() and Load() methods and a type parameter. (Currently attached to TargetManager with type SavedJsonData)

## SaveEnemyPositions
A MonoBehavior in the scene which listens for "S" and "L" presses and Saves/Loads data between the TargetManager and a Json File.

## ScoreSaver
A PlayerData stores the integer value of the player's score. GameData is responsible for saving and loading the data from a given BYTE file. The score is called to be saved every time the score is updated, so it is in sync with the actions of the player. Follows a standard practice for BinaryFormatting.