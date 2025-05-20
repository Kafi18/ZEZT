using System;

namespace MysteryMansion
{
    class Game
    {
        // Игровые состояния
        private bool _hasKey = false;
        private bool _knowsSecret = false;
        private bool _hasMap = false;
        private bool _metAlly = false;
        private int _trustPoints = 0;
        private string _playerName = "";

        // Основной метод игры
        public void Run()
        {
            InitializeGame();
            Chapter1();
        }

        // Инициализация игры
        private void InitializeGame()
        {
            Console.WriteLine("=== ТАЙНА ЗАБРОШЕННОГО ПОМЕСТЬЯ ===");
            Console.Write("Введите имя вашего персонажа: ");
            _playerName = Console.ReadLine();
            Console.Clear();
        }

        // Глава 1: Пробуждение
        private void Chapter1()
        {
            while (true)
            {
                DisplayChapterTitle("ГЛАВА 1: ПРОБУЖДЕНИЕ");
                Console.WriteLine($"{_playerName}, вы просыпаетесь в незнакомой комнате старинного поместья.");

                var choice = GetChoice(
                    "1. Осмотреться вокруг",
                    "2. Попробовать открыть дверь",
                    "3. Кричать о помощи",
                    "4. Выйти из игры");

                switch (choice)
                {
                    case 1:
                        ExamineRoom();
                        break;
                    case 2:
                        TryOpenDoor();
                        break;
                    case 3:
                        ScreamForHelp();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        // Осмотр комнаты
        private void ExamineRoom()
        {
            Console.WriteLine("\nВ комнате вы видите:");
            var choice = GetChoice(
                "1. Старый ключ на столе",
                "2. Записку на подоконнике",
                "3. Странный символ на стене",
                "4. Вернуться");

            switch (choice)
            {
                case 1:
                    _hasKey = true;
                    Console.WriteLine("Вы взяли ключ. Он выглядит подходящим для двери.");
                    break;
                case 2:
                    _knowsSecret = true;
                    Console.WriteLine("На записке написано: 'Не доверяйте теням'.");
                    break;
                case 3:
                    Console.WriteLine("Символ светится при вашем прикосновении!");
                    _trustPoints++;
                    break;
            }
        }

        // Попытка открыть дверь
        private void TryOpenDoor()
        {
            if (_hasKey)
            {
                Console.WriteLine("\nВы открываете дверь и попадаете в длинный коридор.");
                Chapter2();
                return;
            }
            Console.WriteLine("\nДверь заперта. Нужно найти ключ.");
        }

        // Крик о помощи
        private void ScreamForHelp()
        {
            Console.WriteLine("\nВаши крики привлекли внимание...");
            var choice = GetChoice(
                "1. Продолжить звать на помощь",
                "2. Затаиться");

            if (choice == 1)
            {
                ShowEnding(1, "Дверь распахивается, и вас хватают темные силуэты...", false);
            }
            else
            {
                Console.WriteLine("Шаги проходят мимо. Вы в безопасности... пока.");
            }
        }

        // Глава 2: Коридор тайн
        private void Chapter2()
        {
            DisplayChapterTitle("ГЛАВА 2: КОРИДОР ТАЙН");
            Console.WriteLine("Перед вами три двери и лестница наверх:");

            var choice = GetChoice(
                "1. Красная дверь (помечена черепом)",
                "2. Синяя дверь (слышны голоса)",
                "3. Зеленая дверь (пахнет травами)",
                "4. Подняться по лестнице");

            switch (choice)
            {
                case 1:
                    RedDoor();
                    break;
                case 2:
                    BlueDoor();
                    break;
                case 3:
                    GreenDoor();
                    break;
                case 4:
                    Stairs();
                    break;
            }
        }

        // Методы для различных вариантов выбора (RedDoor, BlueDoor и т.д.)
        private void RedDoor()
        {
            Console.WriteLine("\nЗа дверью - лаборатория алхимика.");
            var choice = GetChoice(
                "1. Исследовать стол",
                "2. Осмотреть книжную полку",
                "3. Выйти");

            switch (choice)
            {
                case 1:
                    if (_knowsSecret)
                    {
                        ShowEnding(2, "Вы находите эликсир и используете его, чтобы покинуть поместье!", true);
                    }
                    else
                    {
                        ShowEnding(3, "Вы выпиваете неизвестную жидкость и превращаетесь в статую...", false);
                    }
                    break;
                case 2:
                    _hasMap = true;
                    Console.WriteLine("Вы нашли карту поместья!");
                    Chapter2();
                    break;
            }
        }

        private void BlueDoor()
        {
            Console.WriteLine("\nВ комнате сидит старик.");
            var choice = GetChoice(
                "1. Заговорить с ним",
                "2. Атаковать его",
                "3. Уйти");

            switch (choice)
            {
                case 1:
                    _metAlly = true;
                    Console.WriteLine("Старик оказывается бывшим хозяином поместья. Он дает вам совет.");
                    _trustPoints += 2;
                    Chapter2();
                    break;
                case 2:
                    ShowEnding(4, "Старик оказывается призраком и забирает вашу душу...", false);
                    break;
                case 3:
                    Chapter2();
                    break;
            }
        }

        private void GreenDoor()
        {
            Console.WriteLine("\nВы в оранжерее с экзотическими растениями.");
            var choice = GetChoice(
                "1. Сорвать красный цветок",
                "2. Сорвать синий цветок",
                "3. Выйти");

            switch (choice)
            {
                case 1:
                    ShowEnding(5, "Цветок оживает и опутывает вас корнями...", false);
                    break;
                case 2:
                    Console.WriteLine("Цветок дает вам странное видение...");
                    _trustPoints++;
                    Chapter2();
                    break;
                case 3:
                    Chapter2();
                    break;
            }
        }

        private void Stairs()
        {
            Console.WriteLine("\nПоднявшись, вы видите:");
            var choice = GetChoice(
                "1. Дверь в чердак",
                "2. Окно с возможностью выбраться",
                "3. Вернуться");

            switch (choice)
            {
                case 1:
                    Attic();
                    break;
                case 2:
                    if (_trustPoints >= 3)
                    {
                        ShowEnding(6, "Вы выбираетесь через окно и оказываетесь в безопасности!", true);
                    }
                    else
                    {
                        ShowEnding(7, "Вы падаете и ломаете ногу... Тени приближаются...", false);
                    }
                    break;
                case 3:
                    Chapter2();
                    break;
            }
        }

        private void Attic()
        {
            Console.WriteLine("\nНа чердаке вы находите древний артефакт.");
            var choice = GetChoice(
                "1. Взять его",
                "2. Оставить");

            if (choice == 1)
            {
                if (_metAlly && _hasMap)
                {
                    ShowEnding(8, "Артефакт переносит вас домой! Вы спасены!", true);
                }
                else
                {
                    ShowEnding(9, "Артефакт поглощает ваше сознание...", false);
                }
            }
            else
            {
                Console.WriteLine("Вы чувствуете, что сделали правильный выбор.");
                _trustPoints++;
                FinalChoice();
            }
        }

        private void FinalChoice()
        {
            Console.WriteLine("\n=== ФИНАЛЬНЫЙ ВЫБОР ===");
            var choice = GetChoice(
                "1. Попытаться найти другой выход",
                "2. Вернуться к старику за советом");

            if (choice == 1)
            {
                if (_trustPoints >= 4)
                {
                    ShowEnding(10, "Используя все полученные знания, вы находите тайный выход!", true);
                }
                else
                {
                    Console.WriteLine("Вы блуждаете по коридорам...");
                    ShowEnding(11, "Поместье не отпускает вас... Вы становитесь его частью.", false);
                }
            }
            else
            {
                if (_metAlly)
                {
                    ShowEnding(12, "Старик раскрывает вам последний секрет и помогает сбежать!", true);
                }
                else
                {
                    ShowEnding(13, "Старика нигде нет... Вы остаетесь один в темноте...", false);
                }
            }
        }

        // Вспомогательные методы
        private void DisplayChapterTitle(string title)
        {
            Console.WriteLine($"\n=== {title} ===");
        }

        private void ShowEnding(int number, string message, bool isGood)
        {
            Console.WriteLine($"\n=== КОНЦОВКА #{number} ===");
            Console.WriteLine(message);
            Console.WriteLine(isGood ? "★ ХОРОШАЯ КОНЦОВКА ★" : "✖ ПЛОХАЯ КОНЦОВКА ✖");
            Console.WriteLine("\nСпасибо за игру!");
            Console.ReadKey();
            Environment.Exit(0);
        }

        // Улучшенный метод получения выбора пользователя
        private int GetChoice(params string[] options)
        {
            foreach (var option in options)
            {
                Console.WriteLine(option);
            }

            int choice;
            while (true)
            {
                Console.Write("Ваш выбор: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= options.Length)
                {
                    return choice;
                }
                Console.WriteLine($"Пожалуйста, введите число от 1 до {options.Length}.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Game().Run();
        }
    }
}