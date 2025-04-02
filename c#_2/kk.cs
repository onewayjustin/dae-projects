using System;
using System.Collections.Generic;

public class Program
{
    // Define Enum for player states
    public enum PlayerState
    {
        Idle = 1,
        Moving = 2,
        Attacking = 3
    }

    // Function to calculate damage
    public static int CalculateDamage(int attackPower, int defense)
    {
        int damage = attackPower - defense;
        return damage < 0 ? 0 : damage; // Ensure damage doesn't go below 0
    }

    // Function to get an inventory item by index
    public static string GetInventoryItem(int index, List<string> inventory)
    {
        if (index >= 0 && index < inventory.Count)
        {
            return inventory[index];
        }
        else
        {
            return "Item not found";
        }
    }

    public static void Main()
    {
        // Initialize variables
        int playerHealth = 100;
        int enemyHealth = 50;
        int attackPower = 25;
        int defense = 10;

        // List to simulate an inventory
        List<string> inventory = new List<string> { "Sword", "Shield", "Potion" };

        // Dictionary to manage key-value pairs (item -> quantity)
        Dictionary<string, int> itemInventory = new Dictionary<string, int>
        {
            { "Sword", 1 },
            { "Shield", 1 },
            { "Potion", 3 }
        };

        // Set initial player state
        PlayerState currentState = PlayerState.Idle;
        Console.WriteLine($"Player is in state: {currentState}");

        // Game loop: continue until the player or enemy dies
        while (playerHealth > 0 && enemyHealth > 0)
        {
            // Display current health status
            Console.WriteLine($"Player Health: {playerHealth}, Enemy Health: {enemyHealth}");
            
            // Ask player for an action
            Console.Write("Enter action (attack/defend/run): ");
            string action = Console.ReadLine().ToLower();

            // Switch statement for action handling
            switch (action)
            {
                case "attack":
                    int damage = CalculateDamage(attackPower, defense);
                    enemyHealth -= damage;
                    Console.WriteLine($"Enemy takes {damage} damage. Remaining enemy health: {enemyHealth}");
                    break;

                case "defend":
                    Console.WriteLine("Player defends!");
                    break;

                case "run":
                    Console.WriteLine("You ran away!");
                    break;

                default:
                    Console.WriteLine("Invalid action!");
                    break;
            }

            // Simulate the enemy attacking back if it's still alive
            if (enemyHealth > 0)
            {
                playerHealth -= 10; // Enemy deals fixed damage
                Console.WriteLine($"Player takes 10 damage. Remaining health: {playerHealth}");
            }

            // Nested decision structure: Check for victory or game over
            if (playerHealth <= 0)
            {
                Console.WriteLine("Game Over!");
                break;
            }
            else if (enemyHealth <= 0)
            {
                Console.WriteLine("Victory!");
                break;
            }
        }

        // Example of nested loop (iterating over a 2D grid)
        Console.WriteLine("Demonstrating nested loop:");
        for (int i = 0; i < 3; i++)  // Outer loop
        {
            for (int j = 0; j < 3; j++)  // Inner loop
            {
                Console.WriteLine($"Grid position: ({i}, {j})");
            }
        }

        // Example of modifying list (removing an item)
        inventory.Remove("Potion");
        Console.WriteLine("Inventory after removing Potion:");
        foreach (var item in inventory)
        {
            Console.WriteLine(item);
        }

        // Example of modifying dictionary (adding a new item)
        itemInventory["Helmet"] = 1;
        Console.WriteLine("Updated inventory (dictionary):");
        foreach (var item in itemInventory)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        // Example of performing operations on the inventory
        string item = GetInventoryItem(1, inventory); // Get item by index
        Console.WriteLine($"Item retrieved: {item}");
    }
}

