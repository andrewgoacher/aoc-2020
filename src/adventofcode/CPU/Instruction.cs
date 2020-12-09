namespace adventofcode.CPU
{
    public class Instruction
    {
        public Operand Operand {get; private set;}
        public int Count {get;}
        public bool Executed {get; private set;}
        public int PCWhenExecuted {get; private set;} = -1;

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
            PCWhenExecuted = -1;
        }

        public void Execute(int pc)
        {
            Executed = true;
            PCWhenExecuted = pc;
        }

        public override string ToString()
        {
            return $"({PCWhenExecuted}) {Operand} ({Count})";
        }
    }
}