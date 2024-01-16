namespace ConsoleExample.HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = GetUserName();
            Hello(name);
        }

        static string GetUserName()
        {
            string name;
            do
            {
                Console.WriteLine("안녕, 나는 컴퓨터야. 너는 이름이 뭐니?");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("이름을 입력하세요.");
                }

            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }

        static void Hello(string name)
        {
            switch (name)
            {
                case "roslyn":
                    Console.WriteLine("안녕, 로슬린, 만나서 반가워.");
                    break;
                default:
                    Console.WriteLine("안녕, " + name + "야, 만나서 반가워.");
                    break;
            }
        }
    }
}
