using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace ClashRPG
{
    internal class MongoDB
    {
        private readonly string _connectionString = "mongodb+srv://erick:12345@erick.xlu1pow.mongodb.net/?appName=Erick";
        private readonly string _databaseName = "Clashrpg";
        private IMongoDatabase _database;

        public MongoDB()
        {
            var client = new MongoClient(_connectionString);
            _database = client.GetDatabase(_databaseName);
        }

        // Método para obtener la colección "notas"
        public IMongoCollection<BsonDocument> NotasCollection()
        {
            return _database.GetCollection<BsonDocument>("notas");
        }

        // 🎯 MÉTODO ÚNICO QUE NECESITAS AGREGAR
        public async Task<bool> CrearNotaPartidaFinalizada(int idPartida, int idPersonaje, string nombrePersonaje, int duracionSegundos)
        {
            try
            {
                var collection = NotasCollection();

                var nota = new BsonDocument
                {
                    { "tipo", "partida_finalizada" },
                    { "id_partida", idPartida },
                    { "id_personaje", idPersonaje },
                    { "nombre_personaje", nombrePersonaje },
                    { "duracion_segundos", duracionSegundos },
                    { "fecha_finalizacion", DateTime.Now },
                    { "nota", $"🎮 Partida #{idPartida} finalizada - Personaje: {nombrePersonaje} - Duración: {TimeSpan.FromSeconds(duracionSegundos):mm\\:ss}" },
                    { "fecha_registro", DateTime.Now }
                };

                await collection.InsertOneAsync(nota);
                Console.WriteLine($"✅ Nota de partida #{idPartida} guardada en MongoDB");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al guardar nota: {ex.Message}");
                return false;
            }
        }
    }
}


