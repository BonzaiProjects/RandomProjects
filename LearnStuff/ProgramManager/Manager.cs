using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramManager
{
    public class Manager
    {
        public Dictionary<IProgram, bool> Programs { get; private set; }

        private Manager()
        {
            Programs = new Dictionary<IProgram, bool>();
        }

        private void FillProgramsList()
        {
            // look through directory for programs
            // for each found add to list
        }

        private void AddProgram(IProgram program)
        {
            Programs.Add(program, false);
        }

        public void StartProgram(IProgram tostart)
        {

        }
    }
}
