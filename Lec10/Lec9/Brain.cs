using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public enum State
    {
        Zero,
        AccumulateDigits,
        Compute,
        Result
    }
    public class Brain
    {
        MyDelegate d;
        string text;
        string first;
        string second;
        string operation;

        State state = State.Zero;

        public Brain(MyDelegate d)
        {
            this.d = d;
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
                case State.Compute:
                    Compute(false, command);
                    break;
                case State.Result:
                    Result(false, command);
                    break;
                default:
                    break;
            }
            
        }

        void Zero(bool input, string command)
        {
            if (input)
            {
                //d.Invoke("0");
            }
            else
            {
                if (command.Length == 1 && command[0] <= '9' && command[0] > '0')
                {
                    AccumulateDigits(true, command);
                }
                else
                {
                    Zero(true, command);
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
                if(command.Length == 1 && command[0] == '+')
                {
                    Compute(true, command);
                }
                else if (command.Length == 1 && command[0] <= '9' && command[0] >= '0')
                {
                    AccumulateDigits(true, command);
                }
                else if (command.Length == 1 && command[0] == '=')
                {
                    Result(true, command);
                }
            }
        }

        void Compute(bool input, string command)
        {
            if (input)
            {
                state = State.Compute;
                first = text;
                text = "";
            }else
            {
                if (command.Length == 1 && command[0] <= '9' && command[0] >= '0')
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
                second = text;
                text = (int.Parse(first) + int.Parse(second)).ToString();
                d.Invoke(text);
                text = "";
            }else
            {
                if (command.Length == 1 && command[0] <= '9' && command[0] >= '0')
                {
                    AccumulateDigits(true, command);
                }
            }
        }
    }
}
