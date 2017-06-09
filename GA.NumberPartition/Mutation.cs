using GA.NumberPartition.Models;
using System;
using System.Collections.Generic;

namespace GA.NumberPartition
{
    public class Mutation
    {
        public List<Individuo> Mutate(List<Individuo> population, double mutationRate, int qtdConjuntos)
        {
            var listIndividuos = new List<Individuo>();
            var random = new Random();
            double rateToMutate;

            foreach (var item in population)
            {
                rateToMutate = random.NextDouble();
                if (rateToMutate <= mutationRate)
                {
                    int index = random.Next(0, item.Cromossome.Count);
                    int newValue = random.Next(0, qtdConjuntos);
                    item.Cromossome[index] = newValue;
                    listIndividuos.Add(item);
                }
                else
                {
                    listIndividuos.Add(item);
                }
            }

            return listIndividuos;
        }
    }
}
