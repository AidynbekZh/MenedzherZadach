using System;
using System.Collections.Generic;

class TaskManager
{
    class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }

    // Список задач в менеджере задач
    static List<Task> tasks = new List<Task>();

    // Текущий идентификатор для новых задач
    static int currentId = 1;

// Основной цикл программы
while (true)
{
    // Вывод меню менеджера задач
    Console.WriteLine("Менеджер задач:\n" +
                      "1. Добавить задачу\n" +
                      "2. Показать все задачи\n" +
                      "3. Удалить задачу\n" +
                      "4. Завершить задачу\n" +
                      "5. Выход");

    // Получение выбора пользователя
    int choice = GetIntInput("Введите номер действия: ");

    // Обработка выбора пользователя
    switch (choice)
    {
        case 1:
            AddTask(); // Добавление новой задачи
            break;
        case 2:
            ShowTasks(); // Показ всех задач
            break;
        case 3:
            DeleteTask(); // Удаление задачи
            break;
        case 4:
            CompleteTask(); // Завершение задачи
            break;
        case 5:
            Environment.Exit(0); // Выход из программы
            break;
    }
}

// Добавление новой задачи в список
static void AddTask()
{
    Console.Write("Введите название задачи: ");
    string name = Console.ReadLine();

    tasks.Add(new Task { Id = currentId++, Name = name, IsCompleted = false });
    Console.WriteLine("Задача добавлена.");
}

// Показ всех задач в списке
static void ShowTasks()
{
    Console.WriteLine("Список задач:");

    foreach (var task in tasks)
    {
        string status = task.IsCompleted ? "[Выполнено] " : "";
        Console.WriteLine($"{task.Id}. {status}{task.Name}");
    }
}

// Удаление задачи из списка
static void DeleteTask()
{
    // Получение ID задачи для удаления
    int taskId = GetIntInput("Введите ID задачи для удаления: ");
    Task taskToRemove = tasks.Find(t => t.Id == taskId);

    if (taskToRemove != null)
    {
        tasks.Remove(taskToRemove);
        Console.WriteLine("Задача удалена.");

        // После удаления задачи пересчитываем идентификаторы для оставшихся задач
        for (int i = 0; i < tasks.Count; i++)
        {
            tasks[i].Id = i + 1;
        }
    }
    else
    {
        Console.WriteLine("Задача не найдена.");
    }
}

// Завершение выполнения задачи
static void CompleteTask()
{
    // Получение ID задачи для завершения
    int taskId = GetIntInput("Введите ID задачи для завершения: ");
    Task taskToComplete = tasks.Find(t => t.Id == taskId);

    if (taskToComplete != null)
    {
        taskToComplete.IsCompleted = true;
        Console.WriteLine("Задача завершена.");
    }
    else
    {
        Console.WriteLine("Задача не найдена.");
    }
}

// Получение целочисленного ввода от пользователя
static int GetIntInput(string prompt)
{
    int input;
    Console.Write(prompt);
    while (!int.TryParse(Console.ReadLine(), out input)) //преобразовать введенную строку в целое число
    {
        Console.Write("Введите корректное число: ");
    }
    return input;
}