using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day2
{
    public class IntCodeProgram
    {
        public enum OpCodes
        {
            add = 1,
            mul = 2,
            end = 99
        }

        public int LastCode { get; private set; }

        public bool Errored { get; private set; } = false;

        public List<int> State { get; set; } = new List<int>();

        public IntCodeProgram(string filePath)
            : this(new FileInfo(filePath))
        {
        }

        public IntCodeProgram(FileInfo file)
        {
            using (var fs = file.OpenText())
            {
                State = fs.ReadToEnd().Split(',').Select(int.Parse).ToList();
            }
        }

        public int this[int i] { get => State[i]; set => State[i] = value; }

        public void Run()
        {
            bool end = false;
            for (int loc = 0; loc < State.Count && !end; loc += 4)
            {
                LastCode = State[loc];
                int loc_1, loc_2, loc_result;
                switch ((OpCodes)LastCode)
                {
                    case OpCodes.add:
                        loc_1 = State[loc + 1];
                        loc_2 = State[loc + 2];
                        loc_result = State[loc + 3];
                        State[loc_result] = State[loc_1] + State[loc_2];
                        break;
                    case OpCodes.mul:
                        loc_1 = State[loc + 1];
                        loc_2 = State[loc + 2];
                        loc_result = State[loc + 3];
                        State[loc_result] = State[loc_1] * State[loc_2];
                        break;
                    case OpCodes.end:
                        Errored = false;
                        end = true;
                        break;
                    default:
                        Errored = true;
                        end = true;
                        break;
                }
            }
        }
    }
}
