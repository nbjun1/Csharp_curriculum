using System;
using System.Collections.Generic;

namespace Curriculum_2_22
{
    
    // 1. 単一責任の原則 (SRP)
    public class Report
    {
        public string EmployeeName { get; set; }
        public int HoursWorked { get; set; }
    }

    public class ReportCalculator
    {
        public int CalculateWage(Report r) => r.HoursWorked * 1200;
    }

    public class ReportSaver
    {
        public void Save(Report r) => Console.WriteLine($"【SRP】{r.EmployeeName}のレポートを保存しました。");
    }

    // 2. 開放閉鎖の原則 (OCP)

    public interface IBillable
    {
        int CostForDay(int hours);
    }

    public class FullTimeEmployeeOCP : IBillable
    {
        public int CostForDay(int hours) => hours * 1250;
    }

    public class ContractEmployeeOCP : IBillable
    {
        public int CostForDay(int hours) => hours * 1000;
    }

    // 3. リスコフの置換原則 (LSP)

    public abstract class EmployeeBase
    {
        public abstract void Work(int hours);
    }

    public class RegularEmployee : EmployeeBase
    {
        public override void Work(int hours) => Console.WriteLine($"正社員が{hours}時間働きます。");
    }

    public class InternEmployee : EmployeeBase
    {
        public override void Work(int hours)
        {
            // 親の「働く」という仕様を守りつつ、内部で制約（最大4時間）を適用
            int actual = Math.Min(hours, 4);
            Console.WriteLine($"インターンが{actual}時間働きます。（制限により最大4時間）");
        }
    }

    // 4. インターフェイス分離の原則 (ISP)

    public interface IWorkable { void Work(); }
    public interface IEatable { void Eat(); }

    public class Human : IWorkable, IEatable
    {
        public void Work() => Console.WriteLine("【ISP】人間が働きます。");
        public void Eat() => Console.WriteLine("【ISP】人間が食事をします。");
    }

    public class Robot : IWorkable
    {
        public void Work() => Console.WriteLine("【ISP】ロボットが働きます。（食事は不要）");
    }

    // 5. 依存関係逆転の原則 (DIP)

    public interface IOutput { void Write(string text); }

    public class ConsoleOutput : IOutput
    {
        public void Write(string text) => Console.WriteLine($"[DIP コンソール出力]: {text}");
    }

    public class ReportPrinter
    {
        private readonly IOutput _output;
        public ReportPrinter(IOutput output) { _output = output; }
        public void Print(string text) => _output.Write(text);
    }

    // 実行用メインクラス

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- SOLID原則 実装デモ ---\n");

            // SRPのデモ
            var report = new Report { EmployeeName = "山田太郎", HoursWorked = 8 };
            var saver = new ReportSaver();
            saver.Save(report);

            // OCPのデモ
            List<IBillable> staff = new List<IBillable> { new FullTimeEmployeeOCP(), new ContractEmployeeOCP() };
            foreach (var s in staff) Console.WriteLine($"【OCP】日給: {s.CostForDay(8)}円");

            // LSPのデモ
            EmployeeBase intern = new InternEmployee();
            intern.Work(8); // 8時間を指定しても内部で適切に処理される

            // ISPのデモ
            IWorkable robot = new Robot();
            robot.Work();

            // DIPのデモ
            var printer = new ReportPrinter(new ConsoleOutput());
            printer.Print("全ての原則が適用されました。");

            Console.WriteLine("\nプログラムを終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}