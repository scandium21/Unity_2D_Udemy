# Intro

Documentation on the creation flow of a basic state-machine based text adventure game using scriptable objects in Unity.

## Step 1 - Creating UI (Canvas)

All UI elements in Unity exist on Canvas. First, create Canvas from hierarchy window. Then build each element on the Canvas, in this case:

- the textbox 
- the heading title textbox 
- the background image
- the background image for the appearence as frame
- the heading title background image

## Step 2 - Creating "Game" game object

This is the game flow where the main C# script is associated to. Created from hieraichy window --> "Create Empty".

## Step 3 - Creating the main C# code that is associated with "Game" object (Add component)

In the main C# script (AdventureGame.cs), we defined two instance (or member) variables that are available for the whole class: 

1. textComponent of class Text (from UnitiEngine.UI namespace)
2. startingState of class State

textComponent is associated with the "Story Text" textbox we created in the Canvas as a part of the UI. The reason to use this is to be able to display and update the text in our text adventure game UI. Essentially, the whole text adventure game layout is presented in the form of a UI, which in other advanced games just serves as the starting menu.

startingState is associated with the "Starting State" asset we defined and created using scriptable object. The reason of using this is because we want to use Unity to display and manipulate game text, insteading of writing text as strings in the code. So each state is defined as a stand-alone class inheriting from ScriptableObject class (`public class State : ScriptableObject`) that has a string instance variable and a public method to return that string. 

```
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10,14)] [SerializeField] string storyText;

    public string GetStateStory ()
    {
        return storyText;
    }
}
```



