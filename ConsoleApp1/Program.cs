using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphNode parentChoise = new GraphNode()
            {
                Id = 1,
                Question = "What do you want?"
            };
            GraphNode foodChoice = new GraphNode()
            {
                Id = 2,
                Question = "What type of food you want?",
                ParentAnswer = "food"
            };
            GraphNode drinksChoice = new GraphNode()
            {
                Id = 3,
                Question = "What type of drinks you want?",
                ParentAnswer = "drinks"
            };
            GraphNode pizzaChoice = new GraphNode()
            {
                Id = 4,
                Question = "What type of pizza you want?",
                ParentAnswer = "pizza"
            };
            GraphNode pastaChoice = new GraphNode()
            {
                Id = 5,
                Question = "What type of pasta want?",
                ParentAnswer = "pasta"
            };
            GraphNode traditionalFoodChoice = new GraphNode()
            {
                Id = 6,
                Question = "You are all set",
                ParentAnswer = "traditional food"
            };
            GraphNode typeOfPizzaChoice = new GraphNode()
            {
                Id = 7,
                Question = "You are all set",
                ParentAnswer = "margherita"
            };
            GraphNode anotherTypeOfPizzaChoice = new GraphNode()
            {
                Id = 8,
                Question = "You are all set",
                ParentAnswer = "pepperoni"
            };
            GraphNode typeOfPastaChoice = new GraphNode()
            {
                Id = 9,
                Question = "You are all set",
                ParentAnswer = "bucatini"
            };
            GraphNode anotherTypeOfPastaChoice = new GraphNode()
            {
                Id = 10,
                Question = "You are all set",
                ParentAnswer = "penne"
            };
            GraphNode typeOfTraditionalFoodChoice = new GraphNode()
            {
                Id = 10,
                Question = "You are all set",
                ParentAnswer = "beans"
            };

            foodChoice.Childs.Add(pizzaChoice);
            foodChoice.Childs.Add(pastaChoice);
            foodChoice.Childs.Add(traditionalFoodChoice);

            parentChoise.Childs.Add(foodChoice);
            parentChoise.Childs.Add(drinksChoice);

            pizzaChoice.Childs.Add(typeOfPizzaChoice);
            pizzaChoice.Childs.Add(anotherTypeOfPizzaChoice);

            pastaChoice.Childs.Add(typeOfPastaChoice);
            pastaChoice.Childs.Add(anotherTypeOfPastaChoice);

            traditionalFoodChoice.Childs.Add(typeOfTraditionalFoodChoice);

            ShowChoice(parentChoise);
        }

        private static void ShowChoice(GraphNode currentNode)
        {
            Console.Clear();
            Console.WriteLine(currentNode.Question);
            foreach (GraphNode child in currentNode.Childs)
            {
                Console.WriteLine(child.ParentAnswer);
            }
            string answer = Console.ReadLine().ToLower();
            GraphNode nextNode = currentNode.SelectNextChild(answer);
            if (nextNode != null)
            {
                ShowChoice(nextNode);
            }
            else
            {
                ShowChoice(currentNode);
            }
        }
    }
    class GraphNode
    {
        public int Id { get; set; }
        public string ParentAnswer { get; set; }
        public string Question { get; set; }
        public List<GraphNode> Childs { get; set; } = new List<GraphNode>();
        public GraphNode SelectNextChild(string answer)
        {
            GraphNode result = null;
            foreach (GraphNode child in Childs)
            {
                if (answer == child.ParentAnswer)
                {
                    result = child;
                    break;
                }
            }
            return result;
        }
    }

}
