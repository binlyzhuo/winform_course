using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPDemo
{
    //http://blog.csdn.net/limlimlim/article/details/7817677#
    class Program
    {
        public delegate Animal GetAnimal();

        public delegate void FeedDog(Dog dog);

        public delegate void Feed<in T>(T target);

        public delegate T Find<out T>();

        static void Main(string[] args)
        {
            Console.WriteLine("逆变和协变");
            Animal[] dogs = new Dog[]{};

            GetAnimal getAnimal = new GetAnimal(GetDog);
            getAnimal();

            FeedDog feedDog = FeedAnimal;
            feedDog(new Dog());

            Feed<Animal> feedAnimalMethod = a => Console.WriteLine("Feed Animal Lambda!");
            Feed<Dog> feedDogMethod = feedAnimalMethod;
            feedDogMethod(new Dog());

            Find<Dog> findDog= () =>
            {
                Console.WriteLine("Find Dog!!");
                return new Dog();
            };
            Find<Animal> findAnimal = findDog;
            findAnimal();

            IFeedable<Dog> feedDog2 = new FeedImp<Animal>();
            feedDog2.Feed(new Dog());

            // 协变
            IFinder<Animal> findAnimal2 = new Finder<Dog>();

            Console.ReadLine();
        }

        static Dog GetDog()
        {
            Console.WriteLine("GET DOG!!");
            return new Dog();
        }

        static void FeedAnimal(Animal animal)
        {
            Console.WriteLine("Feed Animal!");
        }
    }

    public class Animal
    {
        
    }

    public class Dog : Animal
    {
        
    }

    public interface IFeedable<in T>
    {
        void Feed(T t);
    }

    public class FeedImp<T> : IFeedable<T>
    {
        public void Feed(T t)
        {
            Console.WriteLine("Feed Animal Imp!!");
        }
    }

    public interface IFinder<out T>
    {
        T Find();
    }

    public class Finder<T> : IFinder<T>
        where T:class,new()
    {
        public T Find()
        {
            return new T();
        }
    }
}
