using GA.NumberPartition.Models;
using System;
using System.Collections.Generic;

namespace GA.NumberPartition
{
    public class Crossover
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="population"></param>
        /// <param name="crossoverRate"></param>
        /// <param name="qtdCromossomes"></param>
        public void ToCross(List<Individuo> population, double crossoverRate)
        {
            var random = new Random();
            double crossoverRateEnable = random.NextDouble();

            if (crossoverRateEnable <= crossoverRate)
            {
                int index = random.Next(0, population.Count);
                var aux = 0;
                for (int i = 0; i < index; i++)
                {
                    aux = population[0].Cromossome[i];
                    population[0].Cromossome[i] = population[1].Cromossome[i];
                    population[1].Cromossome[i] = aux;
                }
            }
        }
    }
}
