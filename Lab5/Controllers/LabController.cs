﻿using Lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Lab1;
using Lab2;
using Lab3;
using System.Text;
using ClassLibraryLab3;


namespace Lab.Controllers
{
    public class LabController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public LabController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Lab_1()
        {
            var model = new LabViewModel
            {
                TaskNumber = "1",
                TaskVariant = "37",
                TaskDescription = "Петя, вивчаючи, як змінюється курс рубля стосовно долара і євро, вивів закон, яким відбуваються ці зміни (чи думає, що вивів :) ). За цим законом Петя розрахував, яким буде курс рубля по відношенню до долара та євро протягом найближчих N днів.\r\n" +
                "Петя має 100 рублів. У кожен із днів він може обмінювати валюти одна на одну за поточним курсом без обмеження кількості (при цьому курс долара по відношенню до євро відповідає величині, яку можна отримати, обмінявши долар на карбованці, а потім ці карбованці — на євро). Оскільки Петро оперуватиме не з готівковою валютою, а з рахунком у банку, то він може здійснювати операції обміну з будь-якою (у тому числі і нецілим) кількістю одиниць будь-якої валюти.\r\n" +
                "Напишіть програму, яка обчислює, яку найбільшу кількість рублів зможе отримати Петя до результату N-го дня.\r\nЗакони зміни курсів влаштовані так, що протягом зазначеного періоду карбованцевий еквівалент тієї суми, яка може виявитися у Петі, не перевищить 108 рублів.\r\n",
                InputDescription = "Перший рядок вхідного файлу INPUT.TXT містить одне число N (1 ≤ N ≤ 5000). У кожному з наступних N рядків записано по 2 числа, обчислених за Петиними законами для відповідного дня — скільки рублів коштуватиме 1 долар і скільки рублів коштуватиме 1 євро. Всі ці значення не менше 0.01 і не більше 10000. Значення задані точно і виражаються речовими числами не більше ніж з двома знаками після десяткової точки",
                OutputDescription = "У вихідний файл OUTPUT.TXT виведіть потрібну величину з двома знаками після десяткової точки.",
                TestCases = new List<TestCase>
            {
                new TestCase { Input = "4 \n1 10 \n10 5.53\n5.53 1.25\n6 5", Output = "4000" },
            }
            };
            return View(model);
        }

        public IActionResult Lab_2()
        {
            var model = new LabViewModel
            {
                TaskNumber = "2",
                TaskVariant = "37",
                TaskDescription = "Нещодавно на уроці інформатики учні одного із класів вивчили булеві функції. Нагадаємо, що булева функція f зіставляє значенням двох булевих аргументів, кожен з яких може дорівнювати 0 або 1, третє булеве значення, зване результатом. Для учнів, які виявили бажання детальніше вивчати цю тему, вчителька інформатики на додатковому уроці ввела в розгляд поняття ланцюгового обчислення булевої функції f.\r\n" +
                "Якщо задана булева функція f і набір N булевих значень a1, a2, ..., aN , то результат ланцюгового обчислення цієї булевої функції визначається наступним чином:\r\n•\tякщо N = 1, то він дорівнює a1;\r\n•\tякщо N > 1, то він дорівнює результату ланцюгового обчислення булевої функції f для набору (N–1) булевого значення f(a1,a2), a3, …, aN, який виходить шляхом заміни перших двох булевих значень у наборі з N булевих значень на єдине булеве значення – результат обчислення функції f від a1 та a2.\r\n" +
                "Наприклад, якщо спочатку задано три булеві значення: a1 = 0, a2 = 1, a3 = 0, а функція f - АБО (OR), то після першого кроку виходить два булевих значення - (0 OR 1) і 0, тобто, 1 і 0. Після другого (і останнього) кроку виходить результат ланцюгового обчислення, що дорівнює 1, оскільки 1 OR 0 = 1.\r\nНаприкінці додаткового уроку вчителька інформатики написала на дошці булеву функцію f і попросила одного з учнів вибрати такі N булевих значень ai, щоб результат ланцюгового обчислення цієї функції дорівнював одиниці. Більше того, вона попросила знайти такий набір булевих значень, у якому число одиниць було б якомога більшим.\r\n" +
                "Потрібно написати програму, яка б вирішувала поставлене вчителькою завдання.\r\n",
                InputDescription = "Перший рядок вхідного файлу INPUT.TXT містить одне натуральне число N (2 ≤ N ≤ 100 000). Другий рядок містить опис булевої функції у вигляді чотирьох чисел, кожне з яких – нуль чи одиниця.\r\n" +
                "Перше є результат обчислення функції у разі, якщо обидва аргументи – нулі, друге – результат у разі, якщо перший аргумент – нуль, другий – одиниця, третє – результат у разі, якщо перший аргумент – одиниця, другий – нуль, а четвертий – у разі, якщо обидва аргументи – одиниці.\r\n",
                OutputDescription = "У вихідний файл OUTPUT.TXT необхідно вивести рядок з N символів, що визначають набір булевих значень ai з максимально можливим числом одиниць. Якщо відповіді декілька, потрібно вивести будь-яку з них. Якщо такого набору немає, виведіть у вихідний файл фразу «No solution».",
                TestCases = new List<TestCase>
            {
                new TestCase { Input = "4\n0110", Output = "1011" },
                new TestCase { Input = "5\n0100", Output = "11111" },
                new TestCase { Input = "6\n0000", Output = "No solution" },
            }
            };
            return View(model);
        }

        public IActionResult Lab_3()
        {
            var model = new LabViewModel
            {
                TaskNumber = "3",
                TaskVariant = "37",
                TaskDescription = "Підприємство \"Авто-2010\" випускає двигуни для відомих у всьому світі автомобілів. Двигун складається з n деталей, пронумерованих від 1 до n, при цьому деталь з номером i виготовляється за pi секунд. Специфіка підприємства \"Авто-2010\" полягає в тому, що там одночасно може виготовлятися лише одна деталь двигуна. Для деяких деталей необхідно мати попередньо виготовлений набір інших деталей.\r\n" +
                "Генеральний директор «Авто-2010» поставив перед підприємством амбітне завдання – за найменший час зробити деталь з номером 1, щоб представити її на виставці.\r\nПотрібно написати програму, яка за заданими залежностями порядку виробництва між деталями знайде найменший час, протягом якого можна зробити деталь з номером 1.\r\n",
                InputDescription = "Перший рядок вхідного файлу INPUT.TXT містить число n (1 ≤ n ≤ 100000) – кількість деталей двигуна. Другий рядок містить n натуральних чисел p1, p2 … pn, що визначають час виготовлення кожної деталі за секунди. Час виготовлення кожної деталі вбирається у 109 секунд.\r\n" +
                "Кожна з наступних n рядків вхідного файлу визначає параметри виробництва деталей. Тут перший рядок містить число деталей ki, які потрібні для виробництва деталі з номером i, а також їх номери. Сума всіх чисел ki не перевищує 200 000.\r\nВідомо, що немає циклічних залежностей у виробництві деталей.\r\n",
                OutputDescription = "У першому рядку вихідного файлу OUTPUT.TXT повинні міститися два числа: мінімальний час (у секундах), необхідний для якнайшвидшого виробництва деталі з номером 1 і число k деталей, які необхідно зробити. " +
                "У другому рядку потрібно вивести через прогалину k чисел – номери деталей у тому порядку, у якому їх виконувати для якнайшвидшого виробництва деталі з номером 1.",
                TestCases = new List<TestCase>
            {
                new TestCase
                {
                    Input = "4\r\n2 3 4 5\r\n2 3 2\r\n1 3\n0\r\n2 1 3",
                    Output = "9 3\n3 2 1"
                }
            }
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessLab(int labNumber, IFormFile inputFile)
        {
            if (inputFile == null || inputFile.Length == 0)
                return BadRequest("Please upload a file");

            // Read file contents into a string array
            string[] lines;
            using (var reader = new StreamReader(inputFile.OpenReadStream()))
            {
                var fileContent = await reader.ReadToEndAsync();
                lines = fileContent.Split(Environment.NewLine); // Split into lines
            }

            string tempFilePath = Path.GetTempFileName();

            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await inputFile.CopyToAsync(stream);
            }

            // Variable to store the processed result
            string output = null;
            StringBuilder result = new StringBuilder();

            // Execute the lab processing method based on lab number
            switch (labNumber)
            {
                case 1:
                    int N;
                    decimal[] USD;
                    decimal[] EUR;

                    Lab1.Program.ReadInput(out N, out USD, out EUR, tempFilePath);

                    decimal finalRubles = Lab1.Program.ProcessLab1(N, USD, EUR);

                    string _result = finalRubles.ToString();

                    output = _result;
                    break;
                case 2:
                    foreach (var line in lines)
                    {
                        output = Lab2.Program.ProcessLab2(lines).ToString().Trim();
                    }
                    break;
                case 3:
                    output = TaskProcessor.ProcessTask(lines);
                    break;
                default:
                    return BadRequest("Invalid lab number");
            }

            // Return result as JSON
            var result_ = new { output = output };
            return Json(result_);
        }

    }
}
