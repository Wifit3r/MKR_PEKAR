using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MKR_PEKAR
{
    class Program
    {
        static void Main (string[] args)
        {

            SolutionContext.GetAthletsBySport("football");

        }
    }
}