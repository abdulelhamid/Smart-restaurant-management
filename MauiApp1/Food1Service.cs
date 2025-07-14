using Supabase;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiApp1
{
    [Table("Food1")]
    public class Food1 : BaseModel
    {
        [PrimaryKey("id", false)]
        public int id { get; set; }

        [Column("food1")]
        public string? food1 { get; set; }

        [Column("pice1")]
        public string pice1 { get; set; }
    }

    public class Food1Service
    {
        private Supabase.Client _client;

        public async Task InitAsync()
        {
            var url = "https://nqhlavnimufvyritqpgg.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im5xaGxhdm5pbXVmdnlyaXRxcGdnIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTE3MzM5MTUsImV4cCI6MjA2NzMwOTkxNX0.fl5EbC-hV6MbHvbUc_7Q0uB9GuLq4ruNSE0YqlfQtJk";

            _client = new Supabase.Client(url, key, new SupabaseOptions
            {
                AutoConnectRealtime = false
            });

            await _client.InitializeAsync();
        }

        public async Task<List<Food1>> GetFoodsAsync()
        {
            var result = await _client.From<Food1>().Get();
            return result.Models;
        }

        public async Task AddFoodAsync(Food1 newFood1)
        {
            if (_client == null)
                throw new InvalidOperationException("Supabase client not initialized");

            await _client.From<Food1>().Insert(newFood1);
        }
    }
}