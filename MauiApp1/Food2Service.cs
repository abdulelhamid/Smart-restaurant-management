using Supabase;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    [Table("Food2")]
    public class Food2 : BaseModel
    {
        [PrimaryKey("id", false)]
        public int id { get; set; }

        [Column("food2")]
        public string? food2 { get; set; }

        [Column("pice2")]
        public string pice2 { get; set; }
    }
    public class Food2Service
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

        public async Task<List<Food2>> GetFoodsAsync()
        {
            var result = await _client.From<Food2>().Get();
            return result.Models;
        }

        public async Task AddFoodAsync(Food2 newFood2)
        {
            if (_client == null)
                throw new InvalidOperationException("Supabase client not initialized");

            await _client.From<Food2>().Insert(newFood2);
        }
    }
}

