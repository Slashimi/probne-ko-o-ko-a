using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokwium
{
    class Skladnik
    {
        protected string nazwaSkladnika;
        protected double cenaSkladnika;

        public Skladnik(string nazwaSkladnika, double cenaSkladnika)
        {
            this.nazwaSkladnika = nazwaSkladnika;
            this.cenaSkladnika = cenaSkladnika;
        }

        public override string ToString()
        {
            return "Skladnik: {" + this.nazwaSkladnika + "}, cena: {" + this.cenaSkladnika + "}";
        }

        public double PobierzCene()
        {
            return this.cenaSkladnika;
        }
    }

    class Sos : Skladnik
    {
        public Sos(string nazwaSkladnika, double cenaSkladnika) : base(nazwaSkladnika, cenaSkladnika)
        {
            this.nazwaSkladnika = nazwaSkladnika;
            this.cenaSkladnika = cenaSkladnika;
        }

        public override string ToString()
        {
            return "Sos: {" + this.nazwaSkladnika + "}, cena: {" + this.cenaSkladnika + "}";
        }

    }

    abstract class Zamowienie
    {
        protected string czasDostawy;

        public virtual bool PoprawnyCzas()
        {
            if (czasDostawy != null)
            {
                return true;
            }
            else return false;
        }

        public void UstawCzasDostawy(string czasDostawy)
        {
            this.czasDostawy = czasDostawy;
        }  
    }

    class NaMiejscu : Zamowienie
    { }

    class NaWynos : Zamowienie
    {
        public override bool PoprawnyCzas()
        {
            if (czasDostawy == "jutro")
            {
                return true;
            }
            else return false;
        }
    }

    interface IPrzepis
    {
        void DodajDoPrzepisu(string przepis);
        void Wypisz();
    }

    class Pizza : IPrzepis
    {
        private List<string> przepis = new List<string>();

        public void DodajDoPrzepisu(string przep)
        {
            przepis.Add(przep);
        }
        public void Wypisz()
        {
            przepis.ForEach(i => Console.Write("{0}\t", i));
        }
      
    }

    class Piec
    {
        private int czas;

        public void NastawCzas(int czas)
        {
            this.czas = czas;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Skladnik o1 = new Skladnik("ser", 3.15);
            Skladnik o2 = new Skladnik("ananas", 3.00);
            Skladnik o3 = new Skladnik("szynka", 3.50);
            Skladnik o4 = new Skladnik("salami", 3.70);
            Skladnik o5 = new Skladnik("cebula", 3.90);
            Sos s1 = new Sos("Ostry", 2.00);

            //Console.WriteLine(o1.nazwaSkladnika);
            //Console.WriteLine(o1.ToString());

            List<Skladnik> pizza = new List<Skladnik>();

            pizza.Add(o1);
            pizza.Add(o2);
            pizza.Add(o3);
            pizza.Add(o4);
            pizza.Add(o5);
            pizza.Add(s1);

            foreach(Skladnik x in pizza)
            {
                Console.WriteLine(x.ToString());
            }

            pizza = pizza.OrderByDescending(o => o.PobierzCene()).ToList();


            foreach (Skladnik x in pizza)
            {
                Console.WriteLine(x.ToString());
            }
            int zet = 0;

            foreach (Skladnik x in pizza)
            {
                zet += 1;
                if (zet % 2 == 0)
                {
                    Console.WriteLine(x.ToString());
                }
            }

            pizza.Reverse();

            foreach (Skladnik x in pizza)
            {
                Console.WriteLine(x.ToString());
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////

            Queue<Zamowienie> zamowienia = new Queue<Zamowienie>();

            NaMiejscu nw1 = new NaMiejscu();
            NaMiejscu nw2 = new NaMiejscu();
            NaWynos nm1 = new NaWynos();
            NaWynos nm2 = new NaWynos();
            NaWynos nm3 = new NaWynos();

            
            nw2.UstawCzasDostawy("a1");
            nm1.UstawCzasDostawy("a1");
            nm2.UstawCzasDostawy("jutro");
            nm3.UstawCzasDostawy("a1");

            zamowienia.Enqueue(nw1);
            zamowienia.Enqueue(nw2);
            zamowienia.Enqueue(nm1);
            zamowienia.Enqueue(nm2);
            zamowienia.Enqueue(nm3);

            foreach(Zamowienie x in zamowienia)
            {
                Console.WriteLine(x.PoprawnyCzas());
            }

            // zamowienia.Clear();
            foreach(Zamowienie x in zamowienia)
            {
                Console.WriteLine(zamowienia.ToString());
            }

            for (int i=0;i<5;i++)
            {
                Console.WriteLine(zamowienia.Dequeue());
            }

            foreach (Zamowienie x in zamowienia)
            {
                Console.WriteLine(zamowienia.ToString());
            }

            //////////////////////////////ZAD8////////////////////////////////////////////////////

            Pizza p1 = new Pizza();
            p1.DodajDoPrzepisu("dupoa");
            p1.Wypisz();


            Piec piec1 = new Piec();
            piec1.NastawCzas(15);


            Console.ReadKey();
        }
    }
}
