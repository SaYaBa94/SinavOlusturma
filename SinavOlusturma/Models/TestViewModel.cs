using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;

namespace SinavOlusturma.Models
{
    public class TestViewModel
    {
        public List<Test> TestList { get; set; }

        public List<Question> QuestionList { get; set; }

        public Test Test { get; set; }
    }
}
