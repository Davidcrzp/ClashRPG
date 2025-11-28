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

        // 🎯 MÉTODO SIMPLIFICADO CON VICTORIA/DERROTA
        public async Task<bool> CrearNotaPartidaFinalizada(
            int idPartida,
            int idPersonaje,
            int duracionSegundos,
            bool victoria,                    // true = ganó, false = perdió
            string motivoFin = "")            // razón del fin de partida
        {
            try
            {
                var collection = NotasCollection();

                string resultadoTexto = victoria ? "🏆 VICTORIA" : "💀 DERROTA";
                string emoji = victoria ? "🎉" : "😔";
                string notaCompleta = $"{emoji} {resultadoTexto} - Partida #{idPartida} - " +
                                      $"Duración: {TimeSpan.FromSeconds(duracionSegundos):mm\\:ss}";

                // Agregar motivo si existe
                if (!string.IsNullOrEmpty(motivoFin))
                {
                    notaCompleta += $" - {motivoFin}";
                }

                var nota = new BsonDocument
                {
                    { "tipo", "partida_finalizada" },
                    { "id_partida", idPartida },
                    { "id_personaje", idPersonaje },
                    { "duracion_segundos", duracionSegundos },
                    { "victoria", victoria },
                    { "resultado", resultadoTexto },
                    { "motivo_fin", motivoFin },
                    { "fecha_finalizacion", DateTime.Now },
                    { "nota", notaCompleta },
                    { "fecha_registro", DateTime.Now }
                };

                await collection.InsertOneAsync(nota);
                Console.WriteLine($"✅ Nota de partida #{idPartida} guardada - {resultadoTexto}");
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



