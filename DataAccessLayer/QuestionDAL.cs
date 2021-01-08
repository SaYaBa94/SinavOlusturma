using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class QuestionDAL
    {
        public static void AddQuestion(Question question)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var addedEntity = context.Entry(question);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }
        public static List<Question> GetTestQuestion(int testId)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Questions.Where(q => q.testId == testId).ToList();
            }
        }
        public static List<Question> GetQuestions(int testId, int userId)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from q in context.Questions
                             join t in context.Tests on q.testId equals t.testId
                             select new Question
                             {
                                 test = t,
                                 questionId = q.questionId,
                                 choiceOne = q.choiceOne,
                                 choiceTwo = q.choiceTwo,
                                 choiceThree = q.choiceThree,
                                 choiceFour = q.choiceFour,
                                 Answer = q.Answer,
                                 testId = q.testId,
                                 question = q.question
            };

                return result.Where(q => q.testId == testId && q.test.userId == userId).ToList();

        }

    }

}
}
