using Supabase;
using Supabase.Gotrue;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiApp1
{
    [Table("Food")]
    public class Food : BaseModel
    {
        [PrimaryKey("id", false)]
        public int id { get; set; }

        [Column("foode")]
        public string? foode { get; set; }

        [Column("pice")]
        public string pice { get; set; }
    }

    public class FoodService
    {
        private Supabase.Client _client;

        public async Task InitAsync()
        {
            var url = "https://nqhlavnimufvyritqpgg.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im5xaGxhdm5pbXVmdnlyaXRxcGdnIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTE3MzM5MTUsImV4cCI6MjA2NzMwOTkxNX0.fl5EbC-hV6MbHvbUc_7Q0uB9GuLq4ruNSE0YqlfQtJk"; // 🔐 لا تستخدم المفتاح كاملاً في الإنتاج

            _client = new Supabase.Client(url, key, new SupabaseOptions
            {
                AutoConnectRealtime = false
            });

            await _client.InitializeAsync();
        }

        public async Task<List<Food>> GetFoodsAsync()
        {
            var result = await _client.From<Food>().Get();
            return result.Models;
        }
        public async Task AddFoodAsync(Food newFood)
        {
            if (_client == null)
                throw new InvalidOperationException("Supabase client not initialized");

            var response = await _client.From<Food>().Insert(newFood);
        }
    }
}