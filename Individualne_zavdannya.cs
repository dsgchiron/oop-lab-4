using System;

namespace Lab4_Task24
{
    class WorkPayment
    {
        public double hoursWorked;
        public double hourlyRate;

        public WorkPayment(double hours, double rate)
        {
            hoursWorked = hours;
            hourlyRate = rate;
        }

        public string GetInfoString()
        {
            return $"Інформація про роботу: відпрацьовано {hoursWorked} год. за тарифом {hourlyRate} грн/год.";
        }

        public double CalculateTotalCost()
        {
            return hoursWorked * hourlyRate;
        }
    }

    class TaxedWorkPayment : WorkPayment
    {
        public double incomeTaxPercent;

        public TaxedWorkPayment(double hours, double rate, double taxPercent) : base(hours, rate)
        {
            incomeTaxPercent = taxPercent;
        }

        public double CalculateNetPayment()
        {
            double grossSalary = CalculateTotalCost(); 
            double taxAmount = grossSalary * (incomeTaxPercent / 100.0);
            return grossSalary - taxAmount;
        }

        public new string GetInfoString()
        {
            return base.GetInfoString() + $" Прибутковий податок: {incomeTaxPercent}%.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Об'єкт класу-предка (WorkPayment) ---");
            Console.Write("Введіть кількість відпрацьованих годин: ");
            double hours1 = double.Parse(Console.ReadLine());
            Console.Write("Введіть тариф (грн/год): ");
            double rate1 = double.Parse(Console.ReadLine());

            WorkPayment payment = new WorkPayment(hours1, rate1);
            Console.WriteLine(payment.GetInfoString());
            Console.WriteLine($"Загальна вартість роботи: {payment.CalculateTotalCost()} грн.\n");

            Console.WriteLine("--- Об'єкт класу-нащадка (TaxedWorkPayment) ---");
            Console.Write("Введіть кількість відпрацьованих годин: ");
            double hours2 = double.Parse(Console.ReadLine());
            Console.Write("Введіть тариф (грн/год): ");
            double rate2 = double.Parse(Console.ReadLine());
            Console.Write("Введіть прибутковий податок (%): ");
            double tax = double.Parse(Console.ReadLine());

            TaxedWorkPayment taxedPayment = new TaxedWorkPayment(hours2, rate2, tax);
            Console.WriteLine(taxedPayment.GetInfoString());
            Console.WriteLine($"Загальна вартість (до податків): {taxedPayment.CalculateTotalCost()} грн.");
            Console.WriteLine($"Скільки грошей отримає працівник (після податків): {taxedPayment.CalculateNetPayment()} грн.");

            Console.ReadLine();
        }
    }
}