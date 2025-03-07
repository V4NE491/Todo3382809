﻿using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Todo3382809.Models;

namespace Todo3382809.Data
{
    public class TodoItemDatabase
    {
        SQLiteAsyncConnection Database;
        public TodoItemDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<TodoItem>();
        }

        public async Task<List<TodoItem>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<TodoItem>().ToListAsync();
        }

        public async Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            await Init();
            return await Database.Table<TodoItem>().Where(t => t.Done).ToListAsync();
        }

        public async Task<TodoItem> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table <TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemsAsync(TodoItem item)
        {
            await Init();
            if (item.ID != 0)
            {
                return await Database.UpdateAsync(item);
            }
            else
            {
                return await Database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(TodoItem item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
