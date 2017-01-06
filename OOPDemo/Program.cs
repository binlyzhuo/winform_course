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

        /// <summary>
        /// 泛型委托协变
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public delegate T Find<out T>();

        static void Main(string[] args)
        {
            Console.WriteLine("逆变和协变");

            // 数组的协变
            Animal[] dogs = new Dog[]{};

            // 委托协变
            GetAnimal getAnimal = new GetAnimal(GetDog);
            getAnimal();

            // 委托逆变
            FeedDog feedDog = FeedAnimal;
            feedDog(new Dog());

            // 委托泛型逆变
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

            // 接口逆变
            IFeedable<Dog> feedDog2 = new FeedImp<Animal>();
            feedDog2.Feed(new Dog());

            // 接口协变
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
