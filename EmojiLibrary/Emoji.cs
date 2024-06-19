
using System.Diagnostics.CodeAnalysis;

namespace EmojiLibrary
{
    public class Emoji : IInit, IComparable, ICloneable
    {
        protected Random rnd = new Random();

        private string name;
        private string tag;

        static string[] Names = { "Улыбка", "Сияющий", "Задумчивый", "Привет", "Праздник", "Ура", "Работа", "Инструменты", "Искусство", "Настройки", "Ракета" };
        static string[] Tags = { "<smile>", "<happy>", "<thinking>", "<wave>", "<celebrate>", "<hooray>", "<work>", "<tools>", "<art>", "<settings>", "<rocket>" };
        public string Name { get; set; }
        public string Tag { get; set; }

        public Emoji()
        {
            Name = "NoName";
            Tag = "<NoTag>";
        }
        public Emoji(string name, string tag)
        {
            Name = name;
            Tag = tag;
        }

        public virtual void Init()
        {
            Console.Write("Введите название: ");
            Name = Console.ReadLine();
            Console.Write("Введите тэг: ");
            Tag = Console.ReadLine();
        }

        public virtual void RandomInit()
        {
            Name = Names[rnd.Next(Names.Length)];
            Tag = Tags[rnd.Next(Tags.Length)];
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Emoji e)
                return this.Name == e.Name && this.Tag == e.Tag;
            return false;
        }

        public override string ToString()
        {
            return Name + ", " + Tag;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Эмодзи: Название = {Name}, тэг = {Tag}");
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return -1;
            if (obj is not Emoji) return -1;
            Emoji e = obj as Emoji;

            int nameComparison = String.Compare(this.Name, e.Name);
            if (nameComparison != 0)
            {
                return nameComparison; // Если имена различаются, возвращаем результат сравнения имен
            }
            else
            {
                return String.Compare(this.Tag, e.Tag); // Если имена совпадают, сравниваем по тегам
            }
        }

        public object Clone()
        {
            return new Emoji(Name, Tag);
        }
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
        public override int GetHashCode()
        {
            unchecked // Предотвращает переполнение при вычислении хэш-кода
            {
                int hash = 17; // Начальное значение хэш-кода

                // Умножаем на простое число и прибавляем хэш-код каждого свойства
                hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
                hash = hash * 23 + (Tag != null ? Tag.GetHashCode() : 0);

                return hash;
            }
        }
    }
}