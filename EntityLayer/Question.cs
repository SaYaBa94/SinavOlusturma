using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class Question
    {
        public int questionId { get; set; }
        public int testId { get; set; }
        public string question { get; set; }
        public string choiceOne { get; set; }
        public string choiceTwo { get; set; }
        public string choiceThree { get; set; }
        public string choiceFour { get; set; }
        public string Answer { get; set; }


    }
}
