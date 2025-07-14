using Supabase;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MauiApp1
{
    [Table("Requests")]
    public class Request : BaseModel
    {
        [PrimaryKey("id", false)]
        public int? id { get; set; }

        [Column("name")]
        public string? name { get; set; }

        [Column("number")]
        public int? number { get; set; }

        [Column("namefode")]
        public string? namefode { get; set; }

        [Column("count")]
        public int? count { get; set; }
 
    }

    public class RequestService
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

        public async Task<List<Request>> GetRequestsAsync()
        {
            if (_client == null)
                throw new InvalidOperationException("Supabase client not initialized");

            var result = await _client.From<Request>().Get();
            return result.Models;
        }

        public async Task AddRequestAsync(Request newRequest)
        {
            if (_client == null)
                throw new InvalidOperationException("Supabase client not initialized");

            await _client.From<Request>().Insert(newRequest);
        }

        public async Task UpdateRequestAsync(Request request)
        {
            if (_client == null)
                throw new InvalidOperationException("Supabase client not initialized");

            await _client.From<Request>().Update(request);
        }
        public async Task DeleteRequestByIdAsync(int id)
        {
            if (_client == null)
                throw new InvalidOperationException("Supabase client not initialized");

            var itemToDelete = new Request { id = id };
            await _client.From<Request>().Delete(itemToDelete);
        }
    }
}