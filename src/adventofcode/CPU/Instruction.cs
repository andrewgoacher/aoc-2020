namespace adventofcode.CPU
{
    public class Instruction
    {
        public Operand Operand {get; private set;}
        public int Count {get;}
        public bool Executed {get; private set;}

        public Instruction(Operand operand, int count)
        {
            Operand = operand;
            Count = count;
            Executed = false;
        }

        public void Deconstruct(out Operand operand, out int count, out bool executed)
        {
            operand = Operand;
            count = Count;
            executed = Executed;
        }

        public void ChangeOperand(Operand operand)
        {
            Operand = operand;
        }

        public void Reset()
        {
            Executed = false;
        }

        public void Execute()
        {
            Executed = true;
        }
    }
}