using static System.Console;
using HugeConsoleLibrary;
using System.Text;
using System.Drawing;
using System;


namespace MyQuickDemo
{
    internal class Program
    {
        private static void Main()
        {
            Title = "Huge Console Library";
            FrameworkDemo();
            ReadKey(true);
        }

        private static void ScrollMenuDemo()
        {
            ConsoleLibrary.WriteTextInsideLine("Huge Console Library", Justify.Center, null, null);
            var menu = new ScrollMenu("Animated Scroll Menu")
            {
                HighlightTitle = false,
                ScrollSpeed = 10,
                ShowTitle = true,
                ShowInstructions = true,
                AutoWrap = true,
                AnimateMenu = false,
            };
            menu.AddMenuItems("Play", "Settings", "About Me", "Exit");
            menu.Show();
        }

        private static void TextMenuDemo()
        {
            Clear();
            var textMenu = new TextMenu()
            {
                Title = "Animated Text Menu".CenterText().BackgroundColor(Color.White).RgbForeground(25, 25, 25),
                ShowTitle = true,
                ShowInstructions = true,
                EnableAnimations = false,
                AnimationSpeed = 8,
                SelectedItemHighlightLength = 19,
                AutoWrap = true,
                ShowLineUnderMenu = true,
            };
            textMenu.AddMenuContent("Alots Of Things To Discover", "<--[ Very Custimeziable ]-->");
            textMenu.AddMenuItems("Progress Show", "Spinner Show", "Clear Screen", "About Me", "Exit");
            switch (textMenu.Show())
            {
                case 1: ProgressDemo(); break;
                case 2: SpinnerDemo(); break;
                case 3: ClearAnimation(); break;
                case 4: TextMenuDemo(); break;
                case 5: ConfirmMenuDemo(); break;
            }
        }

        private static void ConfirmMenuDemo()
        {
            Clear();
            var confirm = new ConfirmMenu("Are you sure you want to exit the app?")
            {
                DisplayWay = EDisplayWay.Horizontal,
                UseCustomColorForSelectedItem = false,
                ShowLineUnderTitle = true,
                LineColor = Color.DimGray,
                TitleColor = Color.White
            }.Show();
            if (confirm) Environment.Exit(0);
            TextMenuDemo();
        }

        private static void ProgressDemo()
        {
            Clear();
            ConsoleLibrary.WriteTextInsideLine("Progress Show", Justify.Center, Color.FromArgb(255, 44, 38, 201), Color.DimGray);
            Write("\n");
            ConsoleAnimations.WriteAndOverride(2500, "A very custimeziable progress bar", "You are able to change progress length and speed..", "Background, Fill and completed colors..", "Percantage, Text and text color", "Totally Everything..");

            new ProgressBar()
            {
                Text = "Processing Action",
                ShowPercentage = true,
                DeleteWhenFinished = false,
                ProgressSpeed = 70,
                ProgressLength = 30,
                PercentageIndicator = "%",
            }.Activate();

            ConsoleAnimations.WriteLine("I hope you've like it..", null, 75);
            Thread.Sleep(1200);
            ConsoleAnimations.RemoveLine(CursorTop, RemoveCase.Backward, 150);
            TextMenuDemo();
        }

        private static void FrameworkDemo()
        {
            ConsoleLibrary.PressAnyKey(ConsoleKey.Enter);
            ConsoleLibrary.CountDown("Please wait for:", 10, null);
            ConsoleAnimations.LoadScreen("Preparing To Start..", 50, null);
            ConsoleLibrary.WriteTextInsideBorder("Huge Console Library", Color.Magenta); Write("\n");

            // Username Prompt
            var username = new Prompt(PromptType.String, "Enter your name: ")
            {
                AcceptSpace = true,
                RemovePromptWhenDone = false,
                MinimumChars = 1,
                MaximumChars = 100,
            }.Display();

            // Numeric Prompt
            var age = new Prompt(PromptType.Numeric, "Enter your age: ")
            {
                AcceptSpace = false,
                RemovePromptWhenDone = false,
                MinimumChars = 0,
                MaximumChars = 2,
            }.Display();

            // Password Prompt
            var pass = new Prompt(PromptType.Private, "Create password: ")
            {
                AcceptSpace = false,
                RemovePromptWhenDone = false,
                MinimumChars = 1,
                MaximumChars = 100,
            }.Display();


            // Display those prompts
            Write("\n\n");
            WriteLine($"--> Userrname: {username} | --> Password: {pass} | --> Age: {age}");
            ConsoleLibrary.CreateLine(Color.DimGray);

            // Confirm Prompt
            var succ = new Prompt(PromptType.Confirmation, "Is those information correct?").Display();

            if (succ.ToBool()) Clear(); TextMenuDemo();
        }

        private static void TextStyles()
        {
            var a = "Huge Console Library".Bold();
            var b = "Huge Console Library".Dim();
            var c = "Huge Console Library".Italic();
            var e = "Huge Console Library".Underline();
            var f = "Huge Console Library".DoubleUnderline();
            var g = "Huge Console Library".Blink();
            var h = "Huge Console Library".Inverted();
            var m = "Huge Console Library".Hide();
            var v = "Huge Console Library".Link("https://www.youtube.com/");
            var w = "Huge Console Library".Overline();
            var x = "Huge Console Library".StrikeThrough();
            var z = "Huge Console Library".CenterText();
            var d = "Huge Console Library".ForegroundColor(Color.Crimson);
            var t = "Huge Console Library".BackgroundColor(Color.Teal);
            var n = "Huge Console Library".RgbForeground(82, 111, 137);
            var k = "Huge Console Library".RgbBackground(234, 218, 125);
            var y = "Huge Console Library".Opacity(70);


            WriteLine(z); Write("\n"); WriteLine(b); Write("\n"); WriteLine(a); Write("\n");
            WriteLine(c); Write("\n"); WriteLine(d); Write("\n"); WriteLine(e); Write("\n");
            WriteLine(f); Write("\n"); WriteLine(g); Write("\n"); WriteLine(h); Write("\n");
            WriteLine(w); Write("\n"); WriteLine(v); Write("\n"); WriteLine(n); Write("\n");
            WriteLine(x); Write("\n"); WriteLine(k); Write("\n"); WriteLine(t); Write("\n"); 
            WriteLine(y); Write("\n"); WriteLine(m);

            CursorVisible = false;
        }

        private static void ClearAnimation()
        {
            ConsoleAnimations.ClearScreen(100, RemoveCase.Backward);
        }

        private static void SpinnerDemo()
        {
            Clear();
            ConsoleLibrary.WriteTextInsideLine("Spinner Show", Justify.Center, Color.FromArgb(255, 44, 38, 201), Color.DimGray);
            Write("\n");

            new Spinner(SpinnerType.UpDown)
            {
                Text = "Spinner One",
                RemoveSpinnerWhenDone = true,
                LoopCount = 4,
                LoopDelay = 80,
                SpinnerColor = Color.Fuchsia,
            }.Activate();
            new Spinner(SpinnerType.Progress)
            {
                Text = "Spinner Two",
                RemoveSpinnerWhenDone = true,
                LoopCount = 4,
                LoopDelay = 80,
                SpinnerColor = Color.Orange,
            }.Activate();
            new Spinner(SpinnerType.Dots)
            {
                Text = "Spinner Three",
                RemoveSpinnerWhenDone = true,
                LoopCount = 4,
                LoopDelay = 100,
                SpinnerColor = Color.Cyan,
            }.Activate();
            new Spinner(SpinnerType.BrailleDots)
            {
                Text = "Spinner Four",
                RemoveSpinnerWhenDone = true,
                LoopCount = 4,
                LoopDelay = 80,
                SpinnerColor = Color.Crimson,
            }.Activate();
            new Spinner(SpinnerType.Speed)
            {
                Text = "Spinner Five",
                RemoveSpinnerWhenDone = true,
                LoopCount = 4,
                LoopDelay = 80,
                SpinnerColor = Color.YellowGreen,
            }.Activate();

            ConsoleAnimations.WriteLine("And Mush More..", null, 120);
            Thread.Sleep(1500);
            ConsoleAnimations.RemoveLine(CursorTop, RemoveCase.Backward, 120);
            TextMenuDemo();
        }
    }
}
