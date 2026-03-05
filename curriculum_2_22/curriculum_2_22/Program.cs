using System;
using System.Collections.Generic;

namespace curriculum_2_22
{
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
}


// ② 開放閉鎖の原則 (OCP)

namespace Solid.Ocp
{
    public interface IBillable
    {
        int CostForDay(int hours);
    }

    public class FullTimeEmployee : IBillable
    {
        public int CostForDay(int hours) => hours * 1250;
    }

    public class ContractEmployee : IBillable
    {
        public int CostForDay(int hours) => hours * 1000;
    }
}
// ③ リスコフの置換原則 (LSP)

namespace Solid.Lsp
{
    public abstract class Employee
    {
        public abstract void Work(int hours);
    }

    public class FullTimeEmployee : Employee
    {
        public override void Work(int hours) => Console.WriteLine($"正社員が{hours}時間働きます。");
    }

    public class InternEmployee : Employee
    {
        public override void Work(int hours)
        {
            // 親クラスの「働く」という仕様を守りつつ、内部で制約を適用
            int actual = Math.Min(hours, 4);
            Console.WriteLine($"インターンが{actual}時間働きます。（制限により最大4時間）");
        }
    }
}


// ④ インターフェイス分離の原則 (ISP)

namespace Solid.Isp
{
    public interface IWorkable { void Work(); }
    public interface IEatable { void Eat(); }

    public class Robot : IWorkable
    {
        public void Work() => Console.WriteLine("ロボットが稼働します。");
        
    }

    public class Human : IWorkable, IEatable
    {
        public void Work() => Console.WriteLine("人間が働きます。");
        public void Eat() => Console.WriteLine("人間が食事をします。");
    }
}


// ⑤ 依存関係逆転の原則 (DIP)

namespace Solid.Dip
{
    public interface IOutput
    {
        void Write(string text);
    }

    public class ConsoleOutput : IOutput
    {
        public void Write(string text) => Console.WriteLine($"[Console]: {text}");
    }

    public class FileOutput : IOutput
    {
        public void Write(string text) => Console.WriteLine($"[File]: {text}");
    }

    public class ReportPrinter
    {
        private readonly IOutput _output;
        public ReportPrinter(IOutput output) => _output = output;

        public void Print(string text) => _output.Write(text);
    }
}

class Program
{
    static void Main()
    {
        // ② OCPの確認
        Solid.Ocp.IBillable emp = new Solid.Ocp.FullTimeEmployee();
        Console.WriteLine($"給与: {emp.CostForDay(8)}");

        // ③ LSPの確認
        Solid.Lsp.Employee intern = new Solid.Lsp.InternEmployee();
        intern.Work(8); // 8時間を渡しても4時間として処理される

        // ⑤ DIPの確認
        var printer = new Solid.Dip.ReportPrinter(new Solid.Dip.ConsoleOutput());
        printer.Print("レポート内容");
    }
}