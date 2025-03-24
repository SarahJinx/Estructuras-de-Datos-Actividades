using System;
using System.Collections.Generic;

class ActionStack
{
    private Stack<string> stack;

    public ActionStack()
    {
        stack = new Stack<string>();
    }

    public void Push(string action)
    {
        stack.Push(action);
        Console.WriteLine($"Action added: {action}");
    }

    public void Pop(List<string> availableActions)
    {
        if (IsEmpty())
        {
            Console.WriteLine("No actions to undo.");
        }
        else
        {
            string action = stack.Pop();
            Console.WriteLine($"Action undone: {action}");
            availableActions.Add(action);  // Add the undone action back to available actions
        }
    }

    public void DisplayStack()
    {
        if (IsEmpty())
        {
            Console.WriteLine("The stack is empty.");
        }
        else
        {
            Console.WriteLine("Current stack of actions:");
            foreach (var action in stack)
            {
                Console.WriteLine(action);
            }
        }
    }

    public bool IsEmpty()
    {
        return stack.Count == 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ActionStack characterActions = new ActionStack();
        List<string> actions = new List<string> { "ESQUIVAR", "SALTAR", "ATACAR", "DEFENDER" };
        List<string> availableActions = new List<string>(actions);
        int option = 0;

        while (true)
        {
            Console.Clear(); // Clear the screen before showing the menu
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add action to the stack");
            Console.WriteLine("2. Undo the last action");
            Console.WriteLine("3. Show current stack of actions");
            Console.WriteLine("4. Exit");

            Console.Write("Choose an option: ");
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        if (availableActions.Count == 0)
                        {
                            Console.WriteLine("No more actions available to add.");
                            WaitForKeyPress();
                            break;
                        }

                        Console.WriteLine("Choose an action to add:");
                        for (int i = 0; i < availableActions.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {availableActions[i]}");
                        }

                        int actionChoice;
                        Console.Write("Enter the number of the action: ");
                        if (int.TryParse(Console.ReadLine(), out actionChoice) && actionChoice >= 1 && actionChoice <= availableActions.Count)
                        {
                            string selectedAction = availableActions[actionChoice - 1];
                            characterActions.Push(selectedAction);
                            availableActions.Remove(selectedAction); // Remove action from the available list
                            WaitForKeyPress();
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                            WaitForKeyPress();
                        }
                        break;

                    case 2:
                        characterActions.Pop(availableActions); // Pass the availableActions list to update it
                        WaitForKeyPress();
                        break;

                    case 3:
                        characterActions.DisplayStack();
                        WaitForKeyPress();
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        WaitForKeyPress();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                WaitForKeyPress();
            }
        }
    }

    // Function to wait for a key press before continuing
    static void WaitForKeyPress()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
