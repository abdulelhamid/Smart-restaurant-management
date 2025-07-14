using Supabase;
using Supabase.Gotrue;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supabase.Postgrest;
namespace MauiApp1
{
    [Table("User")]
    public class User : BaseModel
    {
        [PrimaryKey("id", false)]
        public int? id { get; set; }

        [Column("name")]
        public string? name { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("number")]
        public int number { get; set; }
        [Column("adminsampil")]
        public bool? adminsampil { get; set; } 
        [Column("adminall")]
        public bool? adminall { get; set; } 



    }

    
    public class UserService
    {
        private Supabase.Client _client;




        public async Task InitAsync()
        {
            var url = "https://nqhlavnimufvyritqpgg.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im5xaGxhdm5pbXVmdnlyaXRxcGdnIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTE3MzM5MTUsImV4cCI6MjA2NzMwOTkxNX0.fl5EbC-hV6MbHvbUc_7Q0uB9GuLq4ruNSE0YqlfQtJk"; // 🔐 الأفضل إخفاء هذا المفتاح في ملف إعدادات

            _client = new Supabase.Client(url, key, new SupabaseOptions
            {
                AutoConnectRealtime = false
            });

            await _client.InitializeAsync();
        }



        public async Task UpdateUserAsync(User user)
        {
            if (_client == null)
                throw new InvalidOperationException("Supabase client not initialized");

            await _client.From<User>().Update(user);
        }



        public async Task<List<User>> GetUsersAsync()
        {
            var result = await _client.From<User>().Get();
            return result.Models;
        }




       

        public async Task AddUserAsync1(User newUser)
        {
            if (_client == null)
                throw new InvalidOperationException("Supabase client not initialized");
         
            await _client.From<User>().Insert(newUser);
        }

        public async Task<User?> GetUserByNumberAsync(int number)
        {
            var result = await _client.From<User>().Get();
            return result.Models.FirstOrDefault(u => u.number == number);
        }
        public async Task DeleteUserAsync(User user)
        {
            if (_client == null)
                throw new InvalidOperationException("Supabase client not initialized");

            await _client.From<User>().Delete(user);
        }



        public async Task<bool> IsPhoneNumberExistsAsync(int number,string password)
        {
            if (_client == null)
                throw new InvalidOperationException("Supabase client not initialized");

            var allUsers = await _client.From<User>().Get(); 
            bool a = allUsers.Models.Any(u => u.number == number || u.password == password);

            return a;
               
        }
     
    }
}