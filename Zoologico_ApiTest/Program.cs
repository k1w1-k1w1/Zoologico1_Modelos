namespace Zoologico_ApiTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            var rutaEspecies = "api/Especies";
            httpClient.BaseAddress = new Uri("https://localhost:7155/");

            //lectira de datos
            var response = httpClient.GetAsync(rutaEspecies).Result;
            var json = response.Content.ReadAsStringAsync().Result;       
            var especies = Newtonsoft.Json.JsonConvert.DeserializeObject<Zoologico1_Modelos.ApiResult<List<Zoologico1_Modelos.Especie>>>(json);

            //insercion de datos

            var nuevaEspecie = new Zoologico1_Modelos.Especie
            {
                Id = 0,
                NombreEspecie = "LXTYZ"
            };

            //invocar al servicio web para insertar la nueva especie
            var nuevaEspecieJson = Newtonsoft.Json.JsonConvert.SerializeObject(nuevaEspecie);
            var content = new StringContent(nuevaEspecieJson, System.Text.Encoding.UTF8, "application/json");
            response = httpClient.PostAsync(rutaEspecies, content).Result;
            json = response.Content.ReadAsStringAsync().Result;

            //deserializar la respuesta
            var especieCreada = Newtonsoft.Json.JsonConvert.DeserializeObject<Zoologico1_Modelos.ApiResult<Zoologico1_Modelos.Especie>>(json);

            //actualizacion de datos

            especieCreada.Data.NombreEspecie = "Lobo ártico actualizado";
            var especieActualizadaJson = Newtonsoft.Json.JsonConvert.SerializeObject(especieCreada.Data);
            content = new StringContent(especieActualizadaJson, System.Text.Encoding.UTF8, "application/json");
            response = httpClient.PutAsync($"{rutaEspecies} / {especieCreada.Data.Id}", content).Result;
            json = response.Content.ReadAsStringAsync().Result;
            var especieActualizada = Newtonsoft.Json.JsonConvert.DeserializeObject<Zoologico1_Modelos.ApiResult<Zoologico1_Modelos.Especie>>(json);

            //eliminar datos

            response = httpClient.DeleteAsync($"{rutaEspecies} / {especieCreada.Data.Id}").Result;
            json = response.Content.ReadAsStringAsync().Result;
            var especieEliminada = Newtonsoft.Json.JsonConvert.DeserializeObject<Zoologico1_Modelos.ApiResult<Zoologico1_Modelos.Especie>>(json);

            Console.WriteLine(json);
            Console.ReadLine();

        }
    }
}
