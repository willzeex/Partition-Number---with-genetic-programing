using System.Collections.Generic;

namespace NumberPartition
{
    public class Individuo
    {
        public Individuo()
        {
            Gene = new List<int>();
        }
        public List<int> Gene { get; set; }
        public int Peso { get; set; }
    }
}
