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
        /// <param name="individuoOne"></param>
        /// <param name="individuoTwo"></param>
        /// <param name="crossoverRate"></param>
        /// <param name="populationLenth"></param>
        /// <returns></returns>
        public List<Individuo> ToCross(Individuo individuoOne, Individuo individuoTwo, double crossoverRate, int populationLenth)
        {
            var random = new Random();
            var listIndividuos = new List<Individuo>();
            double crossoverRateEnable = random.NextDouble();

            if (crossoverRateEnable <= crossoverRate)
            {
                int index = random.Next(0, populationLenth);
                var aux = 0;
                for (int i = index; i < populationLenth; i++)
                {
                    aux = individuoOne.Cromossome[i];
                    individuoOne.Cromossome[i] = individuoTwo.Cromossome[i];
                    individuoTwo.Cromossome[i] = aux;
                }
            }
            listIndividuos.Add(individuoOne);
            listIndividuos.Add(individuoTwo);
            return listIndividuos;
        }
    }
}
