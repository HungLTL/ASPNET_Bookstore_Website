// See https://aka.ms/new-console-template for more information
using DataAccess;
using DataAccess.AuthorDA;
using BusinessObjects;


Console.WriteLine(ConnStr.Get());

Author author = new Author();
author.Name = "Taras Shevchenko";

var context = new ffmlwpyhContext();
context.Authors.Add(author);
context.SaveChanges();
return 1;
