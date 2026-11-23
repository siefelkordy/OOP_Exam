using System.Text;

namespace ConsoleApp1
{
    //Revising All Syllabus
    internal class Program
    {
       
        static void Main(string[] args)
        {

            #region csharp02
            //     class Book
            //{
            //    public string title;
            //    public int pages;
            //}
            //int x = 10;
            //Book objectBook = new Book();
            //object book = objectBook;
            //Console.WriteLine(book.GetType());
            //Console.WriteLine(book.ToString());
            //Console.WriteLine(book.Equals(objectBook));
            //Console.WriteLine(book.GetHashCode());
            //try
            //{
            //    x = x / 0;
            //}
            //catch
            //{
            //    Console.WriteLine("Cannot divide by zero");
            //}
            //finally
            //{
            //    Console.WriteLine("done");
            //}
            //int pages = 300;
            //double pagesInDouble = pages;
            //double price = 49.99;
            //int priceinInt = (int)price;
            //string pagesText = "464";
            //int pagesInInt = Convert.ToInt32(pagesText);
            //Console.WriteLine("Pages in integer: " + pagesInInt);
            //Console.WriteLine("Pages in double: " + pagesInDouble);
            //string yearText = "2023";
            //int yearInInt = int.Parse(yearText);
            //string badText = "abc";
            //int badInInt = int.TryParse(badText, out int result) ? result : 0;
            //if(result == 0)
            //{
            //    Console.WriteLine("Invalid Number");
            //}
            //pages = 464;
            //string pagesInString = pages.ToString();
            //Console.WriteLine("Pages in string: " + pagesInString);
            //Console.WriteLine(pages.ToString().GetType());
            //int copies = 100;
            //object copiesInObject = copies;//boxing
            //Console.WriteLine("Copies in object: " + copiesInObject);
            //int copiesInInt = (int)copiesInObject;//unboxing
            //Console.WriteLine("Copies in integer: " + copiesInInt);
            //int? year = null;//nullable type...can be assigned null value
            //year = 2023;
            //Console.WriteLine("Year: " + year);
            //string reviewer = null;
            //if(reviewer == null)
            //{
            //    Console.WriteLine("Reviewer is null");
            //}
            //else
            //{
            //    Console.WriteLine("Reviewer: " + reviewer);
            //}
            //Book? bookcopy = null;
            //Console.WriteLine(bookcopy?.title?? "Book title is null");
            //bookcopy?.title ??= "untitled";
            //Console.WriteLine(bookcopy?.title);
            //string? name = null;
            //string confirmedName= name!;
            #endregion

            #region session3task
            //     class Student
            //{
            //    public string studentName;
            //    public int studentAge;
            //    public float grade1;
            //    public float grade2;
            //    public float grade3;


            //}
            //Student student = new Student();
            //Console.WriteLine("Enter Student Name: ");
            //student.studentName = Console.ReadLine()!;
            //Console.WriteLine("Enter Student Age: ");
            //student.studentAge = int.TryParse(Console.ReadLine(), out int resultAge) ? resultAge : 0;
            //Console.WriteLine("Enter Grade 1: ");
            //student.grade1 = float.TryParse(Console.ReadLine(), out float result1) ? result1 : 0;
            //Console.WriteLine("Enter Grade 2: ");
            //student.grade2 = float.TryParse(Console.ReadLine(), out float result2) ? result2 : 0;
            //Console.WriteLine("Enter Grade 3: ");
            //student.grade3 = float.TryParse(Console.ReadLine(), out float result3) ? result3 : 0;
            //float sum = student.grade1 + student.grade2 + student.grade3;
            //float average = sum / 3;
            //bool isPassed = average >= 50;
            //bool isAdult = student.studentAge >= 18;
            //Console.WriteLine("Student Name : " + student.studentName);
            //Console.WriteLine("Age          : " + student.studentAge);
            //Console.WriteLine("Total Grades : " + sum);
            //Console.WriteLine("Average      : " + average);
            //Console.WriteLine("Status       : " + (isPassed ? "Passed" : "Failed"));
            //Console.WriteLine("Age Status   : " + (isAdult ? "Adult" : "Minor"));
            #endregion

            #region csharp03
            ////string title = "Refactoring";
            ////switch (title)
            ////{
            ////    case ("Clean Code"):
            ////        Console.WriteLine("Great choice!");
            ////        break;
            ////    case ("Refactoring"):
            ////        Console.WriteLine("Nice pick");
            ////        break;
            ////    default:
            ////        Console.WriteLine("Never heard of it.");
            ////        break;
            ////}
            ////int pages = 300;
            ////var sizelabel = (pages>300) ? "Long Book" : "Short Book";

            //string[] books = { "Clean Code", "Refactoring", "The Pragmatic Programmer" };
            ////for(int i = 0; i < books.Length; i++)
            ////{
            ////    Console.WriteLine(books[i]);
            ////}
            //int i = 0;

            //while (i < books.Length)
            //{
            //    if (books[i] == "Refactoring")
            //        break;

            //    Console.WriteLine(books[i]);

            //    i++;
            //}
            //i = 0;

            //while (i < books.Length)
            //{
            //    if (books[i] == "The Pragmatic Programmer")
            //        continue;

            //    Console.WriteLine(books[i]);

            //    i++;
            //}
            //void PrintFirstBook(string[] bookList)
            //{
            //    if (bookList.Length == 0)
            //    {
            //        return;
            //    }
            //    Console.WriteLine(bookList[0]);
            //}

            ////do
            ////{
            ////    Console.WriteLine("Checking Book...");
            ////    i++;
            ////} while (i < books.Length);
            ////foreach (string book in books)
            ////{
            ////    Console.WriteLine(book);


            #endregion

            #region csharp04
            //static void PrintWelcomeMessage()
            //{
            //    Console.WriteLine("Welcome to the Library!");
            //}
            //static void PrintBookTitle(string title)
            //{
            //    Console.WriteLine("Book Title: " + title);
            //}
            //static void AddBonusPages(int pages)
            //{
            //    pages += 50;
            //}
            //static void ApplyDiscount(double[] prices)
            //{
            //    prices[0] -= 5;
            //}
            //static void AddBonusPagesByRef(ref int pages)
            //{
            //    pages += 50;
            //}
            //static void ReplaceArray(ref double[] prices)
            //{
            //    prices = new double[] { 10.0, 12.5, 15.0 };
            //}
            //double[] prices = { 25.5, 40.0};
            //int pages = 400;
            //AddBonusPages(pages);
            //Console.WriteLine("Pages after bonus passing by value: " + pages);
            //AddBonusPagesByRef(ref pages);
            //Console.WriteLine("Pages after bonus passing by reference: " + pages);
            //ApplyDiscount(prices);
            //Console.WriteLine("Price after discount: " + prices[0]);
            //int[,] shelfCopies = { { 3, 5 }, { 1, 4 } };
            //Console.WriteLine(shelfCopies[1, 0]);
            //PrintWelcomeMessage();
            //PrintBookTitle("Clean Code");
            //ReplaceArray(ref prices);
            //Console.WriteLine("Price after array replacement: " + prices[0]);
            //Console.WriteLine(prices.Length);
            //string title = "clean code";
            //int pages = 464;
            //string upperTitle = title.ToUpper();
            //Console.WriteLine("Uppercase Title: " + upperTitle);
            //Console.WriteLine("Original Title: " + title);
            //string name = "clean code";
            //Console.WriteLine(ReferenceEquals(title, name));
            //StringBuilder stringBuilder1 = new StringBuilder();
            //stringBuilder1.Append("Book List");
            //stringBuilder1.Append("Updated");
            //Console.WriteLine(stringBuilder1);
            //stringBuilder1.Replace("Book List", "Library");
            //Console.WriteLine(stringBuilder1);
            //Console.WriteLine("Book: " + title + ", Pages: " + pages);
            //Console.WriteLine($"Book: {title}, Pages: {pages}");
            //Console.WriteLine(string.Format("Book: {0}, Pages: {1}", title, pages));



            #endregion

            #region session5task
            //    class GymMember
            //{
            //    public int id;
            //    public string name;
            //    public int age;
            //    public enum Gender
            //    {
            //        Male = 1,
            //        Female
            //    }
            //    public Gender gender;
            //    public enum MembershipType
            //    {
            //        Standard,
            //        Premium
            //    }
            //    public MembershipType membershipType;
            //    public float price;

            //};
            //GymMember member = new GymMember();
            //Console.WriteLine("Enter ID: ");
            //member.id = int.TryParse(Console.ReadLine(), out int resultId) ? resultId : 0;
            //Console.WriteLine("------------------------------");
            //Console.WriteLine("Enter Name: ");
            //member.name = Console.ReadLine()!;
            //Console.WriteLine("------------------------------");
            //Console.WriteLine("Enter Age: ");
            //member.age = int.TryParse(Console.ReadLine(), out int resultAge) ? resultAge : 0;
            //Console.WriteLine("------------------------------");
            //Console.WriteLine("Choose Gender:\n1.Male\n2.Female");
            //int genderChoice = int.TryParse(Console.ReadLine(), out int resultGender) ? resultGender : 0;
            //member.gender = genderChoice == 1 ? GymMember.Gender.Male : GymMember.Gender.Female;
            //Console.WriteLine("------------------------------");
            //Console.WriteLine("Choose Membership Type:\n1.Standard\n2.Premium");
            //int membershipChoice = int.TryParse(Console.ReadLine(), out int resultMembership) ? resultMembership : 0;
            //member.membershipType = membershipChoice == 1 ? GymMember.MembershipType.Standard : GymMember.MembershipType.Premium;
            //member.price = member.membershipType == GymMember.MembershipType.Standard ? 500f : 800f;
            //Console.WriteLine("------------------------------");
            //Console.WriteLine("Member Details:");
            //Console.WriteLine("ID: " + member.id);
            //Console.WriteLine("Name: " + member.name);
            //Console.WriteLine("Age: " + member.age);
            //Console.WriteLine("Gender: " + member.gender);
            //Console.WriteLine("Membership Type: " + member.membershipType);
            //Console.WriteLine("Membership Price: " + member.price);
            #endregion

            #region csharp05
        //    class Book
        //{
        //    private string password = "secret";
        //    internal int copiesInStock = 5;
        //    public string title;
        //    public enum Genre
        //    {
        //        Fiction, NonFiction, Science
        //    }
        //    public Genre genre = Genre.Science;
        //}
        //static bool TryGetPrice(string title, out double price)
        //{
        //    if (title == "Clean Code")
        //    {
        //        price = 25.5;
        //        return true;
        //    }
        //    else
        //    {
        //        price = 0;
        //        return false;
        //    }
        //}
        //static void PrintBookInfo(string title, int pages = 300)
        //{
        //    Console.WriteLine($"Book Title: {title},Pages = {pages}");
        //}
        //static void PrintAllTitles(params string[] titles)
        //{
        //    foreach (string title in titles)
        //    {
        //        Console.WriteLine(title);
        //    }
        //}
        //TryGetPrice("Clean Code",out double price);
        //if(price!=0) 
        //    Console.WriteLine(price);
        //PrintBookInfo("Calculus",200);
        //PrintBookInfo(pages:200,title:"Calculus");
        //PrintAllTitles("Clean Code", "Refactoring", "The Pragmatic Programmer");
        //Book book = new Book();
        //Console.WriteLine(book.copiesInStock); 
        //book.title = "Clean Code";
        //Console.WriteLine(book.title);
        //Console.WriteLine(book.genre);
        //Console.WriteLine((int)(book.genre));
        //Console.WriteLine((int)Book.Genre.Fiction);
        //Console.WriteLine((int)Book.Genre.NonFiction);
        //int genreValue = 1;
        //Book.Genre genre = (Book.Genre)genreValue;
        //Console.WriteLine(genre);
        //string genreText = "Mystery"; 
        //Console.WriteLine(Enum.TryParse(genreText,out Book.Genre parsedGenre)? parsedGenre : "Invalid genre");
        //Console.WriteLine(parsedGenre);
            #endregion

    }
    }

}