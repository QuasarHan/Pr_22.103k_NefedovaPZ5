using Pr_22._103k_NefedovaPZ5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashPasswords;

namespace Pr_22._103k_NefedovaPZ5

{
    internal class Helper
{
    private static PhotocentreEntities1 _context;

    public static PhotocentreEntities1 GetContext()

    {
        if (_context == null)
        {
            _context = new PhotocentreEntities1();
        }
        return _context;
    }


    public void CreateUser(Vhod user)
    {
        var context = GetContext();
        context.Vhod.Add(user);
        context.SaveChanges();
    }

    public void UpdateUser(Vhod user)
    {
        _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
        _context.SaveChanges();
    }

    public void RemoveUser(int ID_user)
    {
        var user = _context.Vhod.Find(ID_user);
        if (user != null) // Проверяем, найден ли пользователь
        {
            _context.Vhod.Remove(user);
            _context.SaveChanges();
        }
    }

    public List<Vhod> FiltrUsers()
    {
        return _context.Vhod
            .Where(x => x.login.StartsWith("М")).ToList(); // Логика фильтрации
    }

    public List<Vhod> SortUsers()
    {
        return _context.Vhod.OrderBy(x => x.login).ToList();
    }



    private string HashPassword(string password)
    {
        return Hash.HashPassword(password);
    }

    public void Users(string login, string password)
    {
        using (var context = GetContext())
        {
            var hashedPassword = HashPassword(password);

            int maxID = context.Vhod.Any() ? context.Vhod.Max(a => a.ID_vhod) : 0;

            var account = new Vhod
                {
                    ID_vhod = maxID + 1,
                    login = login,
                    parol = hashedPassword
                };

            context.Vhod.Add(account);
            context.SaveChanges();
        }
    }






    //public string GetUserTypes(Vhod user)
    //{

    //    return user.Types..ToString();
    //}
}
}


    

