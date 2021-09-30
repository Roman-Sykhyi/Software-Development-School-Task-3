using System;

namespace Завдання_2
{
    public class Product
    {
        public string Name { get; }
        public float Price { get; private set; }
        public float Weight { get; }

        public Product(string name, float price, float weight)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentNullException("Назва товару не може бути пустою або null", nameof(name));

            if(price <= 0)
                throw new ArgumentOutOfRangeException("Ціна товару не можу бути меншею або рівною нулю", nameof(price));

            if(weight <= 0)
                throw new ArgumentOutOfRangeException("Вага товару не можу бути меншею або рівною нулю", nameof(price));

            Name = name;
            Price = price;
            Weight = weight;
        }

        public virtual void RaisePrice(int percent)
        {
            Price *= (1 + (percent / 100));
        }

        public override bool Equals(object obj)
        {
            Product product = obj as Product;

            if (product == null)
                return false;

            return Name.Equals(product.Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Назва: " + Name + ". Ціна: " + Price + ". Вага: " + Weight;
        }
    }
}
