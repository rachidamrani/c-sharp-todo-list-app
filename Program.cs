bool shallExit = true;

List<string> todos = new List<string>();
Console.WriteLine("Hello !");

do
{
    Console.WriteLine();
    Console.WriteLine("What to you want to do ?");
    Console.WriteLine();
    Console.WriteLine("[S]ee All TODOS");
    Console.WriteLine("[A]dd a new TOOD");
    Console.WriteLine("[R]emove a TOOD");
    Console.WriteLine("[E]xit");

    string? userInput = Console.ReadLine();

    switch (userInput.ToLower())
    {
        case "a":
            AddNewTodo();
            shallExit = false;
            break;
        case "s":
            ShowAllTodos();
            shallExit = false;
            break;
        case "r":
            RemoveTodo();
            shallExit = false;
            break;
        case "e":
            Console.WriteLine("Goodbye !");
            shallExit = true;
            break;
        default:
            Console.WriteLine("Invalid choice !");
            shallExit = false;
            break;
    }
} while (shallExit == false);



void AddNewTodo()
{
    string descriptionInput;
    do
    {
        Console.WriteLine("Describe your todo : ");
        descriptionInput = Console.ReadLine();
    } while (descriptionInput.Length == 0);

    todos.Add(descriptionInput);
}

void ShowAllTodos()
{
    if (todos.Count == 0)
    {
        PrintEmptyTodosListMessage();
        Console.WriteLine("Do you want to add a new todo ? [Y] or [N]");
        string userInput = Console.ReadLine();

        if (userInput.ToLower() == "y") AddNewTodo();
        else return;
    }

    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1} - {todos[i]}");
    }
}


void RemoveTodo()
{
    if (todos.Count == 0)
    {
        PrintEmptyTodosListMessage();
        return;
    }
    else
    {
        bool parsingResult = false;
        do
        {
            Console.WriteLine("What todo you want to remove ?");
            ShowAllTodos();
            string userChoice = Console.ReadLine();
            parsingResult = int.TryParse(userChoice, out int index) && (index >= 1) && (index <= todos.Count);

            if (parsingResult)
            {
                todos.RemoveAt(index - 1);
            }
            else
            {
                Console.WriteLine("Invalid choice! please try again");
            }
        } while (parsingResult == false);
    }
}


void PrintEmptyTodosListMessage()
{
    Console.WriteLine("Your todos list is empty for now! ");
}