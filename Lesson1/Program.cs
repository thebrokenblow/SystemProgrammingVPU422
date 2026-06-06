using System.Runtime.InteropServices;

Example1();
Example2();

static void Example1()
{
    var result = MyMessageBox(0, "Заголовок", "Заголовок", 0);
    Console.WriteLine(result);
}

static void Example2()
{
    var a = int.Parse(Console.ReadLine());
    var b = int.Parse(Console.ReadLine());
    Console.WriteLine($"{a} + {b} = {Add(a, b)}");
}

[DllImport("SimpleMath.dll", EntryPoint = "Add")]
static extern int Add(int a, int b);

[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MessageBox")] 
static extern int MyMessageBox(IntPtr hWnd, string text, string caption, uint type);