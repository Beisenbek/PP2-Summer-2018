namespace Calc
{

    enum State
    {
        Zero,
        AccumulateDigits,
        Operation,
        Result
    }

    public class Brain
    {
        DisplayInfoDelegate d;
        State state;
        string text = "";
        int first = 0;
        int second = 0;

        public Brain(DisplayInfoDelegate d)
        {
            this.d = d;
            state = State.Zero;
        }

        public void Process(string command)
        {
            switch (state)
            {
                case State.Zero:
                    Zero(false, command);
                    break;
                case State.AccumulateDigits:
                    AccumulateDigits(false, command);
                    break;
                case State.Operation:
                    Operation(false, command);
                    break;
                default:
                    break;
            }
        }

        void Zero(bool input, string command)
        {
            if (input)
            {
                state = State.Zero;
                d.Invoke("0");
            }
            else{
                if (Utils.IsNonZeroDigit(command))
                {
                    AccumulateDigits(true, command);
                }else
                {
                            (true, command);
                }
            }
        }

        void AccumulateDigits(bool input, string command)
        {
            if (input)
            {
                state = State.AccumulateDigits;
                text = text + command;
                d.Invoke(text);
            }else
            {
                if (Utils.IsDigit(command))
                {
                    AccumulateDigits(true, command);
                }else if (Utils.IsOperation(command))
                {
                    Operation(true, command);
                }
                else if (Utils.IsResult(command))
                {
                    Result(true, command);
                }
            }
        }

        void Operation(bool input, string command)
        {
            if (input)
            {
                first = int.Parse(text);
                text = "";
                state = State.Operation;
            }else
            {
                if (Utils.IsDigit(command))
                {
                    AccumulateDigits(true, command);
                }
            }
        }

        void Result(bool input, string command)
        {
            if (input)
            {
                state = State.Result;
                second = int.Parse(text);
                text = (first + second).ToString();
                d.Invoke(text);
                text = "";
            }else
            {
                if (Utils.IsNonZeroDigit(command))
                {
                    AccumulateDigits(true, command);
                }else if (Utils.IsZero(command))
                {
                    Zero(true, command);
                }

            }
        }

    }
}
