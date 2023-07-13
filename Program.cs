using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Testes.Model;

namespace Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lista geral
            List<ProfissionalModel> listagemGeralProfissionais = GetProfissionais();

            // Por código
            ProfissionalModel profissional = GetProfissionalById(100);

            // Lista com novos profissionais
            List<ProfissionalModel> listagemProfissionais = InsertProfissional(new ProfissionalModel
            {
                CodigoProfissional = 4,
                Nome = "Karen",
                Sobrenome = "Santana Oliveira Jesus",
                DataCadastro = DateTime.Now,
                DataNascimento = DateTime.Now.AddYears(-27)
            });

            // Lista com novos profissionais
            List<ProfissionalModel> listagemProfissionaisComEdicao = UpdateProfissional(new ProfissionalModel
            {
                CodigoProfissional = 1,
                Nome = "Juliana",
                Sobrenome = "Bonde",
                DataCadastro = DateTime.Now.AddMinutes(-30),
                DataNascimento = DateTime.Now.AddYears(-22)
            });

            // Lista com profissionais com remoção
            List<ProfissionalModel> listagemProfissionaisComRemocao = DeleteProfissionais(1);

            Console.WriteLine();
        }

        private static List<ProfissionalModel> GetProfissionais()
        {
            HttpResponseMessage httpResponseMessage = ApiHelper.Get(
                new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:50097/api/profissionais")
                }).GetAwaiter().GetResult();

            if (httpResponseMessage.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<ProfissionalModel>>(httpResponseMessage.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        private static ProfissionalModel GetProfissionalById(int id)
        {
            HttpResponseMessage httpResponseMessage = ApiHelper.Get(
                new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:50097/api/profissionais/" + id)
                }).GetAwaiter().GetResult();

            if (httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<ProfissionalModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        private static List<ProfissionalModel> InsertProfissional(ProfissionalModel profissionalModel)
        {
            HttpResponseMessage httpResponseMessage = ApiHelper.Create(
                new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:50097/api/profissionais/novo")
                }, JsonConvert.SerializeObject(profissionalModel)).GetAwaiter().GetResult();

            if (httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<List<ProfissionalModel>>(httpResponseMessage.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        private static List<ProfissionalModel> UpdateProfissional(ProfissionalModel profissionalModel)
        {
            HttpResponseMessage httpResponseMessage = ApiHelper.Update(
                new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:50097/api/profissionais/atualizacao")
                }, JsonConvert.SerializeObject(profissionalModel)).GetAwaiter().GetResult();

            if (httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<List<ProfissionalModel>>(httpResponseMessage.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        private static List<ProfissionalModel> DeleteProfissionais(int id)
        {
            HttpResponseMessage httpResponseMessage = ApiHelper.Delete(
                new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:50097/api/profissionais/deletar/" + id),
                }).GetAwaiter().GetResult();

            if (httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<List<ProfissionalModel>>(httpResponseMessage.Content.ReadAsStringAsync().Result);
            else
                return null;
        }
    }
}
