using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp7Demo
{
    public class Spring2016TermMessaging
    {
        public (IEnumerable<string> messages, int staffCount, int) GetThankYouMessages(IEnumerable<Person> persons)
        =>
        (
            persons.Select(x => GetThankYouMessage(x)),
            persons.Where(x => x is Staff).Count(),
            42
        );

        private string GetThankYouMessage(Person person)
        => person switch
        {
            { Name: "John" } => "Where are the beers happening tonight?",
            Student student when (student.GPA > 3.2m)
            => $"Thanks {student.Name} for being  an honor student " +
               $"this term, sorry about the flood",
            Student student
            => "Thanks for being a student this term, sorry about the flood",
            Instructor instructor
            => $"Thanks for teaching {string.Join(", ", instructor.Courses)}",
            Staff staff
                => $"Thanks for being a {staff.StaffRole.ToString()}",
            _ =>
            throw new InvalidOperationException()
        };

        public (IEnumerable<string> messages, int staffCount, int) GetThankYouMessages2(IEnumerable<Person> persons)
        {
            var messages = new List<string>();
            int staffCount = 0;
            foreach (Person person in persons)
            {
                string message = GetThankYouMessage(person);

                if (person is Staff staff)
                { staffCount += 1; }

                messages.Add(message);
            }
            return (messages, staffCount, 42);
        }



        private string GetThankYouMessage2(Person person)
        {
            switch (person)
            {
                case Student student when (student.GPA > 3.2m):
                    return $"Thanks {student.Name} for being  an honor student " +
                        $"this term, sorry about the flood";
                case Student student:
                    return "Thanks for being a student this term, sorry about the flood";
                case Instructor instructor:
                    return $"Thanks for teaching {string.Join(", ", instructor.Courses)}";
                case Staff staff:
                    return $"Thanks for being a {staff.StaffRole.ToString()}";
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
