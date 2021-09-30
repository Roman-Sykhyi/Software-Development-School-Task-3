using System;

namespace Завдання_2
{
    public class DairyProduct : Product
    {
        private int expirationDate; // in days

        public DairyProduct(string name, float price, float weight, int expirationDate) : base(name, price, weight)
        {
            if (expirationDate <= 0)
                throw new ArgumentOutOfRangeException("Термін придатності не може бути меншим або рівним нулю", nameof(expirationDate));

            this.expirationDate = expirationDate;
        }

        public override void RaisePrice(int percent)
        {
            percent += expirationDate / 10;
            base.RaisePrice(percent);
        }

        public override bool Equals(object obj)
        {
            DairyProduct product = obj as DairyProduct;
            return product == null ? false : Name.Equals(product.Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Назва: " + Name + ". Ціна: " + Price + ". Вага: " + Weight + ". Термін придатності: " + expirationDate + " днів.";
        }
    }
}
