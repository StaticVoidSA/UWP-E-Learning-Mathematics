using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP_Maths_Quiz_New.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_MyCTU_Maths_Quiz
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Grade2Page : Page
    {
        Random rnd;
        Calculations calc;

        // Addition
        int add1, add2, add3, add4,
        // Subtraction 
            sub1, sub2,
        // Division
            div1, div2;

        int answer1, answer2, answer3, answer4, score;
        
        public Grade2Page()
        {
            this.InitializeComponent();
            rnd = new Random();
            calc = new Calculations();
            score = 0;
            DoneButton.IsEnabled = false;
        }
        
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartQuiz();
            DoneButton.IsEnabled = true;
        }

        private void StartQuiz()
        {
            StartButton.IsEnabled = false;

            try
            {
                GenerateRandomNumbers();
                ConvertGeneratedNumbers();
                ClearEntries();
            }
            catch (InvalidOperationException ex)
            {
                ScoreTextBox.Text = "There was an error...\n" + ex.Message.ToString();
            }
        }

        private void GenerateRandomNumbers()
        {
            // Addition Random numbers
            add1 = rnd.Next(10, 10);
            add2 = rnd.Next(1, 15);
            add3 = rnd.Next(10, 30);
            add4 = rnd.Next(1, 15);
            // Division random numbers - Only even numbers
            div1 = rnd.Next(4 / 2, 10 / 2) * 2;
            div2 = rnd.Next(2 / 2, 4 / 2) * 2;
            // Fill the subtraction problem
            sub1 = rnd.Next(20, 30);
            sub2 = rnd.Next(1, 20);
        }

        private void ConvertGeneratedNumbers()
        {
            plusLeftText.Text = add1.ToString();
            plusRightText.Text = add2.ToString();
            plus1LeftText.Text = add3.ToString();
            plus1RightText.Text = add4.ToString();
            minusLeftText.Text = sub1.ToString();
            minusRightText.Text = sub2.ToString();
            divLeftText.Text = div1.ToString();
            divRightText.Text = div2.ToString();
        }
        
        private void ClearEntries()
        {
            plusAnswerTextBox.Text = "";
            plus1AnswerTextBox.Text = "";
            minusAnswerTextBox.Text = "";
            divAnswerTextBox.Text = "";
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            Done();
        }

        private void Done()
        {
            try
            {
                if (VerifyInput())
                {
                    // Do nothing until all fields are entered
                    ScoreTextBox.Text = "Please enter all fields...";
                }
                else
                {
                    CheckAnswer();
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
        }

        private bool VerifyInput()
        {
            bool isPempty = String.IsNullOrEmpty(plusAnswerTextBox.Text);
            bool isP1empty = String.IsNullOrEmpty(plus1AnswerTextBox.Text);
            bool isMempty = String.IsNullOrEmpty(minusAnswerTextBox.Text);
            bool isDempty = String.IsNullOrEmpty(divAnswerTextBox.Text);

            if (isPempty || isP1empty || isMempty || isDempty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CheckAnswer()
        {
            try
            {
                ConvertAnswers();
                PerformCalculations();
                DisplayScore();
            }
            catch (Exception)
            {
                ScoreTextBox.Text = "There was an error...\nPlease try again..";
            }

            StartQuiz();
        }

        private void ConvertAnswers()
        {
            answer1 = int.Parse(plusAnswerTextBox.Text);
            answer2 = int.Parse(plus1AnswerTextBox.Text);
            answer3 = int.Parse(minusAnswerTextBox.Text);
            answer4 = int.Parse(divAnswerTextBox.Text);
        }

        private void PerformCalculations()
        {
            // Addition
            if (answer1 == calc.Add(add1, add2))
            {
                score = score + 1;
            }
            // Addition
            if (answer2 == calc.Add(add3, add4))
            {
                score = score + 1;
            }
            // Subtraction
            if (answer3 == calc.Sub(sub1, sub2))
            {
                score = score + 1;
            }
            // Division
            if (answer4 == calc.Div(div1, div2))
            {
                score = score + 1;
            }
        }

        private void DisplayScore()
        {
            ScoreTextBox.Text = "Score: " + score.ToString();
        }

        private void DifficultyButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OptionsPage));
        }
    }
}
