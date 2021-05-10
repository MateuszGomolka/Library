using System;

namespace Library
{
    public class OperationMenu
    {
        private readonly string operationHeader;
        private readonly string operationFooter;
        private readonly Action operation;

        public OperationMenu(string operationHeader, string operationFooter, Action operation)
        {
            this.operationHeader = operationHeader;
            this.operationFooter = operationFooter;
            this.operation = operation;
        }

        public void Run()
        {
            Console.Clear();

            if (operationHeader != null)
            {
                Console.WriteLine(operationHeader);
            }
            operation();
            
            if (operationFooter != null)
            {
                Console.WriteLine(operationFooter);
            }
            Console.ReadKey(true);
        }
    }
}