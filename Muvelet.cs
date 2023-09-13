using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operatorokokokokokokkok
{
    internal class Muvelet
    {
        int operandA, operandB;
        string operat;

        public Muvelet(int operandA, int operandB, string operat)
        {
            this.operandA = operandA;
            this.operandB = operandB;
            this.operat = operat;
        }

        public int OperandA { get => operandA; set => operandA = value; }
        public int OperandB { get => operandB; set => operandB = value; }
        public string Operat { get => operat; set => operat = value; }
    }

    
}
