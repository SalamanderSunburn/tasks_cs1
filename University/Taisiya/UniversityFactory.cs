using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Taisiya
{
    class UniversityFactory : IUniversityFactory
    {
        const string Programmer = "Taisiya Loza";

        public IUniversity CreateUniversity(string title)
        {
            return new University(title);
        }

        public string ProgrammerName
        {
            get { return Programmer; }
        }
    }
}
