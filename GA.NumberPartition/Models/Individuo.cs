using System.Collections.Generic;

namespace GA.NumberPartition.Models
{
    public class Individuo
    {
        public Individuo()
        {
            Cromossome = new List<int>();
        }
        public List<int> Cromossome { get; set; }
        public int Fitness { get; set; }
    }
}
