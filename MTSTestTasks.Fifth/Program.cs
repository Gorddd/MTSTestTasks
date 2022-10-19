using System.Text;

class Program
{
    static void Main(string[] args)
    {
        TransformToElephant();
        Console.WriteLine("Муха");
        //... custom application code
        Console.WriteLine("Hello how low");
    }

    static void TransformToElephant()
    {
        Console.WriteLine("Слон");
        Console.SetOut(new SkipOneWriter());
    }

    class SkipOneWriter : TextWriter
    {
        private TextWriter standardOutStream;

        public override Encoding Encoding => Encoding.UTF8;

        public SkipOneWriter()
        {
            standardOutStream = Console.Out;
        }

        public override void WriteLine(string value)
        {
            Console.SetOut(standardOutStream);
        }
    }
}