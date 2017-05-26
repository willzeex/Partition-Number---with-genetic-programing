﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberPartition
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            ManageFile mf = new ManageFile();
            //mf.GerarArquivo(1, 1000, 20, 5);
            List<int> ConjuntNumeros = new List<int>();

            string[] file = mf.LerArquivo("arquivo.txt");
            string[] strNumbers = file[1].Split(';');


            int numConjuntos = Convert.ToInt32(file[0]);
            int geracoes = 200;
            double taxaCruzamento = 0.85;
            double taxaMutacao = 0.15;

            foreach (var number in strNumbers)
                ConjuntNumeros.Add(Convert.ToInt32(number));

            ConjuntNumeros.Sort((a, b) => a.CompareTo(b));

            int menorDiferenca = int.MaxValue;
            var populacaoInicial = program.GeraPopulacaoInicial(1000, ConjuntNumeros.Count, numConjuntos);

            for (int i = 0; i < geracoes; i++)
            {
                var populacaoMelhores = new List<Individuo>();

                while (populacaoMelhores.Count < populacaoInicial.Count)
                {
                    
                    program.Fitness(populacaoInicial, ConjuntNumeros);

                    var selecionados = program.Seleciona(populacaoInicial, 10);

                    var sorteados = program.SorteioBinario(selecionados, 10);

                    program.Cruzar(sorteados, taxaCruzamento, ConjuntNumeros.Count);

                    program.Mutar(sorteados, taxaMutacao, numConjuntos);

                    populacaoMelhores.AddRange(sorteados);
                }

                populacaoInicial = populacaoMelhores;

                //teste
                var teste = program.MenorFitness(populacaoInicial);
                if (teste < menorDiferenca)
                {
                    menorDiferenca = teste;
                    Console.WriteLine(menorDiferenca);
                }
            }

            Console.WriteLine("================FIM=============");

            Console.ReadKey();
        }

        public List<Individuo> GeraPopulacaoInicial(int qtdIndividuos, int qtdNumeros, int qtdConjuntos)
        {
            var individuos = new List<Individuo>();
            var random = new Random();
            for (int i = 0; i < qtdIndividuos; i++)
            {
                var individuo = new Individuo();
                for (int j = 0; j < qtdNumeros; j++)
                {
                    individuo.Gene.Add(random.Next(0, qtdConjuntos));
                }
                individuos.Add(individuo);
            }

            return individuos;
        }

        public void Fitness(List<Individuo> populacao, List<int> lsNumeros)
        {
            for (int i = 0; i < populacao.Count; i++)
            {
                var somaConjutos = new Dictionary<int, int>();
                for (int j = 0; j < populacao[i].Gene.Count; j++)
                {
                    var conjunto = populacao[i].Gene[j];
                    if (somaConjutos.ContainsKey(conjunto))
                    {
                        somaConjutos[conjunto] += lsNumeros[j];
                    }
                    else
                    {
                        somaConjutos.Add(conjunto, lsNumeros[j]);
                    }
                }
                populacao[i].Peso = CalculaFitness(somaConjutos);
            }
        }

        public int CalculaFitness(Dictionary<int, int> somaConjuntos)
        {
            var min = int.MaxValue;
            var max = 0;
            int total = 0;
            foreach (var item in somaConjuntos.Values)
            {
                if (item < min)
                    min = item;

                if (item > max)
                    max = item;

                total += item;
            }

            return max - min;
        }

        public List<Individuo> Seleciona(List<Individuo> populacao, int qtd)
        {
            populacao.Sort((a, b) => a.Peso.CompareTo(b.Peso));
            return populacao.GetRange(0, qtd);
        }

        public List<Individuo> SorteioBinario(List<Individuo> populacao, int intervalo)
        {
            var random = new Random();
            int a = random.Next(0, intervalo);
            int b = random.Next(0, intervalo);

            var listaSorteados = new List<Individuo>();
            listaSorteados.Add(populacao[a]);
            listaSorteados.Add(populacao[b]);

            return listaSorteados;
        }

        public void Cruzar(List<Individuo> populacao, double taxaCruzamento, int qtdGenes)
        {
            var random = new Random();
            double taxaParaCruzar = random.NextDouble();

            if (taxaParaCruzar <= taxaCruzamento)
            {
                int index = random.Next(0, qtdGenes);
                var aux = 0;
                for (int i = 0; i < index; i++)
                {
                    aux = populacao[0].Gene[i];
                    populacao[0].Gene[i] = populacao[1].Gene[i];
                    populacao[1].Gene[i] = aux;
                }
            }
        }

        public void Mutar(List<Individuo> populacao, double taxaMutacao, int qtdConjuntos)
        {
            var random = new Random();
            double taxaParaMutar = random.NextDouble();

            if (taxaParaMutar <= taxaMutacao)
            {
                int index = random.Next(0, populacao[0].Gene.Count);
                int NovoValor = random.Next(0, qtdConjuntos);
                populacao[0].Gene[index] = NovoValor;

                index = random.Next(0, populacao[0].Gene.Count);
                NovoValor = random.Next(0, qtdConjuntos);
                populacao[1].Gene[index] = NovoValor;
            }
        }

        #region Teste

        private void ImprimeResultado(List<Individuo> populacaoMelhores)
        {
            foreach (var item in populacaoMelhores)
            {
                Console.WriteLine(item.Peso);
            }
        }

        private int MenorFitness(List<Individuo> populacao)
        {
            var min = int.MaxValue;
            foreach (var item in populacao)
            {
                if (item.Peso < min)
                    min = item.Peso;
            }

            return min;
        }

        private int GetMin(List<int> list)
        {
            return list.IndexOf(list.Min());
        }
        #endregion
    }
}