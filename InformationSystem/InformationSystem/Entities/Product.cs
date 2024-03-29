﻿using InformationSystem.Services;

namespace InformationSystem.Entities;

internal class Product
{
    public static readonly string Path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "products.csv");
    public static List<Product> Products = new(FileWorkService.Deserialization<Product>(Path));

    public Product(int id, string name, int price, int available)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.available = available;
    }

    public int id { get; set; }
    public string name { get; set; }
    public int price { get; set; }
    public int available { get; set; }
}

internal class SelectedProduct : Product
{
    public SelectedProduct(int id, string name, int price, int available, int selected) : base(id, name, price, available)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.available = available;
        this.selected = selected;
    }

    public int selected { get; set; }
}