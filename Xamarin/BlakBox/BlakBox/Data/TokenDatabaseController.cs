using System;
using System.Collections.Generic;
using System.Text;
using BlakBox.Models;
using SQLite;
using Xamarin.Forms;

namespace BlakBox.Data {
    public class TokenDatabaseController {
        static object locker = new Object();
        SQLiteConnection database;

        public TokenDatabaseController() {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Token>();
        }

        public Token GetToken() {
            lock (locker) {

                if (database.Table<Token>().Count() == 0) {
                    return null;
                } else {
                    return database.Table<Token>().First();
                }
            }
        }

        public int SaveToken(Token token) {
            lock (locker) {
                if (token.ID != 0) {
                    database.Update(token);
                    return token.ID;
                } else {
                    return database.Insert(token);
                }
            }
        }

        public int DeleteUser(int id) {
            lock (locker) {
                return database.Delete<Token>(id);
            }
        }
    }
}
